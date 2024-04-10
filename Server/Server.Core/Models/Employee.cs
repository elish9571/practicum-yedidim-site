namespace Server.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMale { get; set; }
        public DateTime BeginningOfWork { get; set; }
        public bool IsDeleted { get; set; }
        public List<JobPosition> JobPositions { get; set; }
    }
}
