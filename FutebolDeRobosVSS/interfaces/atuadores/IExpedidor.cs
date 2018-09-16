using FutebolDeRobosVSS.interfaces.ambiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolDeRobosVSS.interfaces.atuadores
{
    interface IExpedidor
    {
        void despacharAmbiente();

        void definirPortaRobo(string nome, string porta);

        void conectarPortaRobo(string nome);

        void desconectarPortaRobo(string nome);
    }
}
