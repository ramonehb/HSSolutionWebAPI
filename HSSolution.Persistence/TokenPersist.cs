using HSSolution.Domain;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence;

public class TokenPersist : ITokenPersist
{
    private readonly BaseDataContext _context;
    private readonly IGeralPersist _geralPersit;

    public TokenPersist(BaseDataContext context, IGeralPersist geralPersit)
    {
        _context = context;
        _geralPersit = geralPersit;
    }

    public async Task<(Usuario?, string, int)> AutenticaUsuario(string userName, string password)
    {       
        var usuarios = await _context.Usuarios
            .Where(u => u.Login == userName && u.Senha == password)
            .ToArrayAsync();

        if (usuarios.Count() == 1)
        {
            var usuario = usuarios.Single();
            usuario.NrUltimoAcesso++;
            usuario.DtUltimoAcesso = DateTime.Now;

            _geralPersit.Update(usuario);

            if (await _geralPersit.SaveChangeAsync())
            {
                return (usuario, "Usuário localizado com sucesso.", 200);
            }

            return (null, "Erro ao atualizar usuário.", 500);
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
                var usuario = usuarios.Single(u => u.FlHabilitado == true);
                usuario.NrUltimoAcesso++;
                usuario.DtUltimoAcesso = DateTime.Now;

                _geralPersit.Update(usuario);

                if (await _geralPersit.SaveChangeAsync())
                {
                    return (usuario, "Usuário localizado com sucesso.", 200);
                }

                return (null, "Erro ao atualizar usuário.", 500);
            }
        }

        return (null, "Usuário não localizado.", 404);
    }
}
