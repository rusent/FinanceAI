
using FinanceAI.Business.Interfaces;
using FinanceAI.DataAccess.Contexts;
using FinanceAI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceAI.DataAccess.Repositories;

public class TransactionRepository(FinanceAIDbContext dbContext)
    : ITransactionRepository
{
    public async Task<IReadOnlyList<Transaction>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Transactions
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task<Transaction?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(
                transaction => transaction.Id == id,
                cancellationToken);
    }

    public async Task AddAsync(
        Transaction transaction,
        CancellationToken cancellationToken = default)
    {
        await dbContext.Transactions.AddAsync(transaction, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> DeleteAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        var transaction = await dbContext.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(
                transaction => transaction.Id == id,
                cancellationToken);

        if (transaction is null)
            return false;

        dbContext.Transactions.Remove(transaction);
        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
