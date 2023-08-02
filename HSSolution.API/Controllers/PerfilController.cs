using HSSolution.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HSSolution.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin, User")]
[Route("api/perfil")]
public class PerfilController : ControllerBase
{
    private readonly IPerfilApplitcation _perfilApplication;

    public PerfilController(IPerfilApplitcation perfilApplication)
    {
        _perfilApplication = perfilApplication;   
    }

    /// <summary>
    /// Obter todos os dados de perfils
    /// </summary>
    /// <returns>Dados do perfil</returns>
    /// <response code="200"></response>
    /// <response code="204"></response>
    /// <response code="500"></response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllPerfils()
    {
        try
        {
            var perfils = await _perfilApplication.GetPerfilsAsync();
            if (perfils is null) return NoContent();

            return Ok(perfils);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar todos os perfis.\nErro: {ex.Message}");
        }
    }
}

