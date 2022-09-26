using Granito.Domain.Configurations;
using Granito.Domain.DTOs;
using Granito.Domain.Interfaces.Services;
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

        public TaxasService(TaxasConfigOptions taxasConfigOptions)
        {
            _taxasConfigOptions = taxasConfigOptions;
        }

        public TaxasDTO RetornaTaxaDeJuros()
        {
            return new TaxasDTO(_taxasConfigOptions.Valor);
        }
    }
}
