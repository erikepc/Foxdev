using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxdev.Models;

public class Licao
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Titulo { get; set; }
    // public LicaoTipo Tipo { get; set; } // Enum: Quiz, CodeCompletion, etc.

    [Required]
        public int ModuloId { get; set; }
    
    [ForeignKey(nameof(ModuloId))]
    public List<Modulo> Modulos { get; set; }
}