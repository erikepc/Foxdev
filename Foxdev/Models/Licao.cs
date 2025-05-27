using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxdev.Models;

public class Licao
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; }

    [Required]
    public int ModuloId { get; set; }
    
    // Explicação introdutória para a lição
    public string Explicacao { get; set; }

    // Campo para armazenar a classe do ícone (ex: "fas fa-lightbulb")
    public string? Icon { get; set; } // Adicionado campo para o ícone (nullable)
    
    [ForeignKey(nameof(ModuloId))]
    public Modulo Modulo { get; set; }

    public List<Questao> Questaos { get; set; }
}

