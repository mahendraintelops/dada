using AutoMapper;
using MediatR;
using Application.Queries.FsfssService;
using Application.Responses;
using Core.Repositories;

namespace Application.Handlers.FsfssService
{
    public class GetFsfssByIdQueryHandler : IRequestHandler<GetFsfssByIdQuery, FsfssResponse>
    {
        private readonly IFsfssRepository _fsfssRepository;
        private readonly IMapper _mapper;
        public GetFsfssByIdQueryHandler(IFsfssRepository fsfssRepository, IMapper mapper)
        {
            _fsfssRepository = fsfssRepository;
            _mapper = mapper;
        }
        public async Task<FsfssResponse> Handle(GetFsfssByIdQuery request, CancellationToken cancellationToken)
        {
            var generatedFsfss = await _fsfssRepository.GetByIdAsync(request.id);
            var fsfssEntity = _mapper.Map<FsfssResponse>(generatedFsfss);
            return fsfssEntity;
        }
    }
}
