namespace Server.API.Models
{
    public class JobPositionPostModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public bool IsManagementRole { get; set; }
    }
}
