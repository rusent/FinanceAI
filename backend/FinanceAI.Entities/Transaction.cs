
namespace FinanceAI.Entities;

public class Transaction
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "TRY";

    public string Description { get; set; } = string.Empty;

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public TransactionType Type { get; set; }
}

public enum TransactionType
{
    Income = 1,
    Expense = 2
}
