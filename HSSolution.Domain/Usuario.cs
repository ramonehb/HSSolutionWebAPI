namespace HSSolution.Domain;

public class Usuario
{
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

    public Usuario(int idUsuario,int idPerfil, string nome, string cpf, string email, string login, string senha)
    {
        ID_Usuario = idUsuario;
        ID_Perfil = idPerfil;
        Nome = nome;
        NR_CPF = cpf;
        Email = email;
        Login = login;
        Senha = senha;
    }

}

