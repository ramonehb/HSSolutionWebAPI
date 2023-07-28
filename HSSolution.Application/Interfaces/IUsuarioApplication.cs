using HSSolution.Domain;

namespace HSSolution.Application.Interfaces;

public interface IUsuarioApplication
{
    Task<Usuario?> AddUsuario(Usuario inputModelUsuario);

    Task<Usuario?> UpdateUsuario(int idUsuario, Usuario inputModelUsuario);

    Task<bool> DeleteUsuario(int idUsuario);

    Task<Usuario[]?> GetUsuariosAsync();

    Task<Usuario?> GetUsuarioByIdAsync(int idUsuario);
}

