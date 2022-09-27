using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.DTOs
{
    public class JurosCalculadoDTO
    {
        public decimal ValorFinal { get; set; }

        public JurosCalculadoDTO(decimal valorFinal)
        {
            ValorFinal = valorFinal;
        }

    }
}
