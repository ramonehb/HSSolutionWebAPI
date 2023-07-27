using HSSolution.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HSSolution.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private static List<Usuario> usuarios = new List<Usuario>
    {
        new Usuario(1, 1, "Humberto Ramone", "486.678.378-81", "humberto.ramone@hssolution.com.br", "humberto.ramone", "12345"),
        new Usuario(2, 1, "Samuel Carvalho", "458.278.658-20", "samuel.carvalho@hssolution.com.br", "samuel", "12345"),
        new Usuario(3, 2, "Joyce Braz", "458.278.658-20", "joyce@hssolution.com.br", "joyce", "12345")
    };


    /// <summary>
    /// Obter todos os usuários
    /// </summary>
    /// <returns>Dados do evento</returns>
    /// <response code="200"></response>
    /// <response code="404"></response>
    /// <response code="500"></response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllUsuarios()
    {
        try
        {
            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário por id.\nErro: {ex.Message}");
        }
    }

    /// <summary>
    /// Obter usuário por id
    /// </summary>
    /// <param name="idUsuario">Identificador do usuário</param>
    /// <returns>Dados do usuário</returns>
    /// <response code="200"></response>
    /// <response code="404"></response>
    /// /// <response code="500"></response>
    [HttpGet("id")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetUsuarioById(int idUsuario)
    {
        try
        {
            var usuario = usuarios.Find(u => u.ID_Usuario == idUsuario);

            if (usuario is null)
                return NotFound("Usuário não encontrado");

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário por id.\nErro: {ex.Message}");
        }
    }
}

