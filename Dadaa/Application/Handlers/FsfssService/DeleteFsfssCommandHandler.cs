using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.FsfssService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.FsfssService
{
    public class DeleteFsfssCommandHandler : IRequestHandler<DeleteFsfssCommand>
    {
        private readonly IFsfssRepository _fsfssRepository;
        private readonly ILogger<DeleteFsfssCommandHandler> _logger;

        public DeleteFsfssCommandHandler(IFsfssRepository fsfssRepository, ILogger<DeleteFsfssCommandHandler> logger)
        {
            _fsfssRepository = fsfssRepository;
            _logger = logger;
        }
        public async Task Handle(DeleteFsfssCommand request, CancellationToken cancellationToken)
        {
            var fsfssToDelete = await _fsfssRepository.GetByIdAsync(request.Id);
            if (fsfssToDelete == null)
            {
                throw new FsfssNotFoundException(nameof(Fsfss), request.Id);
            }

            await _fsfssRepository.DeleteAsync(fsfssToDelete);
            _logger.LogInformation($" Id {request.Id} is deleted successfully.");
        }
    }
}
