using DeLeeghteAPI.Applicatie.Interfaces;
using DeLeeghteAPI.Applicatie.Repositories;
using DeLeeghteAPI.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

services.RegisterServices(builder.Services, connectionString);
builder.Services.AddScoped<IUuidRepository, UuidRepository>();
builder.Services.AddScoped<IWedstrijdRepository, WedstrijdRepository>();
builder.Services.AddScoped<IInschrijvingRepository, InschrijvingenRepository>();
builder.Services.AddScoped<IWegingRepository, WegingRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://0.0.0.0:5000");


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
