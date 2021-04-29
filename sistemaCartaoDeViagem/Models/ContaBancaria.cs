using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCartaoDeViagem.Models
{
    public class ContaBancaria
    {
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public double Saldo { get; set; }
        public Banco Banco { get; set; }
        public Cliente Cliente { get; set; }
        public ContaBancaria()
        {
            Agencia = 1;
            Conta = 123;
            Banco = new Banco();
            Saldo = 2000;
        }
    }
}
