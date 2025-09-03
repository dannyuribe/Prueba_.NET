using MarcasAutos.Domain.Entities;

namespace MarcasAutos.Application.Interfaces.Infrastructure.Repositories;

public interface IAutosMarcasRepository
{
    Task<List<MarcaAutoEntity>> GetAllAsync();
}
