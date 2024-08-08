using Expense_Tracker.Data;
using Expense_Tracker.Models;
using Expense_Tracker.Models.Entities;
using Expense_Tracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var email = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if(email != null)
                {
                    return BadRequest(new { Message = "User Already Exists" });
                }
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
                var user = new User
                {
                    UserId = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Password = passwordHash
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(new {Message = "User registered successfully"});
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if(user == null)
                {
                    return BadRequest(new { Message = "User does not exists."});
                }

                bool password = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);
                if (!password)
                {
                    return BadRequest(new {Message = "Invalid password."});
                }
                JwtTokenService jwt = new JwtTokenService(_configuration);
                string token = jwt.GenerateToken(user.Name);
                return Ok(new { Message = "User logged in successfully!!!", Token = token});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
