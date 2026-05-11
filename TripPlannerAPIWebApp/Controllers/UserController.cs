using Microsoft.AspNetCore.Mvc;
using TripPlannerAPI.Data;
using TripPlannerAPI.Models;

namespace TripPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly TripPlannerContext _context;

        public UsersController(TripPlannerContext context)
        {
            _context = context;
        }

        // Цей метод миттєво змусить базу створити таблиці
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }
    }
}