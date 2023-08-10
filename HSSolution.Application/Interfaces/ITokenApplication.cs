using HSSolution.Application.Dtos;

namespace HSSolution.Application.Interfaces;

public interface ITokenApplication
{
    Task<(UsuarioViewModel?, string, int)> AutenticacaoUsuario(AutenticacaoInputModel autenticacaoInputModel);
}

