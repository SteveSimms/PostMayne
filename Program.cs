using Postmizan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JsonContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();


app.MapGet("/", () => "Hello Asim");
app.MapGet("/test", () => "Test 1,2");

app.MapGet("/get", () => "Status 200 OK");

app.MapPost("/post", () => "I'm Posted");
//Todo create a db to store the test posts and puts will have to make a GET to post and post to a GET


var getJson = app.MapGet("/api/jsondatas", async(JsonContext db) => await db.JsonDatas.ToListAsync());

var postJson = app.MapPost("/api/jsondatas", async (JsonContext db, JsonData jsondata) =>
{
    await db.JsonDatas.AddAsync(jsondata);
    await db.SaveChangesAsync();
    Results.Accepted();
});

app.UseRouting();
//Use static files and MapFallBackToFile are critical to running spa(Vue/vite) server at the same time also these 2 functions are needed to serve the files in production 
app.UseStaticFiles();
app.MapFallbackToFile("index.html");
//app.UseHttpsRedirection("http://localhost:3000");




app.Run();

