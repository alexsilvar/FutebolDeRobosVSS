using FutebolDeRobosVSS.utilidades;
using System.Drawing;
using System.IO.Ports;

namespace FutebolDeRobosVSS.interfaces.dados
{
    interface IRoboEstrategia
    {
        Point PontoTime { get; }

        Point PontoIndividual { get; }

        string Nome { get; }

        int RodaDireita { set; get; }

        int RodaEsquerda { set; get; }

        //SerialPort Porta { get; }

        //Range CorIndividual { get; }
    }
}
