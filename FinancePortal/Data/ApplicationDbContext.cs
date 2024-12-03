using FinancePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancePortal.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Transaction> Transactions { get; set; }
}
