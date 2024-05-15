using Server.Core.Models;

namespace Server.API.Models
{
    public class EmployeeJobPositionPostModel
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public bool IsManagementRole { get; set; }
    }
}
