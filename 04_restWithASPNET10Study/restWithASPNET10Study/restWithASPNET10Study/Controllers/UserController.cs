using Microsoft.AspNetCore.Mvc;
using restWithASPNET10Study.Data.Dto;
using restWithASPNET10Study.Model;
using restWithASPNET10Study.Services;

namespace restWithASPNET10Study.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all users");
            return Ok(_userService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            _logger.LogInformation("Getting user with ID: {id}", id);
            var user = _userService.FindById(id);
            if (user == null)
            {
                _logger.LogError("User with ID: {id} not found", id);
                return NotFound();
            }
            _logger.LogInformation("User with ID: {id} found", id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsersDto user)
        {
            _logger.LogInformation("Create user: {firstName}", user.FirstName);
            return Ok(_userService.Create(user));
        }

        [HttpPut]
        public IActionResult Put([FromBody] UsersDto user)
        {
            _logger.LogInformation("Update User with id: {Id}", user.Id);
            var updatedUser = _userService.Update(user);
            if (updatedUser == null) { 
                _logger.LogError("User with ID: {id} not found for update", user.Id);
                return NotFound(); }
            _logger.LogInformation("User with ID: {id} updated successfully", user.Id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete user with ID: {id}", id);
            var user = _userService.FindById(id);
            if (user == null) { 
                _logger.LogError("User with ID: {id} not found for deletion", id);
                return NotFound(); }
            _userService.Delete(id);
            _logger.LogInformation("User with ID: {id} deleted successfully", id);
            return NoContent();
        }
    }
}
