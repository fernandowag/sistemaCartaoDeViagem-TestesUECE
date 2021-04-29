using sistemaCartaoDeViagem.Models;
using sistemaCartaoDeViagem.Services;
using System; 
using Xunit;

namespace CartaoViagemTest
{
    public class ServicesTest
    {

        Services services = new Services();
        Cartao cartao = new Cartao();

        [Theory]  
        [InlineData("a")]
        [InlineData("b")]
        public void DadoValidaZonaProcess_DeveRetornarTrue_QuandoAZonaForValida(string zona)
        {
            //arrange

            //act

            bool result = services.ValidaZona(zona);

            //assert
            Assert.True(result);

        }

        [Theory]
        [InlineData("")]
        [InlineData("x")]
        public void DadoValidaZonaProcess_DeveRetornarFalse_QuandoAZonaForInvalida(string zona)
        {
            //arrange

            //act

            bool result = services.ValidaZona(zona);

            //assert
            Assert.False(result);

        }

        [Theory]
        [InlineData("u")]
        [InlineData("d")]
        [InlineData("s")]
        [InlineData("m")]
        public void DadoValidaBilheteProcess_DeveRetornarTrue_QuandoOBilheteForValido(string bilhete)
        {
            //arrange

            //act

            bool result = services.ValidaBilhete(bilhete);

            //assert
            Assert.True(result);

        }

        [Theory]
        [InlineData("")]
        [InlineData("x")]
        public void DadoValidaBilheteProcess_DeveRetornarFalse_QuandoOBilheteForInvalido(string zona)
        {
            //arrange

            //act

            bool result = services.ValidaBilhete(zona);

            //assert
            Assert.False(result);

        }

        [Fact]
        public void DadoChecarSeHaBilheteAtivoProcess_DeveRetornarTrue_QuandoHouverBilheteAtivoNoCartao()
        {
            //arrange

            cartao.DataValidadeBilhete = DateTime.Now.Date.AddDays(1).AddTicks(-1);
            cartao.Bilhete = "dia";
            //act

            bool result = services.ChecarSeHaBilheteAtivo(cartao);

            //assert

            Assert.True(result);
        }

        [Fact]
        public void DadoChecarSeHaBilheteAtivoProcess_DeveRetornarFalse_QuandoNaoHouverBilheteAtivoNoCartao()
        {
            //arrange

            cartao.DataValidadeBilhete = DateTime.Now.Date.AddDays(-1); 
            cartao.Bilhete = "dia";
            //act

            bool result = services.ChecarSeHaBilheteAtivo(cartao);

            //assert

            Assert.False(result);
        }


        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaABilheteU()
        {
            //arrange

            var zona = "a";
            var bilhete = "u";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(6, result);
        }

        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaABilheteD()
        {
            //arrange

            var zona = "a";
            var bilhete = "d";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(10, result);
        }

        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaABilheteS()
        {
            //arrange

            var zona = "a";
            var bilhete = "s";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(30, result);
        }

        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaABilheteM()
        {
            //arrange

            var zona = "a";
            var bilhete = "m";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(130, result);
        }

        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaBBilheteU()
        {
            //arrange

            var zona = "b";
            var bilhete = "u";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(7, result);
        }

        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaBBilheteD()
        {
            //arrange

            var zona = "b";
            var bilhete = "d";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(12, result);
        }

        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaBBilheteS()
        {
            //arrange

            var zona = "b";
            var bilhete = "s";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(45, result);
        }

        [Fact]
        public void DadoGetTarifaProcess_DeveRetornarOValorDaTarifa_QuandoOBilheteForZonaBBilheteM()
        {
            //arrange

            var zona = "b";
            var bilhete = "m";

            //act

            double result = services.GetTarifa(zona, bilhete);

            //assert

            Assert.Equal(170, result);
        }

        [Fact]
        public void DadoDebitarValorDaContaProcess_DeveRetornarOValorDaContaSubtraindoOValorDaTarifa()
        {
            //arrange

            cartao.Cliente.ContaBancaria.Saldo = 100;
            double tarifa = 7;

            //act

            double result = services.DebitarValorDaConta(cartao, tarifa);

            //assert

            Assert.Equal(93, result);
        }

        [Fact]
        public void DadoAtribuirBilheteProcess_DeveAtualizarOBilheteDataDeValidadeDoBilheteNoCartao_QuandoOBilheteForDia()
        {
            //arrange

            string bilhete = "d"; 

            //act

            services.AtribuirBilhete(cartao, bilhete);

            //assert

            Assert.Equal("dia", cartao.Bilhete);
            Assert.Equal(DateTime.Now.Date.AddDays(1).AddTicks(-1), cartao.DataValidadeBilhete);
        }

        [Fact]
        public void DadoAtribuirBilheteProcess_DeveAtualizarOBilheteDataDeValidadeDoBilheteNoCartao_QuandoOBilheteForSemana()
        {
            //arrange

            string bilhete = "s";

            //act

            services.AtribuirBilhete(cartao, bilhete);

            //assert

            Assert.Equal("semana", cartao.Bilhete);
            Assert.Equal(DateTime.Now.Date.AddDays(8).AddTicks(-1), cartao.DataValidadeBilhete);
        }

        [Fact]
        public void DadoAtribuirBilheteProcess_DeveAtualizarOBilheteDataDeValidadeDoBilheteNoCartao_QuandoOBilheteForMes()
        {
            //arrange

            string bilhete = "m";

            //act

            services.AtribuirBilhete(cartao, bilhete);

            //assert

            Assert.Equal("mes", cartao.Bilhete);
            Assert.Equal(DateTime.Now.Date.AddDays(31).AddTicks(-1), cartao.DataValidadeBilhete);
        }


    }
}
