using Granito.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiRetornoTaxaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxasJurosController : ControllerBase
    {
        private readonly ITaxasService _taxasService;

        public TaxasJurosController(ITaxasService taxasService)
        {
            _taxasService = taxasService;
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ActionName(nameof(TaxaDeJuros))]
        [HttpGet()]
        public IActionResult TaxaDeJuros()
        {
            try
            {
                var taxa = _taxasService.RetornaTaxaDeJuros();
                return Ok(taxa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
    }


}
