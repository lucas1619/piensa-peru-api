namespace PiensaPeru.API.Domain.Models.ContentBoundedContextModels
{
    public class MilitantContent
    {
        public int MilitantId { get; set; }
        public int ContentId { get; set; }
        public int PeriodId { get; set; }
        public Militant Militant { get; set; }
        public Content Content { get; set; }
        public Period Period { get; set; }
    }
}
