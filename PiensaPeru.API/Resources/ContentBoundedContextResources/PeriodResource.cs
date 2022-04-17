namespace PiensaPeru.API.Resources.ContentBoundedContextResources
{
    public class PeriodResource
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? OriginOfCharge { get; set; }
    }
}
