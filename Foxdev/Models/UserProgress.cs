using System;
using System.ComponentModel.DataAnnotations;
using Foxdev.Models;

namespace Foxdev.Models;

public class UserProgress
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; }
    
    [Required]
    public int LicaoId { get; set; }
    
    public bool Desbloqueada { get; set; }
    public bool Concluida { get; set; }
    public int Vidas { get; set; } = 3; // Valor padrão
    public DateTime UltimaTentativa { get; set; } = DateTime.UtcNow;

    // Relacionamentos
    public Usuario User { get; set; }
    public Licao Licao { get; set; }
}