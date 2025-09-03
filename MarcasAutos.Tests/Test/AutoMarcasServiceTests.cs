using FluentAssertions;
using MarcasAutos.Application.DTOs.Autos;
using MarcasAutos.Application.Interfaces.Infrastructure.Mappings;
using MarcasAutos.Application.Interfaces.Infrastructure.Repositories;
using MarcasAutos.Application.Queries.Autos;
using MarcasAutos.Domain.Entities;
using Moq;
using System.Collections.Generic;

namespace MarcasAutos.Tests.Test;

public class AutoMarcasServiceTests
{
    private readonly Mock<IAutosMarcasRepository> _repoMock;
    private readonly Mock<IAutoMarcasMapper> _mapperMock;
    private readonly GetAllAutosMarcasQueryHandler _handler;


    public AutoMarcasServiceTests()
    {
        _repoMock = new Mock<IAutosMarcasRepository>();
        _mapperMock = new Mock<IAutoMarcasMapper>();
        _handler = new GetAllAutosMarcasQueryHandler(_repoMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldReturnMappedDtos_WhenRepositoryReturnsEntities()
    {
        var entities = new List<MarcaAutoEntity>
        {
            new("Toyota"),
            new("Honda"),
            new("Mazda"), 
        };

        List<AutoMarcaDto> dtos = [];

        foreach (var entity in entities)
        {
            dtos.Add(new AutoMarcaDto
            {
                Id = entity.Id,
                Name = entity.Name,
            });
        }

        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(entities);
        _mapperMock.Setup(m => m.ToMarcaAutoOutput(entities)).Returns(dtos);

        var result = await _handler.Handle(new GetAllAutosMarcasQuery(), CancellationToken.None);

        result.Should().NotBeNull();

    }

}
