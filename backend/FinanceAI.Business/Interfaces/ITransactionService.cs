
using FinanceAI.Entities;

namespace FinanceAI.Business.Interfaces;

public interface ITransactionService
{
    Task<IReadOnlyList<Transaction>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Transaction?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Guid> CreateAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}
