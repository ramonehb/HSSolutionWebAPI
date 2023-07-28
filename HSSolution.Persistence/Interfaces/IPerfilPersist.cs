using HSSolution.Domain;

namespace HSSolution.Persistence.Interfaces;

public interface IPerfilPersist
{
    Task<Perfil[]> GetPerfilsAsync();
}