using HSSolution.Domain;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence;

public class AutenticacaoPersist : IAutenticacaoPersist
{
    private readonly BaseDataContext _context;

    public AutenticacaoPersist(BaseDataContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> AutenticaUsuario(string userName, string password)
    {
        //var bExisteUsuario = _context.Usuarios.Any(u => u.Login == userName && u.Senha == Criptografia.Hash(password) && u.FL_Habilitado);
        var bExisteUsuario = _context.Usuarios.Any(u => u.Login == userName && u.Senha == password && u.FL_Habilitado);

        if (bExisteUsuario)
        {
            var usuario =  _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Login == userName && u.Senha == password);

            return await usuario;
        }

        return null;
    }
}
