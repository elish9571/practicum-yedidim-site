using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Core.Models
{
    public class EmployeeJobPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public bool IsManagementRole { get; set; }
        public bool IsActive { get; set;}
        public EmployeeJobPosition()
        {
            IsActive = true;
        }

    }
}
