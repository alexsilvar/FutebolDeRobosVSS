using FutebolDeRobosVSS.interfaces.controle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.UI;
using FutebolDeRobosVSS.utilidades;
using System.Drawing;
using FutebolDeRobosVSS.interfaces.atuadores;
using System.ComponentModel;
using FutebolDeRobosVSS.implementacoes.atuadores;
using Emgu.CV.CvEnum;
using FutebolDeRobosVSS.interfaces.ambiente;

namespace FutebolDeRobosVSS.implementacoes.controle
{
    class Controle : IControle
    {
        #region Atuadores
        private IVisaoComputacional visaoComp;
        private IEstrategia estrategia;
        private IExpedidor expedidor;

        private IAmbienteControle ambiente;
        #endregion

        #region Desenhistas
        private BackgroundWorker desenhista;
        #endregion

        #region processador Jogo
        private BackgroundWorker jogo;
        #endregion

        #region ImageBoxes
        private ImageBox imageBoxBgr;
        private ImageBox imageBoxHsv;
        private ImageBox imageBoxGray;
        #endregion

        #region Construtores
        public Controle()
        {
            Ambiente amb = new Ambiente();//Novo ambiente

            this.ambiente = amb;//Ambiente controle recebeo mesmo ambiente

            visaoComp = new VisaoComputacional(amb);
            estrategia = new Estrategia(amb);
            expedidor = new Expedidor(amb);

            desenhista = new BackgroundWorker();
            desenhista.WorkerSupportsCancellation = true;
            desenhista.DoWork += desenhar;

            jogo = new BackgroundWorker();
            jogo.WorkerSupportsCancellation = true;
            jogo.DoWork += jogar;
        }
        #endregion

        #region Controle dos Atuadores
        void IControle.criarRobo(string id, Range cor, string papel, string com)
        {
            ambiente.novoRobo(id);
            visaoComp.definirRange(id, cor);
            estrategia.definePapel(id, papel);
            expedidor.definirPortaRobo(id, com);
        }

        void IControle.defineBola(Range cor)
        {
            visaoComp.definirRange("BOLA", cor);
        }

        void IControle.defineCampo(Rectangle[] areas)
        {
            ambiente.definirCampo(areas);
        }

        void IControle.defineTime(Range cor)
        {
            visaoComp.definirRange("TIME", cor);
        }
        #endregion

        #region Interação com UI
        void IControle.desenharBgr(ImageBox imageBoxBgr)
        {
            this.imageBoxBgr = imageBoxBgr;
        }

        void IControle.desenharGray(ImageBox imageBoxGray)
        {
            this.imageBoxGray = imageBoxGray;
        }

        void IControle.desenharHsv(ImageBox imageBoxHsv)
        {
            this.imageBoxHsv = imageBoxHsv;
        }

        void IControle.capturarDaCamera(int camId)
        {
            visaoComp.setupCamera(camId);
            visaoComp.iniciarCaptura();
        }

        #region Desenhar
        private void desenhar(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                if (imageBoxBgr != null)
                {
                    if (visaoComp.ImagemRgb != null)
                        imageBoxBgr.Image = visaoComp.ImagemRgb.Resize(imageBoxBgr.Width, imageBoxBgr.Height, Inter.Linear);
                }
                if (imageBoxGray != null)
                {
                    if (visaoComp.ImagemGray != null)
                        imageBoxGray.Image = visaoComp.ImagemGray.Resize(imageBoxGray.Width, imageBoxGray.Height, Inter.Linear);
                }
                if (imageBoxHsv != null)
                {
                    if (visaoComp.ImagemHsv != null)
                        imageBoxHsv.Image = visaoComp.ImagemHsv.Resize(imageBoxHsv.Width, imageBoxHsv.Height, Inter.Linear);
                }
                if (desenhista.CancellationPending)
                {
                    e.Cancel = true;
                }
            }
        }

        void IControle.exibirImagens(bool exibir)
        {
            if (exibir) //se deve exibir
            {
                if (!desenhista.IsBusy) { desenhista.RunWorkerAsync(); }//Se nao esta rodando - roda
            }
            else
            {
                if (desenhista.IsBusy) { desenhista.CancelAsync(); } //Se esta rodando para
            }
        }

        void IControle.controleManual(string id, int velDireita, int velEsquerda)
        {
            estrategia.definicaoManual(id, velDireita, velEsquerda);
            expedidor.despacharAmbiente();
        }

        #endregion
        #endregion

        #region Jogar
        void IControle.iniciarJogo()
        {
            if (!jogo.IsBusy) { jogo.RunWorkerAsync(); }//Se nao esta rodando - roda
        }

        void IControle.pararJogo()
        {
            if (jogo.IsBusy) { jogo.CancelAsync(); } //Se esta rodando para
        }

        private void jogar(object sender, DoWorkEventArgs e)
        {
            while (!e.Cancel)
            {
                visaoComp.processarAmbienteAtual();
                estrategia.processarAmbiente();
                expedidor.despacharAmbiente();
                if (jogo.CancellationPending) { e.Cancel = true; }
            }
        }

        #endregion
    }
}