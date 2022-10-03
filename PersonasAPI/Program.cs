using Microsoft.EntityFrameworkCore;
using PersonasAPI.BLL.Services;
using PersonasAPI.DAL.Data;
//using PersonasAPI.DAL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PersonasContext>(options => 
   options.UseSqlServer(builder.Configuration.GetConnectionString("dbConn")));

builder.Services.AddTransient<DocumentosService>();
builder.Services.AddTransient<PersonaService>();
builder.Services.AddTransient<GeneroService>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
