using FinanceService.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceService.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<TransactionLogs> TransactionLogs { get; set; }
    public DbSet<AccountBalance> AccountBalances { get; set; }
}
