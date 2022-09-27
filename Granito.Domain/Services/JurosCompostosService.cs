using Granito.Domain.Configurations.ApiCalculoJuros;
using Granito.Domain.DTOs;
using Granito.Domain.Interfaces.Services;
using Granito.Domain.Interfaces.Webservices;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.Services
{
    public class JurosCompostosService : IJurosCompostosService
    {
        private readonly GithubConfigOptions _githubConfigOptions;
        private readonly ITaxasJurosWebservice _taxasJurosWebservice;

        public JurosCompostosService(IOptions<GithubConfigOptions> githubConfigOptions,
                                     ITaxasJurosWebservice taxasJurosWebservice)
        {
            _githubConfigOptions = githubConfigOptions.Value;
            _taxasJurosWebservice = taxasJurosWebservice;
        }

        public async Task<JurosCalculadoDTO> CalculaJuros(decimal valorInicial, int quantidadeMeses)
        {
            decimal valorfinal = valorInicial;

            var taxaJuros = await _taxasJurosWebservice.BuscaTaxaDeJuros();

            for (int i = 0; i < quantidadeMeses; i++)
            {
                valorfinal += Math.Truncate(100 *(valorfinal * taxaJuros.Valor ) + valorfinal * taxaJuros.Valor * taxaJuros.Valor) / 100;
            }

            return new JurosCalculadoDTO(valorfinal);
        }

        public RepositorioGithubDTO RetornaUrlRepositorioGithub()
        {
            return new RepositorioGithubDTO(_githubConfigOptions.Repositorio);
        }
    }
}
