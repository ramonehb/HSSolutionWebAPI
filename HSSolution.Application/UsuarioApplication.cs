using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using HSSolution.Persistence.Interfaces;

namespace HSSolution.Application;

public class UsuarioApplication : IUsuarioApplication
{

    private readonly IGeralPersist _geralPersist;
    private readonly IUsuarioPersist _usuarioPersist;

    public UsuarioApplication(IGeralPersist geralPersist, IUsuarioPersist usuarioPersist)
    {
        _geralPersist = geralPersist;
        _usuarioPersist = usuarioPersist;   
    }
    public async Task<Usuario?> GetUsuarioByIdAsync(int idUsuario)
    {
        try
        {
            var usuario = await _usuarioPersist.GetUsuarioByIdAsync(idUsuario);
            if (usuario == null)
                return null;

            return usuario;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }

    public async Task<Usuario[]?> GetUsuariosAsync()
    {
        try
        {
            var usuarios = await _usuarioPersist.GetUsuariosAsync();
            if (usuarios == null)
                return null;

            return usuarios;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }

    public async Task<Usuario?> AddUsuario(Usuario inputModelUsuario)
    {
        try
        {
            _geralPersist.Add(inputModelUsuario);

            if (await _geralPersist.SaveChangeAsync())
            {
                var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(inputModelUsuario.ID_Usuario);

                return usuarioRetorno;
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }

    public async Task<bool> DeleteUsuario(int idUsuario)
    {
        try
        {
            var usuario = await _usuarioPersist.GetUsuarioByIdAsync(idUsuario);
            if (usuario == null) 
                throw new Exception("Usuário não encontrado.");

            _geralPersist.Delete(usuario);

            return await _geralPersist.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }

    public async Task<Usuario?> UpdateUsuario(int idUsuario, Usuario inputModelUsuario)
    {
        try
        {
            var usuario = await _usuarioPersist.GetUsuarioByIdAsync(idUsuario);
            if (usuario is null) 
                return null;

            _geralPersist.Update(usuario);

            if (await _geralPersist.SaveChangeAsync())
            {
                var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(inputModelUsuario.ID_Usuario);
                return usuarioRetorno;
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro: {ex.Message}");
        }
    }
}

