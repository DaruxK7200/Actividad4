using Actividad4.Dtos;
using Actividad4.Models;

namespace Actividad4.Services;

public interface IProductoService
{
    Task<List<ProductoResponseDto>> ObtenerTodosAsync();

    Task<Producto?> BuscarPorIdAsync(int id);

    Task<ProductoResponseDto> CrearProductoAsync(
        ProductoRequestDto producto);

    Task<ProductoResponseDto?> ActualizarProducto(
        int id,
        ProductoRequestDto producto);

    Task<bool> EliminarAsync(int id);
}