using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCartaoDeViagem.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ContaBancaria ContaBancaria { get; set; }
        public Cartao Cartao { get; set; }
        public Cliente()
        {
            Id = 1;
            ContaBancaria = new ContaBancaria();
            Nome = "Francisco Silva";
        }

    }
}
