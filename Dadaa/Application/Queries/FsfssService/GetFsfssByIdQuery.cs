using MediatR;
using Application.Responses;

namespace Application.Queries.FsfssService
{
    public class GetFsfssByIdQuery : IRequest<FsfssResponse>
    {
        public int id { get; set; }

        public GetFsfssByIdQuery(int _id)
        {
            id = _id;
        }
    }
}
