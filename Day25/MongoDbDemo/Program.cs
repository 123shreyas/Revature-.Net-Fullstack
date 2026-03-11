using MongoDbDemo.Models;
using MongoDbDemo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<BookStoreDatabaseSettings>(
    builder.Configuration.GetSection("BookStoreDatabase"));

builder.Services.AddSingleton<BooksService>();

builder.Services.AddControllers()
.AddJsonOptions(options =>
    options.JsonSerializerOptions.PropertyNamingPolicy = null);

var app = builder.Build();

app.MapControllers();

app.Run();