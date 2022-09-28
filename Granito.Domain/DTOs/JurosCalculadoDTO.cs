using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granito.Domain.DTOs
{
    public class JurosCalculadoDTO
    {
        public string ValorFinal { get; set; }

        public JurosCalculadoDTO(decimal valorFinal)
        {
            ValorFinal = valorFinal.ToString("N2");
        }

    }
}
