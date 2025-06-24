using System.ComponentModel.DataAnnotations;

namespace Foxdev.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar de mim")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Senha deve ter pelo menos 6 caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "As senhas não coincidem")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Idade é obrigatória")]
        [Range(13, 120, ErrorMessage = "Idade deve estar entre 13 e 120 anos")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}

