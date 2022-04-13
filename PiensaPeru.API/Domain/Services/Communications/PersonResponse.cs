using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Domain.Services.Communications
{
    public class PersonResponse : BaseResponse<Person>
    {
        public PersonResponse(Person resource) : base(resource)
        {
        }

        public PersonResponse(string message) : base(message)
        {
        }
    }
}
