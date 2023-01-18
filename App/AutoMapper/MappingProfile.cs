using AutoMapper;

using Domain;
using App.DtoUsers;

namespace AutoMapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<UserDefaultRequestDto, User>();
            CreateMap<UserUpdateDefaultRequestDto, User>();
            CreateMap<User, UserUpdateDefaultRequestDto>();
            CreateMap<UserSignUpRequestDto, User>();
            CreateMap<User, UserDefaultResponseDto>();
            CreateMap<User, UserBasicResponseDto>();
            CreateMap<UserType, UserTypeResponseDto>();
        }
    }
}
