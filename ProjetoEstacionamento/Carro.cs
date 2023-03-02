using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEstacionamento
{
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Carro()
        {
            Tickets = new List<Ticket>();
        }

        


        public string ResumoCarro()
        {
           return  $" Carro: {Marca} {Modelo} | Cor: {Cor} | Placa: {Placa}";
        }
    }

}