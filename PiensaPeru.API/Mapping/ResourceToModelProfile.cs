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
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonResource, Person>();
            CreateMap<SavePostResource, Post>();
            CreateMap<SaveQuizResource, Quiz>();
            CreateMap<SaveQuestionResource, Question>();
            CreateMap<SaveOptionResource, Option>();
            CreateMap<SaveSupervisorResource, Supervisor>();
            CreateMap<SaveImageResource, Image>();
            CreateMap<SaveParagraphResource, Paragraph>();
            CreateMap<SavePercentageDataResource, PercentageData>();
            CreateMap<SaveContentResource, Content>();
            CreateMap<SaveAdministratorResource, Administrator>();
            CreateMap<SaveManagementResource, Management>();
            CreateMap<SavePlanResource, Plan>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveCalificationResource, Calification>();
            CreateMap<SaveMilitantResource, Militant>();
            CreateMap<SaveMilitantContentResource, MilitantContent>();
            CreateMap<SavePoliticalPartyResource, PoliticalParty>();
            CreateMap<SavePeriodResource, Period>();
        }
    }
}
