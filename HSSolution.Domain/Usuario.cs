using System.ComponentModel.DataAnnotations;

namespace HSSolution.Domain;

public class Usuario
{
    protected Usuario() { }

    public Usuario(int iD_Usuario, string nome, string nR_CPF, string email, string nR_Telefone, DateTime dT_Nascimento)
    {
        ID_Usuario = iD_Usuario;
        Nome = nome;
        NR_CPF = nR_CPF;
        Email = email;
        NR_Telefone = nR_Telefone;
        DT_Nascimento = dT_Nascimento;
        DT_Cadastro = DateTime.Now;
    }

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

