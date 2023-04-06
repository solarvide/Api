using AutoMapper;

using Domain;
using App.DtoUsers;
using App.Dto.Proposal;

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
            CreateMap<ProposalResponseDto, Proposal>();
            CreateMap<Proposal, ProposalResponseDto > ();
          
        }
    }
}
