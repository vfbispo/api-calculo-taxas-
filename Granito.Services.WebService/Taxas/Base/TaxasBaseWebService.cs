using Granito.Domain.Configurations.ApiCalculoJuros;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Services.WebService.Taxas.Base
{
    public class TaxasBaseWebService
    {
        protected readonly string _urlBase;

        public TaxasBaseWebService(IOptions<APIsConfigOptions> options)
        {
            _urlBase = options.Value.Taxas.UrlBase;
        }

        protected static object GetHeaders() => new
        {
            Accept = "application/json"
        };
    }
}
