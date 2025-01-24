using DevFreela.API.ExceptionHandler;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//TotalCost Minimo e Maximo
builder.Services.Configure<FreelanceTotalCostConfig>(
    builder.Configuration.GetSection("FreelanceTotalCostConfig")
    );


//Testando os ciclos de Vidas (Injeção de Dependência)
builder.Services.AddScoped<IConfigService, ConfigService>();

//Configurando DbCOntext (Banco de Dados in Memory)
//builder.Services.AddDbContext<DevFreelaDbContext>(o => 
//o.UseInMemoryDatabase("DevFreelaDb"));

//Configurando DbCOntext (Banco de Dados no SQL)
var connectionString = builder.Configuration.GetConnectionString("DevFreelaCS");
builder.Services.AddDbContext<DevFreelaDbContext>(o =>
    o.UseSqlServer(connectionString));

//Testando Exceptions
builder.Services.AddExceptionHandler<ApiExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Exception
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
