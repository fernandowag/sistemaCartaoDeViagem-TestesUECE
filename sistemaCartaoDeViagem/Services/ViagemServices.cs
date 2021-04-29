using sistemaCartaoDeViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCartaoDeViagem.Services
{
    public class ViagemServices
    {
 
    




        public Estacao criarEstacao()
        {
            return new Estacao()
            {
                Id = 1,
                Nome = "Estacao da Parangaba"
 
            };
        }

    }
}
