using Devlivery.Api;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuracao = builder.Configuration;
IServiceCollection servicos = builder.Services;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Startup startup = new Startup(configuracao, servicos);

servicos = Startup.ConfiguraServicos();
servicos.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddControllers();
servicos.BuildServiceProvider();


var app = builder.Build();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new Weatherforecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("Weatherforecast")
.WithOpenApi();
startup.Configure(app, app.Environment);
app.Run();

record Weatherforecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


/*
 * /Startup.ConfiguraServicos().BuildServiceProvider()/.GetService(typeof(IServiceProvider));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//services.ConfigureServices(builder.Services);
//services?.BuildServiceProvider();
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var startup = new Startup();
var services = Startup.ConfiguraServicos();
services.BuildServiceProvider();

//builder.UseStartup<Startup>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.MapIdentityApi<Usuario>();
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};
 
  
 
 */
/*
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

