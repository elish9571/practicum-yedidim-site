using Server.Core.Repositories;
using Server.Core.Services;


namespace Server.Service
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public bool IsAdmin(string name, string password)
        {
            return _adminRepository.IsAdmin(name, password);
        }
    }
}
