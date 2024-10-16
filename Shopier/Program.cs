using BusinessLayer.Concrete;
using BusinessLogicLayer.Concreate;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Configuration için appsettings.json'u baðla
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Shopier")));
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




builder.Services.AddScoped<IOrderDal, EfOrderRepository>();
builder.Services.AddScoped<IProductDal, EfProductRepository>();
builder.Services.AddScoped<ISellerDal, EfSellerRepository>();

// Manager'larý DI'ya ekleyin
builder.Services.AddScoped<OrderManager>();
builder.Services.AddScoped<ProductManager>();
builder.Services.AddScoped<SellerManager>();

