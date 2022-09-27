using Flurl.Http;
using Granito.Domain.Configurations.ApiCalculoJuros;
using Granito.Domain.DTOs.Response;
using Granito.Domain.Interfaces.Webservices;
using Granito.Services.WebService.Taxas.Base;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Services.WebService.Taxas
{
    public class TaxasJurosWebservice : TaxasBaseWebService, ITaxasJurosWebservice
    {
        public TaxasJurosWebservice(IOptions<APIsConfigOptions> options) 
            : base(options)
        {
        }

        public async Task<TaxaJurosResponse> BuscaTaxaDeJuros()
        {
            var headers = GetHeaders();

            var response = await _urlBase
               .AllowAnyHttpStatus()
               .WithHeaders(headers)
               .AppendPathSegments("taxasjuros")
               .GetAsync();

            return response.ResponseMessage.IsSuccessStatusCode ? await response.GetJsonAsync<TaxaJurosResponse>() : null;
        }
    }
}
