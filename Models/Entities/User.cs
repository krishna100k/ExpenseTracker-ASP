using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; } 
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public ICollection<Expense>? Expenses { get; set; }
    }
}
