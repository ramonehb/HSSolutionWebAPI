using HSSolution.Domain;

namespace HSSolution.Persistence.Interfaces;

public interface IAutenticacaoPersist
{
    Task<(Usuario?, string)> AutenticaUsuario(string userName, string password);
}

