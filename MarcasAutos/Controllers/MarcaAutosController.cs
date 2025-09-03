using MarcasAutos.Application.Queries.Autos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MarcasAutos.Controllers;

[Route("[controller]")]
[ApiController]
public class MarcaAutosController : ControllerBase
{
    private readonly IMediator _mediator;

    public MarcaAutosController(IMediator mediator)
    {
        _mediator = mediator;
    }  

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var response = await _mediator.Send(new GetAllAutosMarcasQuery());

        return Ok(response);
    }    
}
