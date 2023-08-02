using AutoMapper;
using HSSolution.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HSSolution.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin, User")]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioApplication _usuarioApplication;

    public UsuarioController(IUsuarioApplication usuarioApplication, IMapper mapper)
    {
        _usuarioApplication = usuarioApplication;
    }

    /// <summary>
    /// Obter todos os usuários
    /// </summary>
    /// <returns>Dados dos usuário</returns>
    /// <response code="200"></response>
    /// <response code="204"></response>
    /// <response code="500"></response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllUsuarios()
    {
        try
        {
            var usuarios = await _usuarioApplication.GetUsuariosAsync();
            if (usuarios is null) return NoContent();

            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar todos os usuários.\nErro: {ex.Message}");
        }
    }

    /// <summary>
    /// Obter usuário por id
    /// </summary>
    /// <param name="idUsuario">Identificador do usuário</param>
    /// <returns>Dados do usuário</returns>
    /// <response code="200"></response>
    /// <response code="204"></response>
    /// /// <response code="400"></response>
    /// /// <response code="500"></response>
    [HttpGet("id")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetUsuarioById(int idUsuario)
    {
        try
        {
            if (idUsuario == 0) return BadRequest("Informe o id do usuário para buscar.");

            var usuario = await _usuarioApplication.GetUsuarioByIdAsync(idUsuario);
            if (usuario is null) return NoContent();

            return Ok(usuario);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário por Id.\nErro: {e.Message}");
        }   
    }
}

