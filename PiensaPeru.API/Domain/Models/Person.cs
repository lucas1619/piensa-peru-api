namespace PiensaPeru.API.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public Supervisor? Supervisor { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
