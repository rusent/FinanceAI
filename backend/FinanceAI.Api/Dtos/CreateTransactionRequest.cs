using FinanceAI.Entities;

namespace FinanceAI.Api.Dtos;

public class CreateTransactionRequest
{
    public decimal Amount { get; set; }

    public string Currency { get; set; } = "TRY";

    public string Description { get; set; } = string.Empty;

    public TransactionType Type { get; set; }
}
