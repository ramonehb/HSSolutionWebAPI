using HSSolution.Application.Dtos;
using HSSolution.Domain;

namespace HSSolution.Application.Interfaces;

public interface IAutenticacaoApplication
{
    Task<(UsuarioViewModel?, string)> AutenticacaoUsuario(AutenticacaoInputModel autenticacaoInputModel);
}

