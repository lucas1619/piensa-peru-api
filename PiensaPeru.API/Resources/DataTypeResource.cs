using PiensaPeru.API.Domain.Models;

namespace PiensaPeru.API.Resources
{
    public class DataTypeResource
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<PercentageData>? PercentagesData { get; set; }
    }
}
