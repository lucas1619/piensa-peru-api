namespace PiensaPeru.API.Domain.Models.ContentBoundedContextModels
{
    public class PoliticalParty
    { 
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PresidentName { get; set; }
        public DateTime FoundationDate { get; set; } = DateTime.Now;
        public string? Ideology { get; set; }
        public string? Position { get; set; }
        public string? PictureLink { get; set; }
        public ICollection<Militant>? Militants { get; set; }
    }
}
