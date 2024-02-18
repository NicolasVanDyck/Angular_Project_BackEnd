using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BackendReview.DAL.Data;
using BackendReview.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ReviewDbContext>(options =>
    options.UseMySQL(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

// maybe needed?

// app.MapControllerRoute(
//     name: "areas",
//     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
// );

using (var scope = app.Services.CreateScope())
{
    var tripContext = scope.ServiceProvider.GetRequiredService<ReviewDbContext>();
    DbInitializer.Initialize(tripContext);
}
app.Run();