namespace PiensaPeru.API.Domain.Models.AdministratorBoundedContextModels
{
    public class Administrator : Person
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Management>? Managements { get; set; }
    }
}
