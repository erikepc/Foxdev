using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxdev.Models;

[Table("usuario")]
public class Usuario : IdentityUser
{
    [Required(ErrorMessage = "Nome obrigatório")]
    [StringLength(100, MinimumLength = 3)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Idade obrigatória")]
    [Range(13, 120)]
    public int Idade { get; set; }

    public string Avatar { get; set; } = "/images/default-avatar.png";
    public string Descricao { get; set; }
    public DateTime DataNascimento { get; set; }

    public List<UserProgress> Progressos { get; set; } = new List<UserProgress>();
}