using MediatR;
using Application.Responses;

namespace Application.Queries.FsfssService
{
    public class GetAllFsfssesQuery : IRequest<List<FsfssResponse>>
    {

    }
}
