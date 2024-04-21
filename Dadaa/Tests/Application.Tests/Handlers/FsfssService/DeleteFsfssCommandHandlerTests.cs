using Microsoft.Extensions.Logging;
using Moq;
using Application.Commands.FsfssService;
using Application.Exceptions;
using Application.Handlers.FsfssService;
using Core.Entities;
using Core.Repositories;

namespace Application.Tests.Handlers.FsfssService
{
    public class DeleteFsfssCommandHandlerTests
    {
        private readonly Mock<IFsfssRepository> _fsfssRepository;
        private readonly Mock<ILogger<DeleteFsfssCommandHandler>> _logger;

        public DeleteFsfssCommandHandlerTests()
        {
            _fsfssRepository = new();
            _logger = new();
        }

        [Fact]
        public async Task Handle_ThrowsFsfssNotFoundExceptionWhenFsfssNotFound()
        {
            // Arrange
            var Id = 123; // Replace with the ID you want to test
            var request = new DeleteFsfssCommand { Id = Id }; // Create a request object

            _fsfssRepository
                .Setup(r => r.GetByIdAsync(Id))
                .ReturnsAsync((Fsfss)null); // Mock the repository to return null

            var handler = new DeleteFsfssCommandHandler(_fsfssRepository.Object, _logger.Object);

            // Act and Assert
            await Assert.ThrowsAsync<FsfssNotFoundException>(
                async () => await handler.Handle(request, CancellationToken.None)
            );
        }
    }
}
