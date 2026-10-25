using System.ComponentModel.DataAnnotations;

namespace Actividad4.Dtos;

public class CategoriaRequestDto
{
    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    public string? Descripcion { get; set; }
}