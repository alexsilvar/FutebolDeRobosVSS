using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using FutebolDeRobosVSS.utilidades;
using System.Drawing;

namespace FutebolDeRobosVSS.interfaces.controle
{
    interface IControle
    {
        #region Setup do ambiente
        /**
         * param name="id" Nome único do Robô - Compreendido em todas os atuadores
         * param name="cor" Cor do robô - Compreendido pela visão Computacional
         * param name="papel" Papel do robô - Compreendido pela Estratégia
         * param name="com" Comunicação - Compreendido pelo Expedidor
         */
        void criarRobo(string id, Range cor, string papel, string com);

        /**
         * param name="cor" Cor da bola - Compreendido pela visão
         */
        void defineBola(Range cor);

        /**
         * param name="cor" Cor do time - Compreendido pela visão
         */
        void defineTime(Range cor);

        /**
         * param name="areas" Áreas do campo - definir na visão computacional
         */
        void defineCampo(Rectangle[] areas);
        #endregion

        #region Captura de vídeo
        void capturarDaCamera(int camId);
        #endregion

        #region Exibição na UI
        void desenharBgr(ImageBox imageBoxBgr);
        void desenharHsv(ImageBox imageBoxHsv);
        void desenharGray(ImageBox imageBoxGray);
        void exibirImagens(bool exibir);
        #endregion

        void controleManual(string id, int velDireita, int velEsquerda);

        #region jogo
        void iniciarJogo();
        void pararJogo();
        #endregion
    }
}
