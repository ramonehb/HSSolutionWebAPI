using HSSolution.Domain;

namespace HSSolution.Persistence.Interfaces;

public interface IUsuarioPersist
{
    Task<Usuario[]> GetUsuariosAsync();

    Task<Usuario?> GetUsuarioByIdAsync(int idUsuario);

    Usuario? GetUsuarioByUserName(string username, string password);
}

