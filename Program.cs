using Microsoft.EntityFrameworkCore;
using System;
using Data.DbContext;
using Data.Repositories;
using Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;  // Added for .Any()

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<PersonContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register your custom services here
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<PersonContext>();
        SeedData(context);
    }
    catch (Exception ex)
    {
        // Log the exception here
    }
}

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

void SeedData(PersonContext context)
{
    // Apply any pending migrations
    context.Database.Migrate();

    // Check to see if any data exists
    if (!context.Persons.Any())
    {
        // If not, seed some initial data
        context.Persons.AddRange(
            new PersonModel { FirstName = "John", LastName = "Doe", BirthDate = new DateTime(1991, 1, 1) },
            new PersonModel { FirstName = "Jane", LastName = "Doe", BirthDate = new DateTime(1996, 5, 15) },
            new PersonModel { FirstName = "Sam", LastName = "Smith", BirthDate = new DateTime(2000, 12, 20) }
        );

        context.SaveChanges();
    }
}
