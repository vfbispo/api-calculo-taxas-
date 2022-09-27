using Granito.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.DTOs
{
    public class TaxasDTO
    {
        public decimal Valor { get; set; }

        public TaxasDTO(TaxasConfigOptions taxasConfigOptions)
        {
            Valor = taxasConfigOptions.Valor;
        }
    }
}
