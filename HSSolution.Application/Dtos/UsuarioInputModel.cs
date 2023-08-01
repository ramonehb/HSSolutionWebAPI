using System.ComponentModel.DataAnnotations;

namespace HSSolution.Application.Dtos;

public class UsuarioInputModel
{
    public int ID_Usuario { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório."), 
        StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter no mínimo 3 ou no máximo 50 carecteres.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo CPF é obrigatório")]
    //[Functions.ValidaCPF(ErrorMessage = "CPF inválido")]
    public string NR_CPF { get; set; }

    [Required(ErrorMessage = "O campo e-mail é obrigatório ")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido."),
        StringLength(100, MinimumLength = 3, ErrorMessage = "O e-mail deve ter no mínimo 5 ou no máximo 100 carecteres.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "O campo telefone está com número inválido.")]
    public string NR_Telefone { get; set; }

    public DateTime DT_Nascimento { get; set; }

    public DateTime DT_Cadastro { get; set; }
}
