using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.CvEnum;
using System.Drawing;
using FutebolDeRobosVSS.interfaces.dados;

namespace FutebolDeRobosVSS.interfaces.ambiente
{
    public interface IAmbienteVisaoComputacional
    {
        IBolaProcessamento Bola { get; set; }

        IReadOnlyList<IRoboProcessamento> ListaRobos { get; }

        IRoboProcessamento getRobo(string id);

        ICampoProcessamento Campo { get; set; }

        //void adicionaRobo(string nome);

        void atualizaPosicaoRobo(string nome, Point pTime, Point pIndividuo);

        //void removeRobo(string nome);
    }
}
