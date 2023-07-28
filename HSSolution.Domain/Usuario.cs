using System.ComponentModel.DataAnnotations;

namespace HSSolution.Domain;

public class Usuario
{
    [Key]
    public int ID_Usuario { get; set; }
    public int ID_Perfil { get; set; }
    public string Nome { get; set; }
    public string NR_CPF { get; set; }
    public string Email { get; set; }
    public string NR_Telefone { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public bool FL_Habilitado { get; set; }
    public int NR_UltimoAcesso { get; set; }
    public DateTime DT_UltimoAcesso { get; set; }
    public DateTime DT_Nascimento { get; set; }
    public DateTime DT_Cadastro { get; set; }
    public DateTime DT_Expiracao { get; set; }
    public int NR_Tentativa { get; set; }
    public DateTime DT_UltimaTentativa { get; set; }
}

