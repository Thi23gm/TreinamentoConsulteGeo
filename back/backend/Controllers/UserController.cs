using backend.Data;
using backend.Models;
using backend.Repos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDatabaseContext _dbContext;

        public UserController(MyDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> getAllUsers()
        {
            return Ok(_dbContext.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> addUser([FromBody] UserModel newUser)
        {
            if (newUser == null)
            {
                return BadRequest("User data is null.");
            }

            UserModel u = new UserModel();
            u.isActive = newUser.isActive;
            u.name = newUser.name;
            u.eyeColor = newUser.eyeColor;
            u.age = newUser.age;

            _dbContext.Users.Add(u);
            _dbContext.SaveChanges();

            return Ok(u);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> editUser(int id, [FromBody] UserModel updatedUser)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            // Atualiza apenas os campos necessários
            user.isActive = updatedUser.isActive;
            user.name = updatedUser.name;
            user.eyeColor = updatedUser.eyeColor;
            user.age = updatedUser.age;

            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return Ok($"User with ID {id} is deleted successfully.");
        }

    }
}
