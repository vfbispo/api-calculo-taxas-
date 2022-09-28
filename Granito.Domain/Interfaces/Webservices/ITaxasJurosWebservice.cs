using Granito.Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.Interfaces.Webservices
{
    public interface ITaxasJurosWebservice
    {
        Task<TaxaJurosResponse> BuscaTaxaDeJuros();
    }
}
