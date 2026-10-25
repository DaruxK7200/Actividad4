using Actividad4.Models;
using Actividad4.Dtos;
using Actividad4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4.Controllers;

[ApiController]
[Route("api/v1/categorias")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriaController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpGet]
    public async Task<List<CategoriaResponseDto>> ObtenerCategorias()
    {
        return await _categoriaService.ObtenerTodosAsync();
    }

    [HttpPost]
    public async Task<CategoriaResponseDto> CrearCategoria(
        CategoriaRequestDto categoria)
    {
        return await _categoriaService.CrearCategoriaAsync(categoria);
    }

    [HttpDelete("{id:int}")]
    public async Task<bool> EliminarCategoria(int id)
    {
        return await _categoriaService.EliminarAsync(id);
    }

    [HttpPatch("{id:int}")]
    public async Task<CategoriaResponseDto?> ActualizarCategoria(
        int id,
        CategoriaRequestDto categoria)
    {
        return await _categoriaService
            .ActualizarCategoria(id, categoria);
    }
    [HttpGet("{id:int}")]
    public async Task<Categoria?> BuscarPorId(int id)
    {
        return await _categoriaService.BuscarPorIdAsync(id);
    }
}