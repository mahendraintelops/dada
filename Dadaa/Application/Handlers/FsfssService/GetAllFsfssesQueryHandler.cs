using AutoMapper;
using MediatR;
using Application.Queries.FsfssService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.FsfssService
{
    public class GetAllFsfssesQueryHandler : IRequestHandler<GetAllFsfssesQuery, List<FsfssResponse>>
    {
        private readonly IFsfssRepository _fsfssRepository;
        private readonly IMapper _mapper;
        public GetAllFsfssesQueryHandler(IFsfssRepository fsfssRepository, IMapper mapper)
        {
            _fsfssRepository = fsfssRepository;
            _mapper = mapper;
        }
        public async Task<List<FsfssResponse>> Handle(GetAllFsfssesQuery request, CancellationToken cancellationToken)
        {
            var generatedFsfss = await _fsfssRepository.GetAllAsync();
            var fsfssEntity = _mapper.Map<List<FsfssResponse>>(generatedFsfss);
            return fsfssEntity;
        }
    }
}
