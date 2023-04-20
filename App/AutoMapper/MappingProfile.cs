using AutoMapper;

using Domain;
using App.DtoUsers;
using App.Dto.Proposal;
using App.Dto.Company;
using App.Dto.Scheduler;
using App.Dto.Users;

namespace AutoMapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Company, CompanyResponseBasicDto>();
            CreateMap<Company, CompanyCitiesResponseDto>();
            CreateMap<SchedulerRequestDto, Scheduler>();
            CreateMap<Scheduler, SchedulerResponseDto>();
           
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
