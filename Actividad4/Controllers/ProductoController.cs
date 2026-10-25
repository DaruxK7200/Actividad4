using Actividad4.Dtos;
using Actividad4.Models;
using Actividad4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Actividad4.Controllers;

[ApiController]
[Route("api/v1/productos")]
public class ProductoController : ControllerBase
{
    private readonly IProductoService _productoService;

    public ProductoController(IProductoService productoService)
    {
        _productoService = productoService;
    }

    [HttpGet]
    public async Task<List<ProductoResponseDto>> ObtenerProductos()
    {
        return await _productoService.ObtenerTodosAsync();
    }

    [HttpPost]
    public async Task<ProductoResponseDto> CrearProducto(
        ProductoRequestDto producto)
    {
        return await _productoService.CrearProductoAsync(producto);
    }

    [HttpDelete("{id:int}")]
    public async Task<bool> EliminarProducto(int id)
    {
        return await _productoService.EliminarAsync(id);
    }

    [HttpPatch("{id:int}")]
    public async Task<ProductoResponseDto?> ActualizarProducto(
        int id,
        ProductoRequestDto producto)
    {
        return await _productoService
            .ActualizarProducto(id, producto);
    }

    [HttpGet("{id:int}")]
    public async Task<Producto?> BuscarPorId(int id)
    {
        return await _productoService.BuscarPorIdAsync(id);
    }
}