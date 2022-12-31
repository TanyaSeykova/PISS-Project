using Microsoft.EntityFrameworkCore;
using RWM.API;
using RWM.Data.Data;
using RWM.Services;
using RWM.Services.Contracts;



var builder = WebApplication.CreateBuilder(args);

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = "";
if (dbHost != null || dbName != null || dbPassword != null)
{
    connectionString = $"Data Source={dbHost}; Initial Catalog={dbName};User ID=sa;Password={dbPassword};Trust Server Certificate=true";
}
else
{
    connectionString = builder.Configuration["ConnectionString"];
}
builder.Services.AddDbContext<RWMDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IBookJsonReader, BookJsonReader>();
builder.Services.AddScoped<IInitialisor, Initialisor>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<RWMDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }

    var iniialisor = services.GetRequiredService<IInitialisor>();
    iniialisor.Initialise();
}

app.Run();
