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
    public class TaxasService : ITaxasService
    {
        private readonly TaxasConfigOptions _taxasConfigOptions;

        public TaxasService(IOptions<TaxasConfigOptions> taxasConfigOptions)
        {
            _taxasConfigOptions = taxasConfigOptions.Value;
        }

        public TaxasDTO RetornaTaxaDeJuros()
        {
            return new TaxasDTO(_taxasConfigOptions.Valor);
        }
    }
}
