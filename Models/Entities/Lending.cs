using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models.Entities
{
    public class Lending
    {
        [Key]
        public Guid LendingId { get; set; }
        public required string LendersName { get; set; }
        public required string LentAmount { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }

    }
}
