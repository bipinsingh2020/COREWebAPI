using COREWebAPI;
using COREWebAPI.Repositories;
using COREWebAPI.Services;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactClient",
        policy => policy
            .WithOrigins("https://localhost:56722") // React dev server
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Add services to the container11.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

//Register Dependency
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWeatherForecastService,WeatherForecastService>();

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
//end 

var app = builder.Build();

app.UseCors("AllowReactClient");

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
