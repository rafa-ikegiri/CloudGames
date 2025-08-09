using System.ComponentModel.DataAnnotations;

namespace Core.Entity;

public class Usuario : EntityBase
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "A senha é obrigatória.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "A senha deve ter no mínimo 8 caracteres, incluindo letra maiúscula, minúscula, número e caractere especial.")]
    public required string Senha { get; set; }

    public bool IsAdmin { get; set; }
}