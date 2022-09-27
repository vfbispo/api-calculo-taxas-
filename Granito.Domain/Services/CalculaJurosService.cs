using Granito.Domain.Configurations;
using Granito.Domain.DTOs;
using Granito.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {

        public Task CalculaJuros(decimal valorInicial, int quantidadeMeses)
        {
            throw new NotImplementedException();
        }

        public Task<RepositorioGithubDTO> RetornaUrlRepositorioGithub()
        {
            throw new NotImplementedException();
        }
    }
}
