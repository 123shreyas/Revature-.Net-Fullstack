var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/payment", () =>
{
    var random = new Random();
    int number = random.Next(1, 5);

    if (number <= 3)
    {
        return Results.StatusCode(500);
    }

    return Results.Ok("Payment Successful");
});

app.Run();