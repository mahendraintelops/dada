using AutoMapper;
using Moq;
using Application.Handlers.FsfssService;
using Application.Queries.FsfssService;
using Application.Responses;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.FsfssService
{
    public class GetAllFsfssesQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ReturnsListOfFsfssResponses()
        {
            // Arrange
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Fsfss, FsfssResponse>();
            });

            var mapper = new Mapper(mapperConfig);

            var obj = new List<Fsfss> 
        {
            new Fsfss { Id = 1 },
            new Fsfss { Id = 2 }

        };

            var RepositoryMock = new Mock<IFsfssRepository>();
            RepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(obj);

            var query = new GetAllFsfssesQuery();
            var handler = new GetAllFsfssesQueryHandler(RepositoryMock.Object, mapper);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<FsfssResponse>>(result);
            Assert.Equal(obj.Count, result.Count);
           
        }
    }
}
