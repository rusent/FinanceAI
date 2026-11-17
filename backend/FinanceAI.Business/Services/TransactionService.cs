
using FinanceAI.Business.Interfaces;
using FinanceAI.Entities;

namespace FinanceAI.Business.Services;

public class TransactionService(
    ITransactionRepository repository) : ITransactionService
{
    public Task<IReadOnlyList<Transaction>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return repository.GetAllAsync(cancellationToken);
    }

    public Task<Transaction?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return repository.GetByIdAsync(id, cancellationToken);
    }

    public async Task<Guid> CreateAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(transaction);

        if (transaction.Amount <= 0)
        {
            throw new ArgumentException(
                "Transaction amount must be greater than zero.");
        }

        await repository.AddAsync(transaction, cancellationToken);

        return transaction.Id;
    }

    public Task<bool> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return repository.DeleteAsync(id, cancellationToken);
    }
}
