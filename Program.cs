using Microsoft.EntityFrameworkCore;
using ParkyApplication.Data;
using ParkyApplication.Repository.IRepository;
using AutoMapper;
using ParkyApplication.Mappers;
using ParkyApplication.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("nationalParkApiSpec", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "National Park API",
        Version = "V1.0.0",
        Description = "Clearance Morumudi National Park Api for South Africa",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        {
            Email = "clearancemorumudi@outlook.com",
            Name = "Clearance Morumudi",
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("NationalParks")));

builder.Services.AddScoped<INationalParkRepository, NationalParkRepository>();
builder.Services.AddScoped<ITrailsRepository, TrailRepository>();
builder.Services.AddAutoMapper(typeof(NationalParkMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/nationalParkApiSpec/swagger.json", "National Park");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
