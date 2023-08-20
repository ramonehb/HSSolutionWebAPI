using AutoMapper;
using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using HSSolution.Persistence.Interfaces;

namespace HSSolution.Application;

public class TokenApplication : ITokenApplication
{
    private readonly ITokenPersist _tokenPersist;
    private readonly IMapper _mapper;

    public TokenApplication(ITokenPersist tokenPersist, IMapper mapper)
    {
        _tokenPersist = tokenPersist;
        _mapper = mapper;
    }

    public async Task<(UsuarioViewModel?, string, int)> AutenticacaoUsuario(TokenInputModel tokenInputModel)
    {
        try
        {
            (Usuario? usuario, string mensagem, int statusCode) = await _tokenPersist.AutenticaUsuario(tokenInputModel.Username, tokenInputModel.PasswordCriptografada);

            if (usuario == null) return (null, mensagem, statusCode);

            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            return (usuarioViewModel, mensagem, statusCode);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

