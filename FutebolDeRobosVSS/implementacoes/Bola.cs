using FutebolDeRobosVSS.interfaces.ambiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FutebolDeRobosVSS.utilidades;
using FutebolDeRobosVSS.interfaces.dados;

namespace FutebolDeRobosVSS.implementacoes
{
    class Bola : IBolaProcessamento, IBolaEstrategia
    {
        private Point posicao;
        private Point posicaoAnterior;
        private Range rangeCorBola;

        public Point Posicao
        {
            get
            {
                return posicao;
            }

            set
            {
                posicaoAnterior = Posicao;
                posicao = value;
            }
        }

        public Point PosicaoAnteiror
        {
            get
            {
                return posicaoAnterior;
            }
        }

        public Range RangeCorBola
        {
            get
            {
                return rangeCorBola;
            }

            set
            {
                rangeCorBola = value;
            }
        }

        public Bola()
        {
            posicao = Point.Empty;
            posicaoAnterior = Point.Empty;
        }

    }
}
