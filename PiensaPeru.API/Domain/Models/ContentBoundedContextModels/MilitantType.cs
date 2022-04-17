namespace PiensaPeru.API.Domain.Models.ContentBoundedContextModels
{
    public class MilitantType
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public ICollection<Militant>? Militants { get; set; }
    }
}
