using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoxDev.Models;

    [Table("Usuario")]
    public class Usuario : IdentityUser
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 100 caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Idade é obrigatória")]
        [Range(13, 120, ErrorMessage = "Idade deve ser maior que 13 anos")]
        [Display(Name = "Idade")]
        public int Idade { get; set; }

        [Display(Name = "Avatar")]
        public string Avatar { get; set; } = "/images/default-avatar.png";

        [StringLength(500, ErrorMessage = "Descrição não pode exceder 500 caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    public DateTime DataNascimento { get; internal set; }
}
