using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceService.Models
{
    [Table("AccountBalances")]

    public class AccountBalance
    {
        public int Id { get; set; }                  
        public string AccountNumber { get; set; }    
        public decimal AvailableBalance { get; set; } 
        public DateTime LastUpdated { get; set; }
    }
}
