using Actividad4.Dtos;
using Actividad4.Models;

namespace Actividad4.Services;

public interface ICategoriaService
{
    Task<List<CategoriaResponseDto>> ObtenerTodosAsync();

    Task<Categoria?> BuscarPorIdAsync(int id);

    Task<CategoriaResponseDto> CrearCategoriaAsync(
        CategoriaRequestDto categoria);

    Task<CategoriaResponseDto?> ActualizarCategoria(
        int id,
        CategoriaRequestDto categoria);

    Task<bool> EliminarAsync(int id);
}