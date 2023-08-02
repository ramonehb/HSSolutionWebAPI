using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HSSolution.API.Controllers;

[ApiController]
[Route("api/token")]
public class TokenController : ControllerBase
{
    private readonly IAutenticacaoApplication _autenticacaoApplication;
    private readonly IConfiguration _configuration;

    public TokenController(IAutenticacaoApplication autenticacaoApplication, IConfiguration configuration)
    {
        _autenticacaoApplication = autenticacaoApplication;
        _configuration = configuration;
    }

    /// <summary>
    /// Token
    /// </summary>
    /// <returns>Dados de autenticação</returns>
    /// <response code="200"></response>
    /// <response code="404"></response>
    /// <response code="500"></response>
    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Autenticacao(AutenticacaoInputModel autenticacaoInputModel)
    {
        try
        {
            var usuario = await _autenticacaoApplication.AutenticacaoUsuario(autenticacaoInputModel);

            if (usuario == null) return NotFound("Usuário não encontrado");

            var token = CriarToken(autenticacaoInputModel.Username);

            return Ok(token);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao autenticar.\nErro: {ex.Message}");
        }
    }

    private string CriarToken(string userName)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, "Admin"),
            new Claim(ClaimTypes.Role, "User")
        };

        var secretKey = _configuration.GetSection("AppSettings:Token").Value!;
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
