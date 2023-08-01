using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using HSSolution.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HSSolution.Application;

public class AutenticacaoApplication : IAutenticacaoApplication
{

    private readonly IGeralPersist _geralPersist;
    private readonly IAutenticacaoPersist _autenticacaoPersist;
    private readonly IUsuarioPersist _usuarioPersist;
    private readonly IConfiguration _configuration;
    public AutenticacaoApplication(IGeralPersist geralPersist, IAutenticacaoPersist autenticacaoPersist, IUsuarioPersist usuarioPersist, IConfiguration configuration)
    {
        _geralPersist = geralPersist;
        _autenticacaoPersist = autenticacaoPersist;
        _usuarioPersist = usuarioPersist;
        _configuration = configuration;
    }

    public JwtSecurityToken? AutenticacaoUsuario(AutenticacaoInputModel inuputModel)
    {
        var autenticado = _autenticacaoPersist.AutenticaUsuario(inuputModel.Username, inuputModel.Password);

        if (autenticado) 
        {
            var usuario = _usuarioPersist.GetUsuarioByUserName(inuputModel.Username, inuputModel.Password);
            //Atualizar o usuario NR_UltimoAcesso

            return CreateToken(usuario);
        }

        return null;
    }

    private JwtSecurityToken CreateToken(Usuario? usuario)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, usuario.Login)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        return token;
    }
}

