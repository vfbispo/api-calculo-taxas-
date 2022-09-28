using Granito.Domain.Configurations.ApiCalculoJuros;
using Granito.Domain.DTOs.Response;
using Granito.Domain.Interfaces.Services;
using Granito.Domain.Interfaces.Webservices;
using Granito.Domain.Services;
using Granito.Services.WebService.Taxas;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Granito.Tests
{
    public class UnitTest1
    {
        public readonly Mock<ITaxasJurosWebservice> _taxasJurosWebservice;
        public readonly Mock<IOptions<APIsConfigOptions>> _optionsAPIsConfigOptions;
        public readonly Mock<IOptions<GithubConfigOptions>> _githubConfigOptions;
        public readonly Mock<IJurosCompostosService> _jurosCompostosService;
        public UnitTest1()
        {
            _taxasJurosWebservice = new Mock<ITaxasJurosWebservice>();
            _optionsAPIsConfigOptions = new Mock<IOptions<APIsConfigOptions>>();
            _jurosCompostosService = new Mock<IJurosCompostosService>();
            _githubConfigOptions = new Mock<IOptions<GithubConfigOptions>>();
        }

        [Fact]
        public async Task ValorTaxaCorreto()
        {
            APIsConfigOptions option = new APIsConfigOptions() { Taxas = new APIsTaxasOptions() { UrlBase = "https://viniciusbispo.azurewebsites.net/" } };

            _optionsAPIsConfigOptions.Setup(x => x.Value).Returns(option);

            TaxasJurosWebservice service = new TaxasJurosWebservice(_optionsAPIsConfigOptions.Object);

            var taxaDeJuros = await service.BuscaTaxaDeJuros();

            Assert.Equal(0.01m, taxaDeJuros.Valor);
        }

        [Fact]
        public async Task ValorTaxaIncorreto()
        {
            APIsConfigOptions option = new APIsConfigOptions() { Taxas = new APIsTaxasOptions() { UrlBase = "https://viniciusbispo.azurewebsites.net/" } };

            _optionsAPIsConfigOptions.Setup(x => x.Value).Returns(option);

            TaxasJurosWebservice service = new TaxasJurosWebservice(_optionsAPIsConfigOptions.Object);

            var taxaDeJuros = await service.BuscaTaxaDeJuros();

            Assert.NotEqual(0.02m, taxaDeJuros.Valor);
        }

        [Fact]
        public async Task ValorRetornoComJurosCompostosCorreto()
        {
            GithubConfigOptions option = new GithubConfigOptions() { Repositorio = new GithubRepositorioConfigOptions() { Url = null } };
            _githubConfigOptions.Setup(x => x.Value).Returns(option);

            TaxaJurosResponse taxaJurosResponse = new TaxaJurosResponse() { Valor = 0.01m };

            _taxasJurosWebservice.Setup(x => x.BuscaTaxaDeJuros()).ReturnsAsync(taxaJurosResponse);

            JurosCompostosService service = new JurosCompostosService(_githubConfigOptions.Object, _taxasJurosWebservice.Object);

            var jurosCalculado = await service.CalculaJuros(100, 5);
            Assert.Equal("105,10", jurosCalculado.ValorFinal);
        }

        [Fact]
        public async Task ValorRetornoComJurosCompostosErrado()
        {
            GithubConfigOptions option = new GithubConfigOptions() { Repositorio = new GithubRepositorioConfigOptions() { Url = null } };
            _githubConfigOptions.Setup(x => x.Value).Returns(option);

            TaxaJurosResponse taxaJurosResponse = new TaxaJurosResponse() { Valor = 0.01m };

            _taxasJurosWebservice.Setup(x => x.BuscaTaxaDeJuros()).ReturnsAsync(taxaJurosResponse);

            JurosCompostosService service = new JurosCompostosService(_githubConfigOptions.Object, _taxasJurosWebservice.Object);

            var jurosCalculado = await service.CalculaJuros(100, 5);
            Assert.NotEqual("400,10", jurosCalculado.ValorFinal);
        }
    }
}
