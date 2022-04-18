using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Models.UserBoundedContextModels;
using PiensaPeru.API.Resources;
using PiensaPeru.API.Resources.AdministratorBoundedContextResources;
using PiensaPeru.API.Resources.UserBoundedContextResources;

namespace PiensaPeru.API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();
            CreateMap<Post, PostResource>();
            CreateMap<Quiz, QuizResource>();
            CreateMap<Question, QuestionResource>();
            CreateMap<Option, OptionResource>();
            CreateMap<Supervisor, SupervisorResource>();
            CreateMap<Image, ImageResource>();
            CreateMap<Paragraph, ParagraphResource>();
            CreateMap<PercentageData, PercentageDataResource>();
            CreateMap<Content, ContentResource>();
            CreateMap<Administrator, AdministratorResource>();
            CreateMap<Management, ManagementResource>();
            CreateMap<Plan, PlanResource>();
            CreateMap<User, UserResource>();
            CreateMap<Calification, CalificationResource>();
        }
    }
}
