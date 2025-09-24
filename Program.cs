// Adicionando os 'usings' necessários para o DbContext e o SQL Server
using Microsoft.EntityFrameworkCore;
using SistemaVendaVeiculos.Data;

var builder = WebApplication.CreateBuilder(args);

// --- Início da Adição ---
// 1. Pegar a string de conexão do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Adicionar o DbContext ao contêiner de serviços da aplicação.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// --- Fim da Adição ---

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();