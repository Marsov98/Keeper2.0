using Data;
using Service.Interfaces;
using Service.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<KeeperContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IStatementRepository, StatementRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOriginsWithCredentials",
        builder =>
        {
            builder
            .SetIsOriginAllowed(origin => true) // –азрешает запросы с любого источника
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials(); // –азрешает передачу учетных данных
        });
});


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

app.UseCors("AllowAllOriginsWithCredentials");

app.Run();
