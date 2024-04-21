using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.FsfssService;
using Application.Exceptions;
using Core.Entities;
using Core.Repositories;


namespace Application.Handlers.FsfssService
{
    public class UpdateFsfssCommandHandler : IRequestHandler<UpdateFsfssCommand>
    {
        private readonly IFsfssRepository _fsfssRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateFsfssCommandHandler> _logger;

        public UpdateFsfssCommandHandler(IFsfssRepository fsfssRepository, IMapper mapper, ILogger<UpdateFsfssCommandHandler> logger)
        {
            _fsfssRepository = fsfssRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateFsfssCommand request, CancellationToken cancellationToken)
        {
            var fsfssToUpdate = await _fsfssRepository.GetByIdAsync(request.Id);
            if (fsfssToUpdate == null)
            {
                throw new FsfssNotFoundException(nameof(Fsfss), request.Id);
            }

            _mapper.Map(request, fsfssToUpdate, typeof(UpdateFsfssCommand), typeof(Fsfss));
            await _fsfssRepository.UpdateAsync(fsfssToUpdate);
            _logger.LogInformation($"Fsfss is successfully updated");
        }
    }
}
