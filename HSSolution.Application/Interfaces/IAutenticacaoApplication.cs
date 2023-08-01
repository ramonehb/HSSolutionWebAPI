using HSSolution.Application.Dtos;
using System.IdentityModel.Tokens.Jwt;

namespace HSSolution.Application.Interfaces;

public interface IAutenticacaoApplication
{
    JwtSecurityToken? AutenticacaoUsuario(AutenticacaoInputModel inuputModel);
}

