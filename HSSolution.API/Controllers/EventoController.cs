using Microsoft.AspNetCore.Mvc;

namespace HSSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        /// <summary>
        /// Obter todos os eventos
        /// </summary>
        /// <returns>Dados do evento</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        /// <summary>
        /// Obter evento por id
        /// </summary>
        /// <param name="id">Identificador do evento</param>
        /// <returns>Dados do evento</returns>
        /// <response code="200"></response>
        /// <response code="404"></response>
        [HttpGet("id")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetBy()
        {
            return Ok();
        }
    }
}
