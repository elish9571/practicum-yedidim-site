namespace Server.Core.Models
{
    public class JobPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public bool IsManagementRole { get; set; }

   //     public List<Employee> Employees { get; set; }

    }
}
