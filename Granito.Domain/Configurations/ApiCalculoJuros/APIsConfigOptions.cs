using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.Configurations.ApiCalculoJuros
{
    public class APIsConfigOptions
    {
        public APIsTaxasOptions Taxas { get; set; }
    }

    public class APIsTaxasOptions
    {
        public string UrlBase { get; set; }
    }
}
