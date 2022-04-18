using PiensaPeru.API.Domain.Models.ContentBoundedContextModels;

namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class MilitantResource : PersonResource
    {
        public DateTime BirthDate { get; set; }
        public string? BirthPlace { get; set; }
        public string? Profession { get; set; }
        public int PolitcalPartyId { get; set; }
        public string? PictureLink { get; set; }
        public bool IsPresident { get; set; }
        public int MilitantTypeId { get; set; }
        public MilitantType militantType { get; set; }
    }
}
