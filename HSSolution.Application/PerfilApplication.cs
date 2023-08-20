using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using HSSolution.Persistence.Interfaces;

namespace HSSolution.Application;

public class PerfilApplication : IPerfilApplitcation
{
    private readonly IPerfilPersist _perfilPersist;

    public PerfilApplication(IPerfilPersist perfil)
    {
        _perfilPersist = perfil;
    }

    public async Task<Perfil[]?> GetPerfilsAsync()
    {
        try
        {
            var perfils = await _perfilPersist.GetPerfilsAsync();
            if (perfils.Count() == 0) return null;

            return perfils;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
