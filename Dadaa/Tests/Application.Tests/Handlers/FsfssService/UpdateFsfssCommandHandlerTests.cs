using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.FsfssService;
using Application.Exceptions;
using Application.Handlers.FsfssService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.FsfssService
{
    public class UpdateFsfssCommandHandlerTests
    {
        private readonly Mock<IFsfssRepository> _fsfssRepository;
        private readonly Mock<ILogger<UpdateFsfssCommandHandler>> _logger;
        private readonly Mock<IMapper> _mapper;

        public UpdateFsfssCommandHandlerTests()
        {
            _fsfssRepository = new();
            _logger = new();
            _mapper = new();
        }

        [Fact]
        public async Task Handle_ThrowsFsfssNotFoundExceptionWhenFsfssNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new UpdateFsfssCommand { Id = Id }; // Create a request object

            _fsfssRepository
               .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Fsfss)null); // Mock the repository to return null

            var handler = new UpdateFsfssCommandHandler(_fsfssRepository.Object, _mapper.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<FsfssNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
