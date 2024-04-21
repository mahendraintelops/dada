using MediatR;

namespace Application.Commands.FsfssService
{
    public class CreateFsfssCommand : IRequest<int>
    {
        public int Id  { get; set; }
    
        
        public int8 Fsfs { get; set; }
        
    
    }
}
