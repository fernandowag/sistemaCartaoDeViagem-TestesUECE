using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCartaoDeViagem.Models
{
    public class Viagem
    {
        public int Id { get; set; }
        public Cartao Cartao { get; set; }
        public DateTime Data { get; set; }

    }
}
