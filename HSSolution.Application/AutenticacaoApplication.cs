using AutoMapper;
using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using HSSolution.Persistence.Interfaces;

namespace HSSolution.Application;

public class AutenticacaoApplication : IAutenticacaoApplication
{
    private readonly IAutenticacaoPersist _autenticacaoPersist;
    private readonly IMapper _mapper;

    public AutenticacaoApplication(IAutenticacaoPersist autenticacaoPersist,IMapper mapper)
    {
        _autenticacaoPersist = autenticacaoPersist;
        _mapper = mapper;
    }

    public async Task<(UsuarioViewModel?, string)> AutenticacaoUsuario(AutenticacaoInputModel autenticacaoInputModel)
    {
        try
        {
            (Usuario usuario, string mensagem) = await _autenticacaoPersist.AutenticaUsuario(autenticacaoInputModel.Username, autenticacaoInputModel.Password);

            if (usuario == null) return (null, mensagem);

            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            return (usuarioViewModel, mensagem);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }
}

