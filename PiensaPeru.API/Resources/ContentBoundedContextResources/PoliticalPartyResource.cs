namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class PoliticalPartyResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PresidentName { get; set; }
        public DateTime FoundationDate { get; set; }
        public string Ideology { get; set; }
        public string Position { get; set; }
        public string PictureLink { get; set; }
    }
}
