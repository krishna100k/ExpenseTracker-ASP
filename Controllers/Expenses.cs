using Expense_Tracker.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class Expenses : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public Expenses(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddExpense")]
        public async Task<IActionResult> AddExpense()
        {
            try
            {
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

    }
}
