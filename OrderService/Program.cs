var builder = WebApplication.CreateBuilder(args);

// 👇 AGREGAR ESTO
builder.Services.AddControllers();

var app = builder.Build();

// 👇 AGREGAR ESTO
app.MapControllers();

app.MapGet("/", () => "Service is running");

app.Run();