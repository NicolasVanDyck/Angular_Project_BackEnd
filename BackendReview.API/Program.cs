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
    options.UseMySql("server=localhost;port=3307;database=ReviewDB;user=nicolas;password=sdfSDF123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql")));

// Add JWT Authentication
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization(options =>
{
    //We create different policies where each policy contains the permissions required to fulfill them
    options.AddPolicy("ReadContent", policy =>
        policy.RequireClaim("permissions", "read:content"));
    options.AddPolicy("createContent", policy =>
        policy.RequireClaim("permissions", "create:content"));
    options.AddPolicy("updateContent", policy =>
        policy.RequireClaim("permissions", "update:content"));
    options.AddPolicy("DeleteContent", policy =>
        policy.RequireClaim("permissions", "delete:content"));
    
    options.AddPolicy("ReadGame", policy =>
        policy.RequireClaim("permissions", "read:game"));
    options.AddPolicy("CreateGame", policy =>
        policy.RequireClaim("permissions", "create:game"));
    options.AddPolicy("UpdateGame", policy =>
        policy.RequireClaim("permissions", "update:game"));
    options.AddPolicy("DeleteGame", policy =>
        policy.RequireClaim("permissions", "delete:game"));

    options.AddPolicy("ReadPlatform", policy =>
        policy.RequireClaim("permissions", "read:platform"));
    options.AddPolicy("CreatePlatform", policy =>
        policy.RequireClaim("permissions", "create:platform"));
    options.AddPolicy("UpdatePlatform", policy =>
        policy.RequireClaim("permissions", "update:platform"));
    options.AddPolicy("DeletePlatform", policy =>
        policy.RequireClaim("permissions", "delete:platform"));

    options.AddPolicy("ReadVariety", policy =>
        policy.RequireClaim("permissions", "read:variety"));
    options.AddPolicy("CreateVariety", policy =>
        policy.RequireClaim("permissions", "create:variety"));
    options.AddPolicy("UpdateVariety", policy =>
        policy.RequireClaim("permissions", "update:variety"));
    options.AddPolicy("DeleteVariety", policy =>
        policy.RequireClaim("permissions", "delete:variety"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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