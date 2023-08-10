using HSSolution.Domain;

namespace HSSolution.Persistence.Interfaces;

public interface ITokenPersist
{
    Task<(Usuario?, string, int)> AutenticaUsuario(string userName, string password);
}

