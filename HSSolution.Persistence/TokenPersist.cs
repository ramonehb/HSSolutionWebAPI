using HSSolution.Domain;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence;

public class TokenPersist : ITokenPersist
{
    private readonly BaseDataContext _context;

    public TokenPersist(BaseDataContext context)
    {
        _context = context;
    }

    public async Task<(Usuario?, string, int)> AutenticaUsuario(string userName, string password)
    {       
        var usuarios = await _context.Usuarios
            .AsNoTracking()
            .Where(u => u.Login == userName && u.Senha == password)
            .ToArrayAsync();

        if (usuarios.Count() == 1)
        {
            return (usuarios.Single(), "Usuário localizado com sucesso.", 200);
        }
        else if (usuarios.Count() > 1)
        {
            var habilitados = usuarios.Where(u => (u.FlHabilitado ?? false) == true);
            if (habilitados.Count() == 0)
            {
                return (null,"Usuário desabilitado, contate o administrador.", 422);
            }
            else if (habilitados.Count() > 1)
            {
                return (null, "Multiplus usuários, contate o administrador.", 422);
            }
            else
            {
                return (habilitados.Single(), "Usuário localizado com sucesso.", 200);
            }
        }
        

        return (null, "Usuário não localizado.", 404);
    }
}
