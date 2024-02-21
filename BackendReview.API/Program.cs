using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using BackendReview.API;
using BackendReview.DAL.Data;
using BackendReview.DAL.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ReviewDbContext>(options =>
    options.UseMySQL(connectionString));

// Add JWT Authentication
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    //We create different policies where each policy contains the permissions required to fulfill them
    options.AddPolicy("DeleteAccess", policy =>
        policy.RequireClaim("permissions", "delete:content"));
    options.AddPolicy("GetAccess", policy =>
        policy.RequireClaim("permissions", "getall:contents"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

builder.Services.AddSwaggerService();

var app = builder.Build();

// Use Cors 
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.WithOrigins("http://localhost:4200", "https://localhost:4200");
});

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