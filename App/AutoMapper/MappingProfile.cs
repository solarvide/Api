using AutoMapper;

using Domain;
using App.DtoUsers;
using App.Dto.Proposal;
using App.Dto.Company;
using App.Dto.Scheduler;
using App.Dto.Users;
using APP.Dto.FAQ;
using App.Dto.Blog;
using App.Dto.Cities;
using App.Dto.CategoryBlog;
using App.Dto.Notification;

namespace AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Blog, BlogListResponseDto>();

            CreateMap<CategoryBlog, CategoryBlogResponseDto>();
            CreateMap<Cities, CitiesResponseDto>();
            CreateMap<Cities, CitiesResponseDto>();
            CreateMap<Company, CompanyResponseBasicDto>();
            CreateMap<Company, CompanyCitiesResponseDto>();

            CreateMap<FAQ, FAQListResponseDto>();
            CreateMap<FAQDefaultRequestDto, FAQ>();

            CreateMap<Notification, NotificationListResponseDto>();

            CreateMap<ProposalResponseDto, Proposal>();
            CreateMap<Proposal, ProposalResponseDto>();

            CreateMap<SchedulerRequestDto, Scheduler>();
            CreateMap<Scheduler, SchedulerResponseDto>();

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
