using FutebolDeRobosVSS.interfaces.ambiente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using FutebolDeRobosVSS.interfaces.dados;

namespace FutebolDeRobosVSS.implementacoes
{
    class Campo : ICampoProcessamento, ICampoEstrategia
    {
        private Rectangle gol;
        private Rectangle golAdversario;
        private Rectangle grandeArea;
        private Rectangle grandeAreaAdversario;
        private Rectangle meioCampo;
        private Rectangle areaTotal;


        public Rectangle Gol
        {
            get
            {
                return this.gol;
            }

            set
            {
                this.gol = value;
            }
        }

        public Rectangle GolAdversario
        {
            get
            {
                return this.golAdversario;
            }

            set
            {
                this.golAdversario = value;
            }
        }

        public Rectangle GrandeArea
        {
            get
            {
                return this.grandeArea;
            }

            set
            {
                this.grandeArea = value;
            }
        }

        public Rectangle GrandeAreaAdversario
        {
            get
            {
                return this.grandeAreaAdversario;
            }

            set
            {
                this.grandeAreaAdversario = value;
            }
        }

        public Rectangle MeioCampo
        {
            get
            {
                return this.meioCampo;
            }

            set
            {
                this.meioCampo = value;
            }
        }

        public Rectangle AreaTotal
        {
            get
            {
                return this.areaTotal;
            }

            set
            {
                this.areaTotal = value;
            }
        }
    }
}
