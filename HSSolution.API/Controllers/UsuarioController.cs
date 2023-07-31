using AutoMapper;
using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HSSolution.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMapper _mapper;

    private readonly IUsuarioApplication _usuarioApplication;

    public UsuarioController(IUsuarioApplication usuarioApplication, IMapper mapper)
    {
        _usuarioApplication = usuarioApplication;
        _mapper = mapper;

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
    /// /// <response code="500"></response>
    [HttpGet("id")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetUsuarioById(int idUsuario)
    {
        try
        {
            try
            {
                var usuario = await _usuarioApplication.GetUsuarioByIdAsync(idUsuario);
                if (usuario is null) return NoContent();

                var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);
                return Ok(usuarioViewModel);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar Usuário por Id.\nErro: {e.Message}");
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário por id.\nErro: {ex.Message}");
        }
    }

}

