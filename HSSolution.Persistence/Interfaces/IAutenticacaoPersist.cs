namespace HSSolution.Persistence.Interfaces;

public interface IAutenticacaoPersist
{
    bool AutenticaUsuario(string userName, string password);
}

