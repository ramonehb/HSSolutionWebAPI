using HSSolution.Domain;

namespace HSSolution.Persistence.Interfaces;

public interface IUsuarioPersist
{
    Task<Usuario[]> GetUsuariosAsync();

    Task<Usuario?> GetUsuarioByIdAsync(int idUsuario);

    Task<bool> ExistsProfile(int idPerfil);

    Task<string> ValidaLoginEmail(string login, string email);
}

