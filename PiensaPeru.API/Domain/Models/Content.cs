using PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels;
using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Domain.Models
{
    public class Content
    {
        public int Id { get; set; }
        public bool Active { get; set; } = false;

        public ICollection<Post>? Posts { get; set; }
        public ICollection<MilitantContent>? MilitantContents { get; set; }
        public ICollection<Management>? Managements { get; set; }
        public ICollection<PercentageData>? PercentagesData { get; set; }
    }
}
