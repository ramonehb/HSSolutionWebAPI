using System.ComponentModel.DataAnnotations;

namespace HSSolution.Domain;

public partial class Cobranca
{
    [Key]
    public int IdCobranca { get; set; }

    public int IdFatura { get; set; }

    public int? NrParcela { get; set; }

    public decimal? VlBruto { get; set; }

    public decimal? VlLiquido { get; set; }

    public virtual Fatura IdFaturaNavigation { get; set; } = null!;
}
