using HSSolution.Application.Dtos;

namespace HSSolution.Application.Interfaces;

public interface IUsuarioApplication
{
    Task<UsuarioViewModel?> AddUsuario(UsuarioInputModel inputModelUsuario);

    Task<UsuarioViewModel?> UpdateUsuario(int idUsuario, UsuarioInputModel inputModelUsuario);

    Task<bool> DeleteUsuario(int idUsuario);

    Task<List<UsuarioViewModel>?> GetUsuariosAsync();

    Task<UsuarioViewModel?> GetUsuarioByIdAsync(int idUsuario);
}

