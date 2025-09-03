using MarcasAutos.Application.DTOs.Autos;
using MarcasAutos.Application.Interfaces.Infrastructure.Mappings;
using MarcasAutos.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace MarcasAutos.Infrastructure.Mappings;

[Mapper]
public partial class AutoMarcasMapper : IAutoMarcasMapper
{
    public partial AutoMarcaDto ToMarcaAutoOutput(MarcaAutoEntity input);
    public partial List<AutoMarcaDto> ToMarcaAutoOutput(List<MarcaAutoEntity> input);
}

