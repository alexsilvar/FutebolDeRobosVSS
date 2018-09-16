using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolDeRobosVSS.interfaces.dados
{
    interface IRoboExpedidor
    {
        string Nome { get; }

        int RodaDireita { get; }

        int RodaEsquerda { get; }

        SerialPort Porta { get; set; }
    }
}
