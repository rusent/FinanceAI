
using FinanceAI.Entities;
using System.ComponentModel.DataAnnotations;

namespace FinanceAI.Api.Dtos;

public class CreateTransactionRequest
{
    [Range(typeof(decimal), "0.01", "999999999999.99",
        ErrorMessage = "Amount must be greater than zero.")]
    public decimal Amount { get; set; }

    [Required]
    [RegularExpression("^[A-Z]{3}$",
        ErrorMessage = "Currency must be a three-letter uppercase code.")]
    public string Currency { get; set; } = "TRY";

    [Required]
    [StringLength(250, MinimumLength = 1)]
    public string Description { get; set; } = string.Empty;

    [EnumDataType(typeof(TransactionType))]
    public TransactionType Type { get; set; }
}
