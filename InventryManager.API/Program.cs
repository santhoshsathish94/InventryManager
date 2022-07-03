using InventryManager.API.Mapper;
using InventryManager.API.Middleware;
using InventryManager.SqlRepostiroy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Invetory Manager APIs", Version = "v1" });
    c.SchemaFilter<SwaggerSchemaFilter>();
});
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InventoryManagerDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add middleware to log every request/response
app.UseMiddleware<RequestResponseLogger>();

// add middleware to process exceptions automatically
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
