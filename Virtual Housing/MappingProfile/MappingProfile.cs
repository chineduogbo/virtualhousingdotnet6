using AutoMapper;
using Virtual_Housing.Models.Dto;
using Virtual_Housing.Models.Model;

namespace Virtual_Housing.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateListingDto, Listings>().ReverseMap();
            CreateMap<CreateUserDto , User>().ReverseMap();  
            
        }
    }
}
