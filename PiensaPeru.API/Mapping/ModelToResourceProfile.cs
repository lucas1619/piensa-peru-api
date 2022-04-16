using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Resources;

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
        }
    }
}
