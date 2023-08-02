﻿using HSSolution.Domain;
using HSSolution.Persistence.Context;
using HSSolution.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSSolution.Persistence;

public class UsuarioPersist : IUsuarioPersist
{
    private readonly BaseDataContext _context;

    public UsuarioPersist(BaseDataContext context)
    {
        _context = context;
    }

    public async Task<Usuario?> GetUsuarioByIdAsync(int idUsuario)
    {
        var usuario = _context.Usuarios
            .AsNoTracking()
            .SingleOrDefaultAsync(u => u.ID_Usuario == idUsuario);

        return await usuario;
    }

    public async Task<Usuario[]> GetUsuariosAsync()
    {
        var usuarios = _context.Usuarios.ToArrayAsync();

        return await usuarios;
    }
}
