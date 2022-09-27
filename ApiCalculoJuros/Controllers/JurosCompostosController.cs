using Granito.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCalculoJuros.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class JurosCompostosController : Controller
    {
        private readonly IJurosCompostosService _jurosCompostosService;

        public JurosCompostosController(IJurosCompostosService jurosCompostosService)
        {
            _jurosCompostosService = jurosCompostosService;
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ActionName(nameof(CalculaJuros))]
        [HttpGet("calculajuros")]
        public async Task<IActionResult> CalculaJuros([FromQuery] decimal valorInicial, int meses)
        {
            try
            {
                var jurosCompostos = await _jurosCompostosService.CalculaJuros(valorInicial, meses);
                return Ok(jurosCompostos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }

        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ActionName(nameof(BuscaUrlRepositorio))]
        [HttpGet("showmethecode")]
        public IActionResult BuscaUrlRepositorio()
        {
            try
            {
                var repositorio = _jurosCompostosService.RetornaUrlRepositorioGithub();
                return Ok(repositorio);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); ;
            }
        }
    }
}
