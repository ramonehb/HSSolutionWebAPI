using HSSolution.Domain;

namespace HSSolution.Application.Interfaces;

public interface IPerfilApplitcation
{
    Task<Perfil[]?> GetPerfilsAsync();

}

