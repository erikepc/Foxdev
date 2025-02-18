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
    [Required]
    [StringLength(500)]
    public string Descricao { get; set; }
}

