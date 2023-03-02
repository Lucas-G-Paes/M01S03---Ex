using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEstacionamento
{
    public class Ticket
    {
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public bool Ativo { get; set; }


        public Ticket()
        {
            Entrada = DateTime.Now;
            Ativo = true;
        }
        public double TempoEstacionado()
        {
            var tempo = Saida - Entrada;
            return tempo.TotalMinutes;
        }
        public double ValorPagar()
        {
            return TempoEstacionado() * 0.09; 
        }

        public void FecharTicket(){ 
            Saida = DateTime.Now;
            Ativo = false;
            Console.WriteLine($"O carro ficou {TempoEstacionado()} Minutos estacionado.");
            Console.WriteLine($"O valor a pagar será de R$ {ValorPagar()}.");
        }

    }
}