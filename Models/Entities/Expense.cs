using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models.Entities
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required string ExpenseId { get; set; }
        public required string ExpenseName { get; set; }
        public required decimal ExpenseAmount { get; set; }

        [ForeignKey("User")]
        public string? UserId;
        public User? User { get; set; }
    }
}
