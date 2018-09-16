
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Structure;
using System.Drawing;
using System.IO.Ports;
using FutebolDeRobosVSS.utilidades;
using FutebolDeRobosVSS.interfaces.dados;

namespace FutebolDeRobosVSS.implementacoes
{
    class Robo : IRoboProcessamento, IRoboEstrategia, IRoboExpedidor
    {
        public Robo(string nome)
        {
            this.nome = nome;
        }

        private Point pontoTime;
        private Point pontoIndividual;
        private string nome;
        private SerialPort porta;
        private int rodaDireita;
        private int rodaEsquerda;
        private Range corIndividual;


        public int RodaDireita
        {
            get
            {
                return this.rodaDireita;
            }

            set
            {
                this.rodaDireita = value;
            }
        }

        public int RodaEsquerda
        {
            get
            {
                return rodaEsquerda;
            }

            set
            {
                rodaEsquerda = value;
            }
        }

        public Range CorIndividual
        {
            get
            {
                return corIndividual;
            }

            set
            {
                corIndividual = value;
            }
        }

        public Point PontoTime
        {
            get
            {
                return pontoTime;
            }

            set
            {
                pontoTime = value;
            }
        }

        public Point PontoIndividual
        {
            get
            {
                return pontoIndividual;
            }

            set
            {
                pontoIndividual = value;
            }
        }



        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public SerialPort Porta
        {
            get
            {
                return porta;
            }

            set
            {
                porta = value;
            }
        }


    }
}
