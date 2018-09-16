using FutebolDeRobosVSS.interfaces.atuadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using FutebolDeRobosVSS.interfaces.ambiente;
using Emgu.CV.Structure;
using System.Drawing;
using FutebolDeRobosVSS.utilidades;
using Emgu.CV.CvEnum;
using System.ComponentModel;
using FutebolDeRobosVSS.interfaces.dados;
using Emgu.CV.UI;

namespace FutebolDeRobosVSS.implementacoes.atuadores
{

    class VisaoComputacional : IVisaoComputacional
    {
        private Image<Bgr, Byte> imagemRgb;
        private Image<Hsv, Byte> imagemHsv;
        private Image<Gray, Byte> imagemGray;
        private IAmbienteVisaoComputacional ambiente;
        private bool ambienteProcessando;

        private Range rangeTime;

        private Image<Bgr, Byte> temp;

        #region captura de imagens
        private Capture captura;
        private Mat quadro;

        /*public event Action imagemCapturada;
        BackgroundWorker desenhistaDeImagens;*/


        ImageBox imgBoxOriginal;

        public void setImageBox(ImageBox box)
        {
            imgBoxOriginal = box;
        }

        public void iniciarCaptura()
        {
            captura.Start();
        }

        public void pararCaptura()
        {
            captura.Stop();
        }

        public void setupCamera(int deviceId, int frameWidth = 1920, int frameHeight = 1080)
        {
            try
            {
                if (captura != null)
                {
                    captura.Stop();
                }
                captura = new Capture(deviceId);
                //Pra ficar igual espelho
                //_capture.FlipHorizontal = !_capture.FlipHorizontal;
                //Se colocar 1920x1080 fica low fps acima ele seta em 1920x1080 então, bora
                captura.SetCaptureProperty(CapProp.FrameWidth, frameWidth);
                captura.SetCaptureProperty(CapProp.FrameHeight, frameHeight);
                captura.ImageGrabbed += imagemColetada;

            }
            catch (NullReferenceException excpt)
            {
                throw new Exception(excpt.Message);
            }
        }

        private void imagemColetada(object sender, EventArgs arg)
        {
            if (!ambienteProcessando)
            {
                if (captura != null && captura.Ptr != IntPtr.Zero)
                {
                    try
                    {
                        captura.Retrieve(quadro);
                        //Reduz o tamanho do quadro
                        CvInvoke.Resize(quadro, quadro, new Size(720, 480));

                        temp = quadro.ToImage<Bgr, Byte>();
                        //temp._EqualizeHist();
                        imagemRgb = temp;

                        CvInvoke.MedianBlur(imagemRgb, imagemRgb, 3);

                        imagemHsv = imagemRgb.Convert<Hsv, Byte>();
                        imagemHsv._SmoothGaussian(5, 5, 0.1, 0.1);
                        if (ambiente != null && ambiente.Bola != null && ambiente.Bola.RangeCorBola != null)
                        {
                            Image<Gray, Byte> temp2 = ImagemHsv.InRange(ambiente.Bola.RangeCorBola.Lowerrange, ambiente.Bola.RangeCorBola.Upperrange);

                            temp2._EqualizeHist();
                            imagemGray = temp2;
                        }
                        /*if (ambiente != null)
                        {

                            imgBoxOriginal.Image = imagemRgb.Resize(480, 270, Inter.Nearest);
                            //Aplicando o gaussian para "interligar" a imagem
                            imagemRgb._SmoothGaussian(3, 3, 1, 1);
                            CvInvoke.MedianBlur(imagemRgb, imagemRgb, 3);

                            //Converter de RGB para HSV
                            imagemHsv = imagemRgb.Convert<Hsv, Byte>();
                            //Aplicando Filtro
                            imagemHsv._SmoothGaussian(5, 5, 0.1, 0.1);

                            if (ambiente.Bola != null && ambiente.Bola.RangeCorBola != null)
                            {
                                imagemGray = ImagemHsv.InRange(ambiente.Bola.RangeCorBola.Lowerrange, ambiente.Bola.RangeCorBola.Upperrange);
                            }


                        }*/
                    }
                    catch { }
                }
            }
        }
        #endregion

        public VisaoComputacional(IAmbienteVisaoComputacional ambiente)
        {
            CvInvoke.UseOpenCL = false;
            imagemRgb = null;
            captura = null;
            quadro = new Mat();
            this.ambiente = ambiente;
            ambienteProcessando = false;
        }

        public Image<Hsv, byte> ImagemHsv
        {
            get
            {
                return imagemHsv;
            }
        }

        public Image<Gray, byte> ImagemGray
        {
            get
            {
                return imagemGray;
            }
        }

        public Image<Bgr, byte> ImagemRgb
        {
            get
            {
                return imagemRgb;
            }
        }


        /// <summary>
        /// Define o range de deteção de cor de ume elmento de jogo - Bola ou robô
        /// </summary>
        /// <param name="nome">Nome do elemento, BOLA ou ATACANTE, JURISCLEISON</param>
        /// <param name="range">Range paradefinir o </param>
        public void definirRange(string nome, Range range)
        {
            if (string.Equals(nome, "BOLA"))
            {
                if (ambiente.Bola != null)
                {
                    ambiente.Bola.RangeCorBola = range;
                    return;
                }
            }
            if (string.Equals(nome, "TIME"))
            {
                if (ambiente.Bola != null)
                {
                    rangeTime = range;
                    return;
                }
            }
            IRoboProcessamento r = ambiente.getRobo(nome);
            if (r != null)
            {
                r.CorIndividual = range;
                return;
            }

            throw new Exception("Deve ser 'BOLA', 'TIME' ou existir um Robô de nome" + nome + "\n");
        }

        public IAmbienteEstrategia processarAmbienteAtual()
        {
            ambienteProcessando = true;
            //processar coisas
            ambienteProcessando = false;
            return (IAmbienteEstrategia)ambiente;
        }

        /*public void novoRobo(string nome)
        {
            if (nome.Equals("BOLA") || nome.Equals("TIME"))
            {
                throw new Exception("'BOLA' e 'TIME' São palavras reservadas");
            }
            IRoboProcessamento r = ambiente.ListaRobos.Find(x => x.Nome.Equals(nome));
            if (r == null)
            {
                ambiente.adicionaRobo(nome);
            }
            else { throw new Exception("Apenas nomes únicos, nome:" + nome + " já presente."); }
        }*/


    }
}
