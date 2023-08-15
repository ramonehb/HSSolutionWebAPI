using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HSSolution.Application.Dtos;

public class TokenInputModel
{

    [Required(ErrorMessage = "O campo username é obrigatório."),
        StringLength(25, MinimumLength = 3, ErrorMessage = "O username deve ter no mínimo 3 ou no máximo 25 carecteres.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = "O campo password é obrigatório."),
        StringLength(20, MinimumLength = 3, ErrorMessage = "O password deve ter no mínimo 3 ou no máximo 20 carecteres.")]
    public required string Password { get; set; }

    [JsonIgnore]
    public string PasswordCriptografada => Functions.Criptografia.Hash(Password);
}
