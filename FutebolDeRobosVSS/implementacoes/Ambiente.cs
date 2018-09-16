using FutebolDeRobosVSS.interfaces.ambiente;
using System;
using System.Collections.Generic;
using System.Drawing;
using FutebolDeRobosVSS.interfaces.dados;
using System.IO.Ports;

namespace FutebolDeRobosVSS.implementacoes
{
    class Ambiente : IAmbienteVisaoComputacional, IAmbienteEstrategia, IAmbienteExpedidor, IAmbienteControle
    {
        private Bola bola;
        private Campo campo;
        private List<Robo> robos;

        public Ambiente()
        {
            robos = new List<Robo>();


            bola = new Bola();
            campo = new Campo();
        }

        public IBolaProcessamento Bola
        {
            get
            {
                return bola;
            }

            set
            {
                bola.Posicao = value.Posicao;//atualiza o valor
            }
        }

        IBolaEstrategia IAmbienteEstrategia.Bola
        {
            get
            {
                return bola;
            }
        }

        ICampoEstrategia IAmbienteEstrategia.Campo
        {
            get
            {
                return campo;
            }
        }

        ICampoProcessamento IAmbienteVisaoComputacional.Campo
        {
            get
            {
                return campo;
            }

            set
            {
                campo = (Campo)value;
            }
        }

        IReadOnlyList<IRoboEstrategia> IAmbienteEstrategia.ListaRobos
        {
            get
            {
                return robos.ConvertAll(new Converter<Robo, IRoboEstrategia>(roboToRoboEstrat));
            }
        }

        private IRoboEstrategia roboToRoboEstrat(Robo robo)
        {
            return robo;
        }

        IReadOnlyList<IRoboProcessamento> IAmbienteVisaoComputacional.ListaRobos
        {
            get
            {
                return robos.ConvertAll(new Converter<Robo, IRoboProcessamento>(roboToRoboProcess));
            }
        }

        private IRoboProcessamento roboToRoboProcess(Robo robo)
        {
            return robo;
        }

        IReadOnlyList<IRoboExpedidor> IAmbienteExpedidor.ListaRobos
        {
            get
            {
                return robos.ConvertAll(new Converter<Robo, IRoboExpedidor>(roboToRoboExped));
            }
        }



        private IRoboExpedidor roboToRoboExped(Robo robo)
        {
            return robo;
        }

        public void atualizaPosicaoRobo(string nome, Point pTime, Point pIndividuo)
        {
            foreach (var roboi in robos)
            {
                if (roboi.Nome == nome)
                {
                    roboi.PontoIndividual = pIndividuo;
                    roboi.PontoTime = pTime;
                    return;
                }
            }
            throw new Exception("Robo com este nome não encontrado");
        }



        public void definirPorta(string nome, string porta)
        {
            string names = "";
            foreach (var roboi in robos)
            {
                names += roboi.Nome + "\n";
                if (roboi.Nome == nome)
                {
                    if (roboi.Porta != null && roboi.Porta.IsOpen)
                    {
                        roboi.Porta.Close();
                    }
                    roboi.Porta = new SerialPort(porta);
                    return;
                }
            }
            throw new Exception("Robo de nome:" + nome + " não encontrado \n os robos presentes são: \n" + names);
        }

        void IAmbienteControle.novoRobo(string id)
        {
            Robo r = new Robo(id);
            foreach (var roboi in robos)
            {
                if (roboi.Nome == id)
                {
                    throw new Exception("Robo com este nome já criado");
                }
            }
            robos.Add(new Robo(id));
        }

        void IAmbienteControle.removeRobo(string nome)
        {
            Robo remover = null;
            string names = "";
            foreach (var roboi in robos)
            {
                names += roboi.Nome + "\n";
                if (roboi.Nome == nome)
                {
                    remover = roboi;
                    break;
                }
            }
            if (remover != null)
            {
                robos.Remove(remover);
            }
            else
            {
                throw new Exception("Robo de nome:" + nome + " não encontrado \n os robos presentes são: \n" + names);
            }
        }

        void IAmbienteControle.definirCampo(Rectangle[] areas)
        {
            if (areas.Length < 6)
                throw new Exception("Devem ser informadas 6 áreas");
            campo.AreaTotal = areas[0];
            campo.Gol = areas[1];
            campo.GolAdversario = areas[2];
            campo.GrandeArea = areas[3];
            campo.GrandeAreaAdversario = areas[4];
            campo.MeioCampo = areas[5];

        }

        IRoboExpedidor IAmbienteExpedidor.getRobo(string id)
        {
            return buscaRoboPorNome(id);
        }

        IRoboProcessamento IAmbienteVisaoComputacional.getRobo(string id)
        {
            return buscaRoboPorNome(id);
        }

        IRoboEstrategia IAmbienteEstrategia.getRobo(string id)
        {
            return buscaRoboPorNome(id);
        }

        private Robo buscaRoboPorNome(string id)
        {
            return robos.Find(x => x.Nome == id);
        }
    }
}