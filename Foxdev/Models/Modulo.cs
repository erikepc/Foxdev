using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Foxdev.Models;


[Table("modulo")]
public class Modulo
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Titulo { get; set; }

    public List<Licao> Licoes { get; set; } = new List<Licao>();
}

