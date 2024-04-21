using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Application.Commands.FsfssService;
using Core.Entities;
using Core.Repositories;

namespace Application.Handlers.FsfssService
{
    public class CreateFsfssCommandHandler : IRequestHandler<CreateFsfssCommand, int>
    {
        private readonly IFsfssRepository _fsfssRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateFsfssCommandHandler> _logger;

        public CreateFsfssCommandHandler(IFsfssRepository fsfssRepository, IMapper mapper, ILogger<CreateFsfssCommandHandler> logger)
        {
            _fsfssRepository = fsfssRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateFsfssCommand request, CancellationToken cancellationToken)
        {
            var fsfssEntity = _mapper.Map<Fsfss>(request);

            /*****************************************************************************/
            var generatedFsfss = await _fsfssRepository.AddAsync(fsfssEntity);
            /*****************************************************************************/
            _logger.LogInformation($" {generatedFsfss} successfully created.");
            return generatedFsfss.Id;
        }
    }
}
