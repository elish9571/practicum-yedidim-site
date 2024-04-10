namespace Server.API.Models
{
    public class JobPositionPostModel
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public bool IsManagementRole { get; set; }
    }
}
