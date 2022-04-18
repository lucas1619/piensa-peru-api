namespace PiensaPeru.API.Resources.AdministratorBoundedContextResources
{
    public class AdministratorResource : PersonResource
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
