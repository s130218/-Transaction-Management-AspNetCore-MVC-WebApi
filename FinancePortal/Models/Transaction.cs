using FinancePortal.Enum;

namespace FinancePortal.Models;

public class Transaction
{
    public int Id { get; set; }
    public Guid TransactionId { get; set; }
    public string AccountNumber { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime TransactionDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}
