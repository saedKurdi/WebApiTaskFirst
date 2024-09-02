using aspTask10WebApi.DAL.Abstract;
using aspTask10WebApi.DAL.Concrete;
using aspTask10WebApi.Data;
using aspTask10WebApi.Services.Abstract;
using aspTask10WebApi.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// injecting DB : 
var conn = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ECommerceDBContext>(opt => {
    opt.UseSqlServer(conn)
    .UseLazyLoadingProxies();
});

// injecting DAL's : 
builder.Services.AddScoped<ICustomerDal,EFCustomerDal>();
builder.Services.AddScoped<IOrderDal,EFOrderDal>();
builder.Services.AddScoped<IProductDal,EFProductDal>();

// injecting services : 
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<IProductService,ProductService>();

// building app : 
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
