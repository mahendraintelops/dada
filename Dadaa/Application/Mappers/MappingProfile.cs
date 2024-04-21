using AutoMapper;

using Application.Commands.FsfssService;

using Application.Responses;
using Core.Entities;

namespace Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          
            CreateMap<Fsfss, FsfssResponse>().ReverseMap();
            CreateMap<Fsfss, CreateFsfssCommand>().ReverseMap();
            CreateMap<Fsfss, UpdateFsfssCommand>().ReverseMap();
          
        }
    }
}
