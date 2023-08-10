using AutoMapper;
using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using HSSolution.Persistence.Interfaces;

namespace HSSolution.Application;

public class TokenApplication : ITokenApplication
{
    private readonly ITokenPersist _autenticacaoPersist;
    private readonly IMapper _mapper;

    public TokenApplication(ITokenPersist autenticacaoPersist,IMapper mapper)
    {
        _autenticacaoPersist = autenticacaoPersist;
        _mapper = mapper;
    }

    public async Task<(UsuarioViewModel?, string, int)> AutenticacaoUsuario(AutenticacaoInputModel autenticacaoInputModel)
    {
        try
        {
            (Usuario usuario, string mensagem, int statusCode) = await _autenticacaoPersist.AutenticaUsuario(autenticacaoInputModel.Username, autenticacaoInputModel.Password);

            if (usuario == null) return (null, mensagem, statusCode);

            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            return (usuarioViewModel, mensagem, statusCode);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }
}

