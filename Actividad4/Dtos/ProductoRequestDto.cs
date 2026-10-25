using System.ComponentModel.DataAnnotations;

namespace Actividad4.Dtos;

public class ProductoRequestDto
{
    [Required]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [Range(1, 999999)]
    public decimal Precio { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }

    [Required]
    public int CategoriaId { get; set; }
}