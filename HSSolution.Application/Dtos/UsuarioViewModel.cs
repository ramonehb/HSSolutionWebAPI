namespace HSSolution.Application.Dtos;

public class UsuarioViewModel
{
    public int idUsuario { get; set; }
    public string nome { get; set; }
    public string cpf { get; set; }
    public string login { get; set; }
    public string email { get; set; }
    public string telefone { get; set; }
    public DateTime dtNascimento { get; set; }
    public DateTime dtCadastro { get; set; }
    public DateTime dtExpiracao { get; set; }
    public bool flHabilitado { get; set; }

}
