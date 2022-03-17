using Microsoft.EntityFrameworkCore;
using RestAPINoleggi.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Aggiunto DbContext
builder.Services.AddDbContext<NoleggiContext>(options => {
    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Aggiunto il servizio per la repository di SQLServer
builder.Services.AddScoped<ISQLServerNoleggiRepository, SQLServerNoleggiRepository>();

builder.Services.AddEndpointsApiExplorer();

// Aggiunto automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
