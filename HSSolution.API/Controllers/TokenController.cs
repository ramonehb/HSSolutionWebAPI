using HSSolution.API.Models;
using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HSSolution.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenController : ControllerBase
{
    private readonly IAutenticacaoApplication _autenticacaoApplication;

    public TokenController(IAutenticacaoApplication autenticacaoApplication)
    {
            _autenticacaoApplication = autenticacaoApplication;
    }

    /// <summary>
    /// Token
    /// </summary>
    /// <returns>Dados de autenticação</returns>
    /// <response code="200"></response>
    /// <response code="204"></response>
    /// <response code="500"></response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Autenticacao(AutenticacaoInputModel autenticacaoInputModel)
    {
        try
        {
            return Ok(_autenticacaoApplication.AutenticacaoUsuario(autenticacaoInputModel));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao autenticar.\nErro: {ex.Message}");
        }
    }
}
