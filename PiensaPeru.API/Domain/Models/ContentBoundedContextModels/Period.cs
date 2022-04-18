namespace PiensaPeru.API.Domain.Models.ContentBoundedContextModels
{
    public class Period
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public string? OriginOfCharge { get; set; }
        public MilitantContent MilitantContent { get; set; }
    }
}
