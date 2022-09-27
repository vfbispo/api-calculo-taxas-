using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.Configurations.ApiCalculoJuros
{
    public class GithubConfigOptions
    {
        public GithubRepositorioConfigOptions Repositorio { get; set; }
    }

    public class GithubRepositorioConfigOptions
    {
        public string Url { get; set; }
    }
}
