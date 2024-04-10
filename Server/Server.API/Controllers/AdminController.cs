using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Core.Repositories;
using Server.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        // GET api/<AdminController>/{name},{password}
        [HttpGet]
        public ActionResult GetAdmin(string name, string password)
        {
            var admin = _adminService.IsAdmin(name, password);
            return Ok(admin);
        }

    }
}
