namespace PiensaPeru.API.Resources.AdministratorBoundedContextResources
{
    public class ManagementResource
    {
        public int Id { get; set; }
        public DateTime SystemUpgrade { get; set; }
        public int ManagementTypeId { get; set; }
        public int AdministratorId { get; set; }
        public int ContentId { get; set; }
    }
}
