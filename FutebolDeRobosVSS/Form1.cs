using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using FutebolDeRobosVSS.implementacoes.atuadores;
using FutebolDeRobosVSS.implementacoes.controle;
using FutebolDeRobosVSS.interfaces.ambiente;
using FutebolDeRobosVSS.interfaces.atuadores;
using FutebolDeRobosVSS.interfaces.controle;
using FutebolDeRobosVSS.utilidades;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace FutebolDeRobosVSS
{
    public partial class Form1 : Form
    {
        private bool mostrar = true;
        private bool estaApertada = false;

        IControle controle;
        private bool pode;

        public Form1()
        {
            InitializeComponent();


            pode = false;
            /*
            visaoComp = new VisaoComputacional();
            estrategia = new Estrategia();
            expedidor = new Expedidor();
            */

            controle = new Controle();

            controle.capturarDaCamera(0);
            controle.desenharBgr(imageBoxOriginal);
            controle.desenharGray(imageBoxGray);
            controle.exibirImagens(true);


            foreach (var item in SerialPort.GetPortNames())
            {
                label1.Text += item + " ";
            }
            /*
            //Configuracoes da visao computacional
            visaoComp.setupCamera(1);
            //((VisaoComputacional)visaoComp).setImageBox(imageBoxOriginal);

            visaoComp.iniciarCaptura();
            

            visaoComp.novoRobo("Atacante");
            /*visaoComp.novoRobo("Goleiro");
            visaoComp.novoRobo("Zagueiro");

            visaoComp.definirRange("Atacante", new Range(new Hsv(1, 1, 1)));
            visaoComp.definirRange("Goleiro", new Range(new Hsv(50, 50, 50)));
            visaoComp.definirRange("Zagueiro", new Range(new Hsv(100, 100, 100)));

            visaoComp.definirRange("BOLA", new Range(new Hsv(100, 100, 100)));
            visaoComp.definirRange("TIME", new Range(new Hsv(100, 100, 100)));*/
            //Configuracoes da Estratégia


            //Configurar expedidor
            /*expedidor.definirPortaRobo("Atacante", "COM1");
            expedidor.definirPortaRobo("Goleiro", "COM2");
            expedidor.definirPortaRobo("Zagueiro", "COM3");*/

            //Liga a conexão
            /*expedidor.conectarPortaRobo("Atacante");
            expedidor.conectarPortaRobo("Goleiro");
            expedidor.conectarPortaRobo("Zagueiro");*/

            /*
            ambEstrat = visaoComp.pegarAmbienteAtual();
            ambExped = estrategia.processarAmbiente(ambEstrat);
            expedidor.despachar(ambExped);



            //Desenha as imagens nas ImageBoxes
            desenhistaDeImagens = new BackgroundWorker();
            desenhistaDeImagens.DoWork += desenharImagens;
            desenhistaDeImagens.RunWorkerAsync();*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrar = !mostrar;
            controle.exibirImagens(mostrar);
        }



        private void originalImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            Range rangeDeCorAtual;
            Point p = new Point(e.X, e.Y);
            Rectangle retanguloSelecao = new Rectangle(p.X - 5, p.Y - 5, 3, 3);
            if (retanguloSelecao.X < 0)
            { retanguloSelecao.X = 0; }
            if (retanguloSelecao.Y < 0)
            { retanguloSelecao.Y = 0; }
            Hsv corMediaSelecionada;

            using (Image<Bgr, Byte> regiaoSelecionada = ((Image<Bgr, Byte>)imageBoxOriginal.Image).
                Resize(imageBoxOriginal.Width, imageBoxOriginal.Height, Inter.Linear).
                GetSubRect(retanguloSelecao))
            {
                using (Image<Hsv, Byte> TouchRegionHsv = regiaoSelecionada.Convert<Hsv, byte>())
                {
                    //pega a media dos valores
                    corMediaSelecionada = TouchRegionHsv.GetAverage();
                    //pega o intervalo de +-delta da cor
                    rangeDeCorAtual = new Range(corMediaSelecionada, 20,20);
                }
            }
            controle.defineBola(rangeDeCorAtual);
        }

        private void grayImageBox_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (pode)
            {
                if (!estaApertada)
                {
                    estaApertada = true;
                    try
                    {
                        switch (e.KeyCode)
                        {
                            case Keys.Left://255
                                controle.controleManual("ATACANTE", 80, 0);
                                break;
                            case Keys.Up:
                                controle.controleManual("ATACANTE", 80, 80);
                                break;
                            case Keys.Right:
                                controle.controleManual("ATACANTE", 0, 80);
                                break;
                            case Keys.Down:
                                controle.controleManual("ATACANTE", -80, -80);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "AQUI ACELERA");
                    }
                }
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (pode)
            {
                estaApertada = false;
                controle.controleManual("ATACANTE", 0, 0);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            pode = true;
            try { controle.criarRobo("ATACANTE", new Range(new Hsv()), "ATACANTE", textBox1.Text); } catch { }

            /*expedidor.definirPortaRobo("Atacante", );
            expedidor.conectarPortaRobo("Atacante");*/

        }

        private void aceleraRobo(object sender, KeyPressEventArgs e)
        {

        }
    }
}