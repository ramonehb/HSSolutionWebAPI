using HSSolution.Domain;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence;

public class UsuarioPersist : IUsuarioPersist
{
    private readonly BaseDataContext _context;

    public UsuarioPersist(BaseDataContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetUsuarioByIdAsync(int idUsuario)
    {
        IQueryable<Usuario> usuario = _context.Usuarios;

        usuario = usuario.AsNoTracking().Where(u => u.ID_Usuario == idUsuario);

        return await usuario.FirstOrDefaultAsync();
    }

    public Usuario? GetUsuarioByUserName(string username, string password)
    {
        IQueryable<Usuario> usuario = _context.Usuarios;

        usuario = usuario.AsNoTracking().Where(u => u.Login == username && u.Senha == Criptografia.Hash(password));

        return usuario.FirstOrDefault();
    }

    public async Task<Usuario[]> GetUsuariosAsync()
    {
        var usuarios = _context.Usuarios.ToArrayAsync();

        return await usuarios;
    }
}
