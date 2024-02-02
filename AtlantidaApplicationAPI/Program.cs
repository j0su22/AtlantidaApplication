using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AtlantidaApplicationAPI.Services;
using AtlantidaApplicationAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Conection to Data Base
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
builder.Services.AddTransient<IService_AGENCIA, AGENCIA_Service>();
builder.Services.AddTransient<IService_CARGO, CARGO_Service>();
builder.Services.AddTransient<IService_CLIENTEXPRODUCTO, CLIENTEXPRODUCTO_Service>();
builder.Services.AddTransient<IService_EJECUTIVO, EJECUTIVO_Service>();
builder.Services.AddTransient<IService_PERSONA, PERSONA_Service>();
builder.Services.AddTransient<IService_PRODUCTO, PRODUCTO_Service>();
builder.Services.AddTransient<IService_TIPOTRANSACCION, TIPOTRANSACCION_Service>();
builder.Services.AddTransient<IService_TRANSACCION, TRANSACCION_Service>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
