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

    public bool AutenticaUsuario(string userName, string password)
    {
        return _context.Usuarios
            .Any(u => u.Login == userName && u.Senha == Criptografia.Hash(password) && u.FL_Habilitado);
    }
}
