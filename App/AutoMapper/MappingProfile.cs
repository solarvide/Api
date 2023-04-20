using AutoMapper;

using Domain;
using App.DtoUsers;
using App.Dto.Proposal;
using App.Dto.Company;
using App.Dto.Scheduler;
using App.Dto.Users;
using APP.Dto.FAQ;
using App.Dto.Blog;

namespace AutoMapper {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Company, CompanyResponseBasicDto>();
            CreateMap<Company, CompanyCitiesResponseDto>();
            CreateMap<SchedulerRequestDto, Scheduler>();
            CreateMap<Scheduler, SchedulerResponseDto>();
            CreateMap<FAQ, FAQListResponseDto>();
            CreateMap<FAQDefaultRequestDto, FAQ>();
            CreateMap<Blog, BlogListResponseDto>();
           
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
