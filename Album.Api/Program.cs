using Album.Api.Controllers;
using Album.Api.Services;
using Microsoft.Extensions.DependencyInjection;
using Album.Api;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<AlbumContext>();
builder.Services.AddCors();

builder.Services.AddTransient<IGreetingService, GreetingService>();
builder.Services.AddTransient<IAlbumService, AlbumService>();

var app = builder.Build();
app.UseCors(policy => policy
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var dbContext = new AlbumContext())
{
    DbInitializer.Initialize(dbContext);
};
app.Run();