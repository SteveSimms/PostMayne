var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Asim");
app.MapGet("/test", () => "Test 1,2");

app.Run();
