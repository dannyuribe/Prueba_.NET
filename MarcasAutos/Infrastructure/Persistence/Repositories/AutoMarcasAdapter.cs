using MarcasAutos.Application.Interfaces.Infrastructure.Repositories;
using MarcasAutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutos.Infrastructure.Persistence.Repositories;

public class AutoMarcasAdapter : IAutosMarcasRepository
{
    private readonly AutosMarcasDbContext _context;

    public AutoMarcasAdapter(AutosMarcasDbContext context)
    {
        _context = context;
    }

    public async Task<List<MarcaAutoEntity>> GetAllAsync()
    {
        return await _context.MarcasAutos
            .Where(m => m.IsActive)
            .ToListAsync();
    }
}
