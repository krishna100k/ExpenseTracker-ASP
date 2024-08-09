using Expense_Tracker.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Lending> Lendings { get; set; }

    }
}
