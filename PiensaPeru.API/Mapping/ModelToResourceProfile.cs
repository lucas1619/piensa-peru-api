using PiensaPeru.API.Domain.Models;
using PiensaPeru.API.Resources;

namespace PiensaPeru.API.Mapping
{
    public class ModelToResourceProfile : AutoMapper.Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Person, PersonResource>();

            CreateMap<Supervisor, SupervisorResource>();
        }
    }
}
