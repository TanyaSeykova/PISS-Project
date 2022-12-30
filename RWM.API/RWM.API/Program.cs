using Microsoft.EntityFrameworkCore;
using RWM.API;
using RWM.Data.Data;
using RWM.Services;
using RWM.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RWMDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionString"]));
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
