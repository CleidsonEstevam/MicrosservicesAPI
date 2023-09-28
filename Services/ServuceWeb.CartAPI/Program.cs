using Microsoft.EntityFrameworkCore;
using ServuceWeb.CartAPI.Model.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();

var connection = builder.Configuration["MySQlConnection:MySQlConnectionString"];

builder.Services.AddDbContext<MySqlCartContext>(options => options.
    UseMySql("Server=localhost;DataBase=service_cart_api;Uid=root;Pwd=admin",
            new MySqlServerVersion(
                new Version(8, 0, 5))));

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
