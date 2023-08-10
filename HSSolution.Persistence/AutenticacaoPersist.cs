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

    public async Task<(Usuario?, string)> AutenticaUsuario(string userName, string password)
    {       
        var usuarios = await _context.Usuarios
            .AsNoTracking()
            .Where(u => u.Login == userName && u.Senha == password)
            .ToArrayAsync();

        if (usuarios.Count() == 1)
        {
            return (usuarios.Single(), "Usuário localizado com sucesso.");
        }
        else if (usuarios.Count() > 1)
        {
            var habilitados = usuarios.Where(u => (u.FlHabilitado ?? false) == true);
            if (habilitados.Count() == 0)
            {
                return (null,"Usuário desabilitado, contate o administrador.");
            }
            else if (habilitados.Count() > 1)
            {
                return (null, "Multiplus usuários, contate o administrador.");
            }
            else
            {
                return (habilitados.Single(), "Usuário localizado com sucesso.");
            }
        }
        

        return (null, "Usuário não localizado.");
    }
}
