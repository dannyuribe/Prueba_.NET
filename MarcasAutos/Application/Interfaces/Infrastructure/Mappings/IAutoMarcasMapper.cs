using MarcasAutos.Application.DTOs.Autos;
using MarcasAutos.Domain.Entities;

namespace MarcasAutos.Application.Interfaces.Infrastructure.Mappings;

public interface IAutoMarcasMapper
{
    AutoMarcaDto ToMarcaAutoOutput(MarcaAutoEntity input);
    List<AutoMarcaDto> ToMarcaAutoOutput(List<MarcaAutoEntity> input);
}
