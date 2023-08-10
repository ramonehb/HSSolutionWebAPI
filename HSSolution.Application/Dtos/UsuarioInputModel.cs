using System.ComponentModel.DataAnnotations;

namespace HSSolution.Application.Dtos;

public class UsuarioInputModel
{

    [Required(ErrorMessage = "o id do perfil é obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "o id do perfil não pode ser zero")]
    public int idPerfil { get; set; }


    [Required(ErrorMessage = "O campo nome é obrigatório."), 
        StringLength(50, MinimumLength = 3, ErrorMessage = "O nome deve ter no mínimo 3 ou no máximo 50 carecteres.")]
    public string nome { get; set; }


    [Required(ErrorMessage = "O campo CPF é obrigatório")]
    public string cpf { get; set; }


    [Required(ErrorMessage = "O campo Login é obrigatório")]
    public string login { get; set; }


    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public string senha { get; set; }

    [Required(ErrorMessage = "O campo e-mail é obrigatório ")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido."),
        StringLength(100, MinimumLength = 5, ErrorMessage = "O e-mail deve ter no mínimo 5 ou no máximo 100 carecteres.")]
    public string email { get; set; }

    [Phone(ErrorMessage = "O campo telefone está com número inválido.")]
    public string telefone { get; set; }

    public DateTime dtNascimento { get; set; }

}
