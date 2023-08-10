using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HSSolution.Domain;

public partial class Perfil
{
    [Key]
    public int IdPerfil { get; set; }

    public string? NmDescricao { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
