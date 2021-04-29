using CartaoViagem.Models;
using sistemaCartaoDeViagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistemaCartaoDeViagem.Services
{
    public class Services
    {
        public void telaInicial(Cartao cartao)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"====================================");
            Console.WriteLine($"Pressione Enter para passar o Cartão");
            Console.WriteLine($"====================================");
            Console.ReadLine();
            Console.Clear();
            IniciarServico(cartao);
        }


        public void IniciarServico(Cartao cartao)
        {
            if (ChecarSePassageiroEstaDentroDaEstacao(cartao))
            {
                Console.WriteLine("Você está saindo da estação.");
                Console.WriteLine("Obrigado por viajar conosco. Até logo!");
                cartao.DentroDaEstacao = false;
            }
            else
            {
                Console.WriteLine($"Bem-Vindo à estação da Parangaba, {cartao.Cliente.Nome}");
                if (!ChecarSeHaBilheteAtivo(cartao))
                {
                    Console.WriteLine($"Não há bilhetes ativos para o seu cartão");
                    Console.WriteLine($"Gostaria de comprar um bilhete? (s/n)");
                    if (Console.ReadLine() == "s")
                    {
                        ComprarPassagem(cartao);
                    }
                    else
                    {
                        Console.WriteLine($"Finalizando a operação...");
                    }

                }
                else
                {
                    Console.WriteLine($"Seu bilhete {cartao.Bilhete} é válido até {cartao.DataValidadeBilhete}");
                    Console.WriteLine($"Entrada Autorizada.");
                    cartao.DentroDaEstacao = true;
                }

            }
            telaInicial(cartao);
        }
        public bool ValidaZona(string zona)
        {
            return zona == "a" || zona == "b" ? true : false;
        }

        public bool ValidaBilhete(string bilhete)
        {
            return bilhete == "u" ||
                   bilhete == "d" ||
                   bilhete == "s" ||
                   bilhete == "m" ? true : false;
        }

        public bool ChecarSePassageiroEstaDentroDaEstacao(Cartao cartao)
        {
            return cartao.DentroDaEstacao;
        }
        public bool ChecarSeHaBilheteAtivo(Cartao cartao)
        {
            return cartao.Bilhete != "none" && cartao.DataValidadeBilhete >= DateTime.Now ? true : false;
        }

        public double GetSaldoEmConta(Cartao cartao)
        {
            return cartao.Cliente.ContaBancaria.Saldo;
        }

        public double GetTarifa(string zona, string bilhete)
        {
            if (zona == "a" || zona == "b")
            {
                if (bilhete == "u")
                    return zona == "b" ? 7 : 6;
                if (bilhete == "d")
                    return zona == "b" ? 12 : 10;
                if (bilhete == "s")
                    return zona == "b" ? 45 : 30;
                if (bilhete == "m")
                    return zona == "b" ? 170 : 130;
            }

            return 0;
        }

        public double DebitarValorDaConta(Cartao cartao, double tarifa)
        {
            cartao.Cliente.ContaBancaria.Saldo -= tarifa;
            return cartao.Cliente.ContaBancaria.Saldo;
        }

        public Bilhete AtribuirBilhete(Cartao cartao, string bilhete)
        {
            Bilhete result = new Bilhete();
            if (bilhete == "u")
            {
                result.Descricao = "unico";
                result.Validade = DateTime.Now;
            }
            if (bilhete == "d")
            {
                result.Descricao = "dia";
                result.Validade = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            }
            if (bilhete == "s")
            {
                result.Descricao = "semana";
                result.Validade = DateTime.Now.Date.AddDays(8).AddTicks(-1);
            }
            if (bilhete == "m")
            {
                result.Descricao = "mes";
                result.Validade = DateTime.Now.Date.AddDays(31).AddTicks(-1);
            }

            cartao.Bilhete = result.Descricao;
            cartao.DataValidadeBilhete = result.Validade;

            return result;


        }

        public Object ComprarPassagem(Cartao cartao)
        {
            bool compraRealizada = false;
            string bilheteComprado =  "";
            object result;
            Console.WriteLine($"Gostaria de comprar a passagem para a Zona A ou Zona B?(a/b)");
            string zona = Console.ReadLine();
            if (ValidaZona(zona))
            {
                Console.WriteLine($"Gostaria de comprar qual bilhete?");
                Console.WriteLine($"u - unico");
                Console.WriteLine($"d - dia");
                Console.WriteLine($"s - semana");
                Console.WriteLine($"m - mes");
                string bilhete = Console.ReadLine();
                if (ValidaBilhete(bilhete))
                {
                    var tarifa = GetTarifa(zona, bilhete);
                    Console.WriteLine($"A tarifa para este bilhete custa R${tarifa} ");
                    Console.WriteLine($"Checando o saldo da sua conta bancária... ");
                    var saldo = GetSaldoEmConta(cartao);
                    Console.WriteLine($"Seu saldo em conta é R${saldo}");
                    if (saldo < tarifa)
                    {
                        Console.WriteLine($"Infelizmente sua conta bancária não tem sado para compra do bilhete.");
                    }
                    else
                    {
                        var novoSaldo = DebitarValorDaConta(cartao, tarifa);
                        var bilheteAtribuido = AtribuirBilhete(cartao, bilhete);
                        Console.WriteLine($"Compra realizda com sucesso");
                        Console.WriteLine($"Você comprou o bilhete \"{bilheteAtribuido.Descricao}\", válido até {bilheteAtribuido.Validade}");
                        Console.WriteLine($"Seu novo saldo é R${novoSaldo}");
                        compraRealizada = true;
                        bilheteComprado = bilheteAtribuido.Descricao;
                    }

                    Console.WriteLine($"Operação finalizada.");
                    cartao.DentroDaEstacao = true;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Bilhete Inválido");
                    ComprarPassagem(cartao);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Zona Inválida");
                ComprarPassagem(cartao);
            }
            
            result = new
            {
                compraRealizada = compraRealizada,
                bilheteComprado = bilheteComprado

            };

            return result;
        }
         
    }
}
