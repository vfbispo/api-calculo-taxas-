using Granito.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.Interfaces.Services
{
    public interface ICalculaJurosService
    {
        Task CalculaJuros(decimal valorInicial, int quantidadeMeses);

        Task<RepositorioGithubDTO> RetornaUrlRepositorioGithub();
    }
}
