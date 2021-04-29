using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCartaoDeViagem.Models
{
    public class Banco
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<ContaBancaria> contasBancarias { get; set; }
        public Banco()
        {
            Id = 1;
            Descricao = "Banco do Brasil";
        }
    }
}
