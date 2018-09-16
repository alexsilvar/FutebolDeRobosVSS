using FutebolDeRobosVSS.interfaces.atuadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutebolDeRobosVSS.interfaces.ambiente;
using FutebolDeRobosVSS.interfaces.dados;
using System.IO.Ports;
using System.Threading;

namespace FutebolDeRobosVSS.implementacoes.atuadores
{
    class Expedidor : IExpedidor
    {
        private IAmbienteExpedidor ambiente;


        public Expedidor(Ambiente ambiente)
        {
            this.ambiente = ambiente;
        }

        /// <summary>
        /// Atribui uma porta ao robô em questão e a abre
        /// </summary>
        /// <param name="nome">nome identificador do robô</param>
        /// <param name="porta">Nome da porta COM</param>
        public void definirPortaRobo(string nome, string porta)
        {
            try
            {
                ambiente.definirPorta(nome, porta);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Alterna a conexão (Liga/Desliga)
        /// </summary>
        /// <param name="nome">Nome identificador do robô</param>
        public void conectarPortaRobo(string nome)
        {
            try
            {
                IRoboExpedidor robo = ambiente.getRobo(nome);//Encontra robo pelo nome
                if (robo == null)
                { throw new Exception("Robo com nome não encontrado"); }
                else
                {
                    if (robo.Porta != null && !robo.Porta.IsOpen)
                    {
                        robo.Porta.Open();
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
        }

        /// <summary>
        /// Envia mensagens para os robôs já identificados e conectados
        /// </summary>
        public void despacharAmbiente()
        {
            foreach (IRoboExpedidor robo in ambiente.ListaRobos)
            {
                conectarPortaRobo(robo.Nome);
                if (robo.Porta != null && robo.Porta.IsOpen)
                {
                    try
                    {
                        string mensagemProtocolada = protocolar(robo.RodaEsquerda, robo.RodaDireita);
                        robo.Porta.Write(mensagemProtocolada);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private string protocolar(int rodaEsquerda, int rodaDireita)
        {
            //Utiliza o sinal para determinar se é para frente ou para trás
            string dirE, dirD;
            if (rodaDireita > 0) { dirD = "F"; if (rodaDireita > 255) { rodaDireita = 255; } }
            else { dirD = "T"; if (rodaDireita < -255) { rodaDireita = -255; } }


            if (rodaEsquerda > 0) { dirE = "F"; if (rodaEsquerda > 255) { rodaEsquerda = 255; } }
            else { dirE = "T"; if (rodaEsquerda < -255) { rodaEsquerda = -255; } }

            return Math.Abs(rodaEsquerda).ToString().PadLeft(3, '0') + dirE +
                   Math.Abs(rodaDireita).ToString().PadLeft(3, '0') + dirD;
        }

        public void desconectarPortaRobo(string nome)
        {
            IRoboExpedidor robo = ambiente.getRobo(nome);
            if (robo != null)
            {
                if (robo.Porta != null && robo.Porta.IsOpen)
                {
                    robo.Porta.Close();
                }
            }
        }


    }
}
