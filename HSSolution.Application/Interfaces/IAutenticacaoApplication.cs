using HSSolution.Application.Dtos;

namespace HSSolution.Application.Interfaces;

public interface IAutenticacaoApplication
{
    Task<bool?> AutenticacaoUsuario(AutenticacaoInputModel autenticacaoInputModel);
}

