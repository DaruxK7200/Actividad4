using Actividad4.Data;
using Actividad4.Dtos;
using Actividad4.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad4.Services;

public class ProductoService : IProductoService
{
    private readonly AppDbContext _context;

    public ProductoService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ProductoResponseDto?> ActualizarProducto(
    int id,
    ProductoRequestDto productoRequest)
    {
    var existe = await _context.Productos.FindAsync(id);

    if (existe == null)
        return null;

    existe.Nombre = productoRequest.Nombre;
    existe.Precio = productoRequest.Precio;
    existe.Stock = productoRequest.Stock;
    existe.CategoriaId = productoRequest.CategoriaId;

    await _context.SaveChangesAsync();

    return new ProductoResponseDto
    {
        Id = existe.Id,
        Nombre = existe.Nombre,
        Precio = existe.Precio,
        Stock = existe.Stock,
        Estado = existe.Estado,
        CategoriaId = existe.CategoriaId
    };
    }

    public async Task<Producto?> BuscarPorIdAsync(int id)
    {
    return await _context.Productos.FindAsync(id);
    }

    public async Task<ProductoResponseDto> CrearProductoAsync(
    ProductoRequestDto productoRequest)
    {
    var producto = new Producto
    {
        Nombre = productoRequest.Nombre,
        Precio = productoRequest.Precio,
        Stock = productoRequest.Stock,
        Estado = true,
        CategoriaId = productoRequest.CategoriaId
    };

    _context.Productos.Add(producto);

    await _context.SaveChangesAsync();

    return new ProductoResponseDto
    {
        Id = producto.Id,
        Nombre = producto.Nombre,
        Precio = producto.Precio,
        Stock = producto.Stock,
        Estado = producto.Estado,
        CategoriaId = producto.CategoriaId
    };
    }

    public async Task<bool> EliminarAsync(int id)
    {
    var existe = await _context.Productos.FindAsync(id);

    if (existe == null)
        return false;

    _context.Productos.Remove(existe);

    await _context.SaveChangesAsync();

    return true;
    }

    public async Task<List<ProductoResponseDto>> ObtenerTodosAsync()
    {
    return await _context.Productos
        .Include(p => p.Categoria)
        .Select(p => new ProductoResponseDto
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Precio = p.Precio,
            Stock = p.Stock,
            Estado = p.Estado,
            CategoriaId = p.CategoriaId,
            NombreCategoria = p.Categoria!.Nombre
        })
        .ToListAsync();
    }
}