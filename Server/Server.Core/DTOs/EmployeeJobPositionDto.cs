using Server.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.DTOs
{
    public class EmployeeJobPositionDto
    {       
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public bool IsManagementRole { get; set; }
    }
}
