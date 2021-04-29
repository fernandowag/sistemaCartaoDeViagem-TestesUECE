using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCartaoDeViagem.Models
{
    public class Cartao
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Cartao()
        {
            Id = 123456;
            Cliente = new Cliente();
        }
    }
}
