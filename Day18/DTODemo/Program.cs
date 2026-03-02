using DtoDemo.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(UserMappingProfile));

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();