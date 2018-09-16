using FutebolDeRobosVSS.interfaces.ambiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutebolDeRobosVSS.interfaces.atuadores
{
    interface IEstrategia
    {

        void processarAmbiente();
        void selecionaEstrategia(string id = "DEFAULT");
        string estrategiasDisponiveis();
        void definePapel(string id, string papel);
        void definicaoManual(string id, int velDireita, int velEsquerda);


        //Metodos para definir estratégia e fazer calibrações na mesma
    }
}
