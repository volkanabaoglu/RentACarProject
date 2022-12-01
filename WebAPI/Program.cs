using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ICarService, CarManger>();
builder.Services.AddSingleton<ICarDal,EfCarDal>();

builder.Services.AddSingleton<ICustomerService,CustomerManager>();
builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddSingleton<IUserDal,EfUserDal>();

builder.Services.AddSingleton<IRentalService, RentalsManager>();
builder.Services.AddSingleton<IRentalsDal, EfRentalsDal>();

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
