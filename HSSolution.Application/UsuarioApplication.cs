﻿using AutoMapper;
using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using HSSolution.Domain;
using HSSolution.Persistence.Interfaces;

namespace HSSolution.Application;

public class UsuarioApplication : IUsuarioApplication
{

    private readonly IGeralPersist _geralPersist;
    private readonly IUsuarioPersist _usuarioPersist;
    private readonly IMapper _mapper;

    public UsuarioApplication(IGeralPersist geralPersist, IUsuarioPersist usuarioPersist, IMapper mapper)
    {
        _geralPersist = geralPersist;
        _usuarioPersist = usuarioPersist;   
        _mapper = mapper;
    }

    public async Task<UsuarioViewModel?> GetUsuarioByIdAsync(int idUsuario)
    {
        try
        {
            var usuario = await _usuarioPersist.GetUsuarioByIdAsync(idUsuario);
            if (usuario == null) return null;

            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            return usuarioViewModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<UsuarioViewModel[]?> GetUsuariosAsync()
    {
        try
        {
            var usuarios = await _usuarioPersist.GetUsuariosAsync();
            if (usuarios == null) return null;

            var usuarioViewModel = _mapper.Map <UsuarioViewModel[]>(usuarios);

            return usuarioViewModel;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<UsuarioViewModel?> AddUsuario(UsuarioInputModel inputModelUsuario)
    {
        try
        {
            var usuario = _mapper.Map<Usuario>(inputModelUsuario);
            usuario.DtCadastro = DateTime.Now;
            usuario.DtExpiracao = DateTime.Now.AddYears(1);
            usuario.NrUltimoAcesso = 0;
            usuario.FlHabilitado = true;
            usuario.IdPerfilNavigationIdPerfil = inputModelUsuario.idPerfil;

            _geralPersist.Add(usuario);

            if (await _geralPersist.SaveChangeAsync())
            {
                var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(usuario.IdUsuario);

                return _mapper.Map<UsuarioViewModel>(usuarioRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> DeleteUsuario(int idUsuario)
    {
        try
        {
            var usuario = await _usuarioPersist.GetUsuarioByIdAsync(idUsuario);
            if (usuario == null) return false;

            _geralPersist.Delete(usuario);

            return await _geralPersist.SaveChangeAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<UsuarioViewModel?> UpdateUsuario(int idUsuario, UsuarioInputModel inputModelUsuario)
    {
        try
        {
            var usuario = await _usuarioPersist.GetUsuarioByIdAsync(idUsuario);
            if (usuario == null) return null;

            usuario.IdPerfil = inputModelUsuario.idPerfil;
            usuario.IdPerfilNavigationIdPerfil = inputModelUsuario.idPerfil;
            usuario.Nome = inputModelUsuario.nome;
            usuario.Cpf = inputModelUsuario.cpf;
            usuario.Login = inputModelUsuario.login;
            usuario.Email = inputModelUsuario.email;
            usuario.Telefone = inputModelUsuario.telefone ?? usuario.Telefone;
            usuario.DtNascimento = inputModelUsuario.dtNascimento ?? usuario.DtNascimento;

            _geralPersist.Update(usuario);

            if (await _geralPersist.SaveChangeAsync())
            {
                var usuarioRetorno = await _usuarioPersist.GetUsuarioByIdAsync(idUsuario);

                return _mapper.Map<UsuarioViewModel>(usuarioRetorno);
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<bool> ValidaPerfil(int idPerfil)
    {
        try
        {
            var bExistePerfil = await _usuarioPersist.ExistsProfile(idPerfil);

            return bExistePerfil;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string> ValidaLoginEmail(string login, string email)
    {
        try
        {
            return await _usuarioPersist.ValidaLoginEmail(login, email);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


}

