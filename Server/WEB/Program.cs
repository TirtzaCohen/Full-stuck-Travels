using BLL.Functions;
using BLL.Inretfaces;
using DAL.Functions;
using DAL.Interfaces;
using DAL.Travels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opotion => opotion.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));

builder.Services.AddControllers()
           .AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<TravelsContext>(
    a => a.UseSqlServer("תרצה\\SQLEXPRESS;Database=Travels;Trusted_Connection=True; TrustServerCertificate=True"));

builder.Services.AddScoped(typeof(IBookingPlaceDal), typeof(BookingPlaceDal));
builder.Services.AddScoped(typeof(IBookingPlaceBll), typeof(BookingPlaceBll));

builder.Services.AddScoped(typeof(ITravelTypeDal), typeof(TravelTypeDal));
builder.Services.AddScoped(typeof(ITravelTypeBll), typeof(TravelTypeBll));

builder.Services.AddScoped(typeof(ITripDal), typeof(TripDal));
builder.Services.AddScoped(typeof(ITripBll), typeof(TripBll));

builder.Services.AddScoped(typeof(IUserDal), typeof(UserDal));
builder.Services.AddScoped(typeof(IUserBll), typeof(UserBll));



var app = builder.Build();

app.UseCors("AllowAll");

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
