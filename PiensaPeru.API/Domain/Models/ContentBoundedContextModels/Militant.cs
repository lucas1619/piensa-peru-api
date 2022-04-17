namespace PiensaPeru.API.Domain.Models.ContentBoundedContextModels
{
    public class Militant : Person
    {
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string? BirthPlace { get; set; }
        public string? Profession { get; set; }
        public int PolitcalPartyId { get; set; }
        public string? PictureLink { get; set; }
        public bool IsPresident { get; set; }
        public int MilitantTypeId { get; set; }
        public MilitantType MilitantType { get; set; }
        public PoliticalParty PoliticalParty { get; set; }
        public ICollection<MilitantContent>? MilitantContents { get; set; }
    }
}
