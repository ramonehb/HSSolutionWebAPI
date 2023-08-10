using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HSSolution.Domain;

public partial class Fatura
{
    [Key]
    public int IdFatura { get; set; }

    public string NmSubEstipulante { get; set; } = null!;

    public DateTime? DtCadastro { get; set; }

    public virtual ICollection<Cobranca> Cobrancas { get; set; } = new List<Cobranca>();
}
