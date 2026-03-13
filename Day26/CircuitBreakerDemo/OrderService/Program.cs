using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("paymentClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5151");
})
.AddPolicyHandler(HttpPolicyExtensions
    .HandleTransientHttpError()
    .CircuitBreakerAsync(
        handledEventsAllowedBeforeBreaking: 3,
        durationOfBreak: TimeSpan.FromSeconds(20)
    ));

var app = builder.Build();

app.MapGet("/order", async (IHttpClientFactory factory) =>
{
    var client = factory.CreateClient("paymentClient");

    try
    {
        var response = await client.GetAsync("/payment");

        if (!response.IsSuccessStatusCode)
        {
            return Results.Ok("Payment Failed");
        }

        var result = await response.Content.ReadAsStringAsync();
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        return Results.Ok("Fallback: Payment service unavailable");
    }
});

app.Run();