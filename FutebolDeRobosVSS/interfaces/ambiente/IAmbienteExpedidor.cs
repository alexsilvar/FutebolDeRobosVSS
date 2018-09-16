using FutebolDeRobosVSS.interfaces.dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolDeRobosVSS.interfaces.ambiente
{
    interface IAmbienteExpedidor
    {
        IReadOnlyList<IRoboExpedidor> ListaRobos { get; }

        IRoboExpedidor getRobo(string id);

        void definirPorta(string nome, string porta);
    }
}
