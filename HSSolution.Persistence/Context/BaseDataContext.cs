using HSSolution.Domain;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence.Context;

public class BaseDataContext : DbContext
{
    public BaseDataContext(DbContextOptions<BaseDataContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<Perfil> Perfils { get; set; }
}

