using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;
using PiensaPeru.API.Resources;
using PiensaPeru.API.Resources.ContentBoundedContextResources;

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
            CreateMap<DataType, DataTypeResource>();
            CreateMap<Paragraph, ParagraphResource>();
            CreateMap<PercentageData, PercentageDataResource>();
            CreateMap<PostType, PostTypeResource>();
            CreateMap<Content, ContentResource>();
            CreateMap<Militant, MilitantResource>();
            CreateMap<MilitantContent, MilitantContentResource>();
            CreateMap<PoliticalParty, PoliticalPartyResource>();
            CreateMap<Period, PeriodResource>();
            
        }
    }
}
