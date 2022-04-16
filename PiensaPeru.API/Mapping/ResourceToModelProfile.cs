using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Resources;

namespace PiensaPeru.API.Mapping
{
    public class ResourceToModelProfile : AutoMapper.Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SavePersonResource, Person>();

            CreateMap<SaveSupervisorResource, Supervisor>();
            CreateMap<SaveImageResource, Image>();
            CreateMap<SaveDataTypeResource, DataType>();
            CreateMap<SaveParagraphResource, Paragraph>();
            CreateMap<SavePercentageDataResource, PercentageData>();
            CreateMap<SavePostTypeResource, PostType>();
            CreateMap<SaveContentResource, Content>();
        }
    }
}
