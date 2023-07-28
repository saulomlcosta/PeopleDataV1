using AutoMapper;
using PeopleDataV1.Entities;
using PeopleDataV1.Extras.Enums;
using PeopleDataV1.ViewModels.Peoples;
using PeopleDataV1.ViewModels.Users;

namespace PeopleDataV1.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<User, UserViewModel>();

            CreateMap<RegisterUserViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<UpdateUserViewModel, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            CreateMap<People, PeopleViewModel>();

            CreateMap<RegisterPeopleViewModel, People>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle));

            CreateMap<UpdatePeopleViewModel, People>()
              .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
              .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
              .ForMember(dest => dest.Sex, opt => opt.MapFrom(src => src.Sex))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
              .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
              .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle));

            CreateMap<RegisterPeopleCsvViewModel, People>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) 
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.NewGuid()));
        }    
    }
}
