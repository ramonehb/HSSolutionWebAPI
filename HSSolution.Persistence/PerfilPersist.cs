using HSSolution.Domain;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence;
public class PerfilPersist : IPerfilPersist
{
    private readonly BaseDataContext _context;

    public PerfilPersist(BaseDataContext context)
    {
        _context = context;
    }

    public async Task<Perfil[]> GetPerfilsAsync()
    {
        var perfils = _context.Perfils.ToArrayAsync();

        return await perfils;
    }
}
