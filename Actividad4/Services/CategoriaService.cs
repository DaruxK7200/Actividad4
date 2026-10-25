using Actividad4.Data;
using Actividad4.Dtos;
using Actividad4.Models;
using Microsoft.EntityFrameworkCore;

namespace Actividad4.Services;

public class CategoriaService : ICategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoriaResponseDto>> ObtenerTodosAsync()
    {
        return await _context.Categorias
            .Select(c => new CategoriaResponseDto
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion
            })
            .ToListAsync();
    }

    public async Task<Categoria?> BuscarPorIdAsync(int id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<CategoriaResponseDto> CrearCategoriaAsync(
        CategoriaRequestDto categoria)
    {
        var nuevaCategoria = new Categoria
        {
            Nombre = categoria.Nombre,
            Descripcion = categoria.Descripcion
        };

        _context.Categorias.Add(nuevaCategoria);

        await _context.SaveChangesAsync();

        return new CategoriaResponseDto
        {
            Id = nuevaCategoria.Id,
            Nombre = nuevaCategoria.Nombre,
            Descripcion = nuevaCategoria.Descripcion
        };
    }

    public async Task<CategoriaResponseDto?> ActualizarCategoria(
        int id,
        CategoriaRequestDto categoria)
    {
        var existe = await _context.Categorias.FindAsync(id);

        if (existe == null)
            return null;

        existe.Nombre = categoria.Nombre;
        existe.Descripcion = categoria.Descripcion;

        await _context.SaveChangesAsync();

        return new CategoriaResponseDto
        {
            Id = existe.Id,
            Nombre = existe.Nombre,
            Descripcion = existe.Descripcion
        };
    }

    public async Task<bool> EliminarAsync(int id)
    {
        var existe = await _context.Categorias.FindAsync(id);

        if (existe == null)
            return false;

        _context.Categorias.Remove(existe);

        await _context.SaveChangesAsync();

        return true;
    }
}
