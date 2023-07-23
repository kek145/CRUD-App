using System.Threading.Tasks;
using CRUD.BL.Interfaces;
using CRUD.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public async Task<IActionResult> CreateNewUser(UserEntity entity)
        {
            var user = await _userService.CreateNewUserAsync(entity);
            return Ok(new { user });
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null!)
                return NotFound("Users is not found!");

            return Ok(users);
        }

        [HttpGet]
        [Route("GetUserById/{userId:int}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null!)
                return NotFound("User is not found");
            return Ok(user);
        }

        [HttpPut]
        [Route("UpdateUser/{userId:int}")]
        public async Task<IActionResult> UpdateUser(UserEntity entity, int userId)
        {
            var user = await _userService.UpdateUserAsync(entity, userId);
            return Ok(new { user });
        }

        [HttpDelete]
        [Route("DeleteUser/{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            return NoContent();
        }

    }
}