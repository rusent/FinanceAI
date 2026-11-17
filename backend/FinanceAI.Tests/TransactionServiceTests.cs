using FinanceAI.Business.Interfaces;
using FinanceAI.Business.Services;
using FinanceAI.Entities;
using Moq;

namespace FinanceAI.Tests;

public class TransactionServiceTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    public async Task CreateAsync_WhenAmountIsNotPositive_ThrowsArgumentException(
        int amount)
    {
        // Arrange
        var repositoryMock = new Mock<ITransactionRepository>();
        var service = new TransactionService(repositoryMock.Object);

        var transaction = new Transaction
        {
            Amount = amount,
            Currency = "TRY",
            Description = "Test transaction",
            Type = TransactionType.Expense
        };

        // Act
        var exception = await Assert.ThrowsAsync<ArgumentException>(
            () => service.CreateAsync(transaction));

        // Assert
        Assert.Equal(
            "Transaction amount must be greater than zero.",
            exception.Message);

        repositoryMock.Verify(
            r => r.AddAsync(
                It.IsAny<Transaction>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task CreateAsync_WhenAmountIsPositive_ReturnsTransactionId()
    {
        // Arrange
        var repositoryMock = new Mock<ITransactionRepository>();
        var service = new TransactionService(repositoryMock.Object);

        var transaction = new Transaction
        {
            Amount = 2500,
            Currency = "TRY",
            Description = "Monthly salary",
            Type = TransactionType.Income
        };

        // Act
        var result = await service.CreateAsync(transaction);

        // Assert
        Assert.Equal(transaction.Id, result);

        repositoryMock.Verify(
            r => r.AddAsync(
                transaction,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
}