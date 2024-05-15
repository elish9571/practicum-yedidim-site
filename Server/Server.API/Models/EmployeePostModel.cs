using Server.Core.Models;

namespace Server.API.Models
{
    public class EmployeePostModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime BeginningOfWork { get; set; }
        public bool IsMale { get; set; }
        public List<EmployeeJobPositionPostModel> JobPositions { get; set; }
    }
}
