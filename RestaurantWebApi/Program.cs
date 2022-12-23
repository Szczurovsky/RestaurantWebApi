using Microsoft.EntityFrameworkCore;
using RestaurantWebApi;
using RestaurantWebApi.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<RestaurantDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantDbConnection")));
builder.Services.AddScoped<RestaurantSeeder>();
var app = builder.Build();

// Configure the HTTP request pipeline.
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<RestaurantSeeder>();
seeder.Seed();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
