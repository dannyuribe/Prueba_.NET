using MarcasAutos.Application.DTOs.Autos;
using MarcasAutos.Application.Interfaces.Infrastructure.Mappings;
using MarcasAutos.Application.Interfaces.Infrastructure.Repositories;
using MarcasAutos.Responses;
using MediatR;

namespace MarcasAutos.Application.Queries.Autos;

public class GetAllAutosMarcasQueryHandler : IRequestHandler<GetAllAutosMarcasQuery, ApiResponse<GetAutoMarcaOutput>>
{
    private readonly IAutosMarcasRepository _autosMarcasRepository;
    private readonly IAutoMarcasMapper _autoMarcasMapper;

    public GetAllAutosMarcasQueryHandler(IAutosMarcasRepository autosMarcasRepository, IAutoMarcasMapper autoMarcasMapper)
    {
        _autosMarcasRepository = autosMarcasRepository;
        _autoMarcasMapper = autoMarcasMapper;
    }

    public async Task<ApiResponse<GetAutoMarcaOutput>> Handle(GetAllAutosMarcasQuery query, CancellationToken cancellationToken )
    {
        var autosMarcasEntity = await _autosMarcasRepository.GetAllAsync();

        var autosMarcas = _autoMarcasMapper.ToMarcaAutoOutput(autosMarcasEntity);

        return ApiResponse<GetAutoMarcaOutput>.SuccessResponse(
            new GetAutoMarcaOutput()
            {
                AutoMarcas = autosMarcas,
            }, 
            "Autos obtenidos exitosamente.");
    }
}
