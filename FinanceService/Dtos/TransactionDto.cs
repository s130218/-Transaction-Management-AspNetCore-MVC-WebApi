using FinanceService.Models;

namespace FinanceService.Dtos;

public class TransactionLogsDto
{
    public Guid TransactionId { get; set; }
    public decimal Amount { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime TransactionDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}


public class TransactionCreateDto
{
    public Guid TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string AccountNumber { get; set; }
    public TransactionStatus Status { get; set; }
    public DateTime TransactionDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
}
