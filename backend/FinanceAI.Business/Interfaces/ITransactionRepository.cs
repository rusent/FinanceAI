
using FinanceAI.Entities;

namespace FinanceAI.Business.Interfaces;

public interface ITransactionRepository
{
    Task<IReadOnlyList<Transaction>> GetAllAsync(
        CancellationToken cancellationToken = default);

    Task<Transaction?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task AddAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default);
}
