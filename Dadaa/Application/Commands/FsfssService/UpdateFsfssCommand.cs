using MediatR;

namespace Application.Commands.FsfssService
{
    public class UpdateFsfssCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public int8 Fsfs { get; set; }
        
    
    }
}
