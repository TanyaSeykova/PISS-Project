using Microsoft.EntityFrameworkCore;
using RWM.Data.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = $"Data Source=localhost, 1433; Initial Catalog=Testing;User ID=sa;Password=1234!!PasswordD;Trust Server Certificate=true";
builder.Services.AddDbContext<RWMDbContext>(options =>
    options.UseSqlServer(connectionString));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
