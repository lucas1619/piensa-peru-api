using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Models.UserBoundedContextModels;
using PiensaPeru.API.Resources;
using PiensaPeru.API.Resources.ContentBoundedContextResources;
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
            CreateMap<Post, PostTypeResource>();
            CreateMap<Quiz, QuizResource>();
            CreateMap<Question, QuestionResource>();
            CreateMap<Option, OptionResource>();
            CreateMap<Supervisor, SupervisorResource>();
            CreateMap<Image, ImageResource>();
            CreateMap<Paragraph, ParagraphResource>();
            CreateMap<PercentageData, PercentageDataResource>();
            CreateMap<Content, ContentResource>();
            CreateMap<Militant, MilitantResource>();
            CreateMap<MilitantContent, MilitantContentResource>();
            CreateMap<PoliticalParty, PoliticalPartyResource>();
            CreateMap<Period, PeriodResource>();
            CreateMap<Administrator, AdministratorResource>();
            CreateMap<Management, ManagementResource>();
            CreateMap<Plan, PlanResource>();
            CreateMap<User, UserResource>();
            CreateMap<Calification, CalificationResource>();
        }
    }
}
