﻿using RealEstate_Dapper_Api.Extension;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.CustomServicesCollection();
//builder.Services.AddTransient<Context>();
//builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.CustomServicesCollection();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Servisleri extension metodu ile ekle ve bağlantı dizesini geç
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
