using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using HSSolution.Persistence.Interfaces;

namespace HSSolution.Application;

public class AutenticacaoApplication : IAutenticacaoApplication
{
    private readonly IAutenticacaoPersist _autenticacaoPersist;

    public AutenticacaoApplication(IAutenticacaoPersist autenticacaoPersist)
    {
        _autenticacaoPersist = autenticacaoPersist;
    }

    public async Task<bool?> AutenticacaoUsuario(AutenticacaoInputModel autenticacaoInputModel)
    {
        try
        {
            var usuario = await _autenticacaoPersist.AutenticaUsuario(autenticacaoInputModel.Username, autenticacaoInputModel.Password);
            if (usuario == null) return null;

            return usuario is not null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }
}

