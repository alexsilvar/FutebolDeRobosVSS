using Emgu.CV.Structure;
using FutebolDeRobosVSS.utilidades;
using System.Drawing;
using System.IO.Ports;

namespace FutebolDeRobosVSS.interfaces.dados
{
    public interface IRoboProcessamento
    {
        Point PontoTime { get; set; }
        Point PontoIndividual { get; set; }


        string Nome { get; set; }

        int RodaDireita { get; set; }

        int RodaEsquerda { get; set; }

        //SerialPort Porta { get; set; }

        Range CorIndividual { get; set; }
    }
}