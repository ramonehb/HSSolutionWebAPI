using HSSolution.Application.Dtos;
using HSSolution.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;

namespace HSSolution.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin, User")]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioApplication _usuarioApplication;

    public UsuarioController(IUsuarioApplication usuarioApplication)
    {
        _usuarioApplication = usuarioApplication;
    }

    /// <summary>
    /// Obter todos os usuários
    /// </summary>
    /// <returns>Dados dos usuário</returns>
    /// <response code="200"></response>
    /// <response code="204"></response>
    /// <response code="500"></response>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetAllUsuarios()
    {
        try
        {
            var usuarios = await _usuarioApplication.GetUsuariosAsync();
            if (usuarios is null) return NoContent();

            return Ok(usuarios);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar todos os usuários.\nErro: {ex.Message}");
        }
    }


    /// <summary>
    /// Obter usuário por id
    /// </summary>
    /// <param name="idUsuario">Identificador do usuário</param>
    /// <returns>Dados do usuário</returns>
    /// <response code="200"></response>
    /// <response code="404"></response>
    /// <response code="422"></response>
    /// <response code="500"></response>
    [HttpGet("{idUsuario}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetUsuarioById(int idUsuario)
    {
        try
        {
            if (idUsuario == 0) return UnprocessableEntity("Informe o id do usuário para buscar.");

            var usuario = await _usuarioApplication.GetUsuarioByIdAsync(idUsuario);
            if (usuario is null) return NotFound("Usuário não localizado.");

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar usuário por Id.\nErro: {ex.Message}");
        }   
    }


    /// <summary>
    /// Cadastrar usuário
    /// </summary>
    /// <param name="usuarioInputModel">Model do usuário</param>
    /// <returns>Dados do usuário</returns>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="422"></response>
    /// <response code="500"></response>
    [HttpPost("{usuario}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]

    public async Task<ActionResult<UsuarioViewModel>> CadastrarUsuario(UsuarioInputModel usuarioInputModel)
    {
        try
        {
            var bExistePerfil = await _usuarioApplication.ValidaPerfil(usuarioInputModel.idPerfil);

            if (bExistePerfil)
            {
                if (string.IsNullOrEmpty(usuarioInputModel.senha))
                {
                    return UnprocessableEntity("O campo senha é obrigatório");
                }

                var mensagemRetorno = await _usuarioApplication.ValidaLoginEmail(usuarioInputModel.login, usuarioInputModel.email);
                if (mensagemRetorno != string.Empty)
                {
                    return UnprocessableEntity(mensagemRetorno);
                }

                var usuarioCadastrado = await _usuarioApplication.AddUsuario(usuarioInputModel);

                if (usuarioCadastrado == null)
                {
                    return UnprocessableEntity("Erro ao cadastrar usuário.");
                }

                return Ok(usuarioCadastrado);
            }
            
            return UnprocessableEntity($"Perfil {usuarioInputModel.idPerfil} não cadastrado.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar cadastrar o usuário.\nErro: {ex.Message}");
        }
    }


    /// <summary>
    /// Excluir usuário por id
    /// </summary>
    /// <param name="idUsuario">Identificador do usuário</param>
    /// <returns>Dados do usuário</returns>
    /// <response code="200"></response>
    /// <response code="404"></response>
    /// <response code="422"></response>
    /// <response code="500"></response>
    [HttpDelete("{idUsuario}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]

    public async Task<ActionResult> DeletarUsuario(int idUsuario)
    {
        try
        {
            if (idUsuario == 0)
            {
                return UnprocessableEntity("Informe o id do usuário para deletar.");
            }

           var bUsuarioDeletado = await _usuarioApplication.DeleteUsuario(idUsuario);

            if (!bUsuarioDeletado)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Ok("Usuário excluído com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar excluir o usuário.\nErro: {ex.Message}");
        }
    }

    /// <summary>
    /// Atualizar usuário
    /// </summary>
    /// <param name="idUsuario">Identificador do usuário</param>
    /// <param name="usuarioInputModel">Model do usuário</param>
    /// <returns>Dados do usuário</returns>
    /// <response code="200"></response>
    /// <response code="400"></response>
    /// <response code="422"></response>
    /// <response code="500"></response>
    [HttpPut("{idUsuario}/{usuarioInputModel}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(422)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<UsuarioViewModel>> AtualizarUsuario(int idUsuario, UsuarioInputModel usuarioInputModel)
    {
        try
        {
            if (idUsuario == 0) return UnprocessableEntity("Informe o id do usuário para buscar.");

            var usuario = await _usuarioApplication.UpdateUsuario(idUsuario, usuarioInputModel);

            if (usuario is null) return NotFound("Usuário não localizado.");

            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar usuário.\nErro: {ex.Message}");
        }
    }
}

