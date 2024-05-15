using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public DateTime BeginningOfWork { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsMale { get; set; }
        public List<EmployeeJobPositionDto> JobPositions { get; set; }
    }
}
