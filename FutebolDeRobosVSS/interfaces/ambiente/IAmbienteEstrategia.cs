using FutebolDeRobosVSS.interfaces.dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolDeRobosVSS.interfaces.ambiente
{
    interface IAmbienteEstrategia
    {
        IBolaEstrategia Bola { get; }

        IReadOnlyList<IRoboEstrategia> ListaRobos { get; }

        IRoboEstrategia getRobo(string id);

        ICampoEstrategia Campo { get; }
    }
}
