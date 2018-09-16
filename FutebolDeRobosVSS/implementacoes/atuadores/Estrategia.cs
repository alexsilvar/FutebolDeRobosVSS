using FutebolDeRobosVSS.interfaces.atuadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutebolDeRobosVSS.interfaces.ambiente;
using Emgu.CV.Structure;
using System.Drawing;
using FutebolDeRobosVSS.interfaces.dados;

namespace FutebolDeRobosVSS.implementacoes.atuadores
{
    class Estrategia : IEstrategia
    {
        private struct Direction
        {
            public const double UP = Math.PI / 2;
            public const double DOWN = -Math.PI / 2;
            public const double RIGHT = 0;
            public const double LEFT = Math.PI;
        }


        private Dictionary<string, string> roboPapel;

        private IAmbienteEstrategia ambiente;

        private string estrategiaAtiva;

        public Estrategia(IAmbienteEstrategia ambiente)
        {
            this.ambiente = ambiente;
            roboPapel = new Dictionary<string, string>();
        }

        void IEstrategia.definicaoManual(string id, int velDireita, int velEsquerda)
        {
            ambiente.getRobo(id).RodaDireita = velDireita;
            ambiente.getRobo(id).RodaEsquerda = velEsquerda;
        }

        void IEstrategia.definePapel(string id, string papel)
        {
            try { roboPapel.Add(id, papel); }
            catch { roboPapel[id] = papel; }
        }

        private void seguePonto(IRoboEstrategia robo, Point meta)
        {
            LineSegment2D orientacaoRobo = new LineSegment2D();
            LineSegment2D orientacaoRoboBola = new LineSegment2D();
            Point meio = new Point();
            
            //orientação do robô
            orientacaoRobo.P1 = robo.PontoIndividual;
            orientacaoRobo.P2 = robo.PontoTime;

            //Meio do robo
            meio.X = (int)((orientacaoRobo.P1.X + orientacaoRobo.P2.X) / 2.0);
            meio.Y = (int)((orientacaoRobo.P1.Y + orientacaoRobo.P2.Y) / 2.0);

            //reta entre o meio do robo e a bola
            orientacaoRoboBola.P1 = meta;
            orientacaoRoboBola.P2 = meio;

            //angulo entre as retas
            double angulo = orientacaoRobo.GetExteriorAngleDegree(orientacaoRoboBola);
            int velMaior, velMenor;
            if (orientacaoRoboBola.Length > 50)
            {
                velMaior = 255;
                velMenor = 100;
            }
            else
            {
                velMaior = 0;
                velMenor = 200;
            }

            if (angulo > 0 && angulo < 180) //Na frente
            {
                if (angulo < 80)
                {
                    robo.RodaEsquerda = velMaior;
                    robo.RodaDireita = velMenor;
                }
                else if (angulo > 100)
                {
                    robo.RodaEsquerda = velMenor;
                    robo.RodaDireita = velMaior;
                }
                else
                {
                    robo.RodaEsquerda = velMaior;
                    robo.RodaDireita = velMaior;
                }
            }
            else //atrás
            {
                if (angulo < 80)
                {
                    robo.RodaEsquerda = -velMaior;
                    robo.RodaDireita = -velMenor;
                }
                else if (angulo > 100)
                {
                    robo.RodaEsquerda = -velMenor;
                    robo.RodaDireita = -velMaior;
                }
                else
                {
                    robo.RodaEsquerda = -velMaior;
                    robo.RodaDireita = -velMaior;
                }
            }
        }

        void IEstrategia.processarAmbiente()
        {
            foreach (var robo in ambiente.ListaRobos)
            {
                switch (estrategiaAtiva)
                {
                    case "SEGUEBOLA":
                        seguePonto(robo, ambiente.Bola.Posicao);
                        break;
                }
            }
        }

        void IEstrategia.selecionaEstrategia(string id)
        {
            estrategiaAtiva = id;
        }

        string IEstrategia.estrategiasDisponiveis()
        {
            return "SEGUEBOLA";
        }

    }
}
