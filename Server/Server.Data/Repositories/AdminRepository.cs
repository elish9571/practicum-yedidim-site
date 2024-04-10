using Server.Core.Repositories;

namespace Server.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepository(DataContext context)
        {
            _context = context;
        }

        public bool IsAdmin(string name, string password)
        {
            // Example: Check if the provided credentials match an admin record in the database
            return _context.Admin.Any(a => a.Name == name && a.Password == password);
        }
    }
}
