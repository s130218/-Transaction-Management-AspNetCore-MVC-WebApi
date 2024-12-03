using FinancePortal.Enum;

namespace FinancePortal.Dtos
{
    public class TransactionResponseDto
    {
        public int Id { get; set; }
        public Guid TransactionId { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
