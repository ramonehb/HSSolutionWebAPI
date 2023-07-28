using System.ComponentModel.DataAnnotations;

namespace HSSolution.Domain;

public class Perfil
{
    [Key]
    public int ID_Perfil { get; set; }
    public string NM_Descricao { get; set; }
}

