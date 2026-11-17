using FinanceAI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceAI.DataAccess.Contexts;

public class FinanceAIDbContext(DbContextOptions<FinanceAIDbContext> options)
    : DbContext(options)
{
    public DbSet<Transaction> Transactions => Set<Transaction>();
}
