using MediatR;

namespace Application.Commands.FsfssService
{
    public class DeleteFsfssCommand : IRequest
    {
        public int Id { get; set; }
    }
}
