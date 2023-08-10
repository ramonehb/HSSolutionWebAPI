using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HSSolution.Domain;

public partial class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    public int? IdPerfil { get; set; }

    public string Nome { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefone { get; set; }

    public string Login { get; set; } = null!;

    public string? Senha { get; set; }

    public bool? FlHabilitado { get; set; }

    public DateTime? DtNascimento { get; set; }

    public int? NrUltimoAcesso { get; set; }

    public DateTime? DtUltimoAcesso { get; set; }

    public DateTime? DtCadastro { get; set; }

    public DateTime? DtExpiracao { get; set; }

    public int? NrTentativa { get; set; }

    public DateTime? DtUltimaTentativa { get; set; }

    public int? IdPerfilNavigationIdPerfil { get; set; }

    public virtual Perfil? IdPerfilNavigationIdPerfilNavigation { get; set; }
}
