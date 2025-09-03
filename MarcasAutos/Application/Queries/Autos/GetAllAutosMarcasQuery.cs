using MarcasAutos.Application.DTOs.Autos;
using MarcasAutos.Responses;
using MediatR;

namespace MarcasAutos.Application.Queries.Autos;

public class GetAllAutosMarcasQuery: IRequest<ApiResponse<GetAutoMarcaOutput>>
{
}
