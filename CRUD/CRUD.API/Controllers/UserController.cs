using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = new[]
            {
                new { Name = "Yurii" },
                new { Name = "Matvei" },
                new { Name = "Janna" }
            };
            return Ok(new { users = users });
        }
        
    }
}