using FinanceAI.Business.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;

namespace FinanceAI.IntegrationTests;

public class ExceptionHandlingTests
{
    [Fact]
    public async Task GetTransaction_WhenIdDoesNotExist_ReturnsNotFound()
    {
        await using var factory = new WebApplicationFactory<Program>();
        using var client = factory.CreateClient();

        var id = Guid.NewGuid();

        var response = await client.GetAsync($"/api/Transactions/{id}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task UnhandledException_Returns500WithProblemDetails()
    {
        await using var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll<ITransactionService>();

                    services.AddScoped<ITransactionService>(_ =>
                        throw new InvalidOperationException(
                            "Integration test exception"));
                });
            });

        using var client = factory.CreateClient();

        var response = await client.GetAsync("/api/Transactions");

        Assert.Equal(
            HttpStatusCode.InternalServerError,
            response.StatusCode);

        Assert.Equal(
            "application/problem+json",
            response.Content.Headers.ContentType?.MediaType);
    }

}