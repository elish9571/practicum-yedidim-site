using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Server.Core.Services
{
    public interface IAdminService
    {
        bool IsAdmin(string name, string password);
    }
}
