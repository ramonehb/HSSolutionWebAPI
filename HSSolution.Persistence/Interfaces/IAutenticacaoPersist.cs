using HSSolution.Domain;

namespace HSSolution.Persistence.Interfaces;

public interface IAutenticacaoPersist
{
    Task<Usuario?> AutenticaUsuario(string userName, string password);
}

