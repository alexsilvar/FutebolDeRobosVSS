using Emgu.CV;
using Emgu.CV.Structure;
using FutebolDeRobosVSS.utilidades;
using FutebolDeRobosVSS.interfaces.ambiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolDeRobosVSS.interfaces.atuadores
{
    interface IVisaoComputacional
    {

        Image<Bgr, Byte> ImagemRgb { get; }

        Image<Hsv, Byte> ImagemHsv { get; }

        Image<Gray, byte> ImagemGray { get; }

        IAmbienteEstrategia processarAmbienteAtual();

        //Definições  do ambiente
        void definirRange(string nome, Range range);

        //Videocaptura
        void setupCamera(int deviceId, int frameWidth = 1920, int frameHeight = 1080);

        void iniciarCaptura();

        void pararCaptura();

    }
}
