using Granito.Domain.Configurations.ApiCalculoJuros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.DTOs
{
    public class RepositorioGithubDTO
    {
        public string Url { get; set; }

        public RepositorioGithubDTO(GithubRepositorioConfigOptions githubRepositorioConfigOptions)
        {
            Url = githubRepositorioConfigOptions.Url;
        }
    }

}
