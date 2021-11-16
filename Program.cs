var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Asim");
app.MapGet("/test", () => "Test 1,2");

app.MapGet("/get", () => "Status 200 OK");

app.MapPost("/post", () => "I'm Posted");
//Todo create a db to store the test posts and puts will have to make a GET to post and post to a GET




app.Run();
public class PostMaynia
{
    //Todo: Think about how you need to format your model
    public string Json { get; set; } = String.Empty;
}