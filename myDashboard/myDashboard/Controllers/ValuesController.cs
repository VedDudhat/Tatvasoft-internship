using Microsoft.AspNetCore.Mvc;
using myDashboard.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserDashboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> Users = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john@example.com", Role = "Admin" },
            new User { Id = 2, Name = "Jane Smith", Email = "jane@example.com", Role = "User" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            user.Id = Users.Max(u => u.Id) + 1;
            Users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Role = updatedUser.Role;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            Users.Remove(user);
            return NoContent();
        }
       
    }
}
