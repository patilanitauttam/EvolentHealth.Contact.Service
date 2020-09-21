using AutoMapper;
using EvolentHealth.Contact.Common.Model;
using EvolentHealth.Contact.DataAccess.Entities;

namespace EvolentHealth.Contact.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contacts, ContactModel>()
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.ModifiedBy))
                .ForMember(dest => dest.PrimaryEmail, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
        }
    }
}

