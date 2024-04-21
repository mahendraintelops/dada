using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.FsfssService;
using Application.Handlers.FsfssService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.FsfssService
{
    public class CreateFsfssCommandHandlerTests
    {
        private readonly Mock<IFsfssRepository> _fsfssRepository;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<CreateFsfssCommandHandler>> _logger;

        public CreateFsfssCommandHandlerTests()
        {
            _fsfssRepository = new();
            _mapper = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ReturnsId()
        {
            // Arrange
            var request = new CreateFsfssCommand(); // Create a request object as needed

            _mapper
                .Setup(m => m.Map<Fsfss>(request))
                .Returns(new Fsfss()); 

            _fsfssRepository
                .Setup(r => r.AddAsync(It.IsAny<Fsfss>()))
                .ReturnsAsync(new Fsfss { Id = 123 }); 

            var loggerMock = new Mock<ILogger<CreateFsfssCommandHandler>>();
            var handler = new CreateFsfssCommandHandler(_fsfssRepository.Object, _mapper.Object, loggerMock.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Equal(123, result); 
        }
    }
}
