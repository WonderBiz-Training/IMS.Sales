using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Sales.Application.Commands;
using Sales.Application.Interfaces;
using Sales.Application.Queries;
using Sales.Application.Services;
using Sales.Application.Validators;
using Sales.Infrastructure.Data;
using Sales.Infrastructure.Interface;
using Sales.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var configuration = builder.Configuration;

var conn = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SaleDbContext>(option => option.UseSqlServer(conn,b => b.MigrationsAssembly("Sales.Api")));

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SaleValidators>());
builder.Services.AddControllers().AddFluentValidation(sp => sp.RegisterValidatorsFromAssemblyContaining<SaleProductValidators>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateSaleProductCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateSaleProductCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteSaleProductCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllSaleProductQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetSaleProductByIdQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateSalesCommand).Assembly));

builder.Services.AddScoped<ISaleProductRepository, SaleProductRepository>();
builder.Services.AddScoped<ISaleProductServices, SaleProductServices>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ISalesServices, SalesServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
