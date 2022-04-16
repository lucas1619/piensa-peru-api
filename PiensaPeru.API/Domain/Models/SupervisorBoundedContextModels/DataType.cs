namespace PiensaPeru.API.Domain.Models
{
    public class DataType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<PercentageData>? PercentagesData { get; set; }

    }
}
