
using FinanceAI.Api.Dtos;
using FinanceAI.Business.Interfaces;
using FinanceAI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceAI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(
    ITransactionService transactionService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Transaction>>> GetAll(
        CancellationToken cancellationToken)
    {
        var transactions =
            await transactionService.GetAllAsync(cancellationToken);

        return Ok(transactions);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Transaction>> GetById(
        Guid id,
        CancellationToken cancellationToken)
    {
        var transaction =
            await transactionService.GetByIdAsync(id, cancellationToken);

        if (transaction is null)
            return NotFound();

        return Ok(transaction);
    }

    [HttpPost]
    public async Task<ActionResult> Create(
        [FromBody] CreateTransactionRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Amount <= 0)
            return BadRequest("Amount must be greater than zero.");

        var transaction = new Transaction
        {
            Id = Guid.NewGuid(),
            Amount = request.Amount,
            Currency = request.Currency,
            Description = request.Description,
            TransactionDate = DateTime.UtcNow,
            Type = request.Type
        };

        var id = await transactionService.CreateAsync(
            transaction, cancellationToken);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new { id });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken)
    {
        var deleted =
            await transactionService.DeleteAsync(id, cancellationToken);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
