using sistemaCartaoDeViagem.Models;
using sistemaCartaoDeViagem.Services;
using System;
using System.Collections.Generic;

namespace CartaoViagem
{
    class Program
    {
        static void Main(string[] args)
        {
            Services services = new Services();
            var cartao = new Cartao();

            services.telaInicial(cartao);       
            

        }
    }
}
