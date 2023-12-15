using LoncotesLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<LoncotesLibraryDbContext>(builder.Configuration["LoncotesLibraryDbConnectionString"]);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get Endpoints
app.MapGet("/api/materials", (LoncotesLibraryDbContext db, int? materialTypeId, int? genreId) =>
{
    return db.Materials
    .Where(m =>
        m.OutOfCirculationSince != null &&
        (!materialTypeId.HasValue || m.MaterialTypeId == materialTypeId.Value) &&
        (!genreId.HasValue || m.GenreId == genreId.Value)
    )
    .Select(m => new MaterialDTO
    {
        Id = m.Id,
        MaterialName = m.MaterialName,
        MaterialTypeId = m.MaterialTypeId,
        MaterialType = new MaterialTypeDTO
        {
            Id = m.MaterialType.Id,
            Name = m.MaterialType.Name,
            CheckoutDays = m.MaterialType.CheckoutDays
        },
        GenreId = m.GenreId,
        Genre = new GenreDTO
        {
            Id = m.Genre.Id,
            Name = m.Genre.Name
        },
        OutOfCirculationSince = m.OutOfCirculationSince
    }).ToList();
});

app.MapGet("/api/Materials/{id}", (LoncotesLibraryDbContext db, int id) =>
{
    var material = db.Materials
        .Include(m => m.MaterialType)
        .Include(m => m.Genre)
        .Include(m => m.Checkouts)
            .ThenInclude(c => c.Patron)
        .SingleOrDefault(m => m.Id == id);

    if (material == null)
    {
        return Results.NotFound(); // Or handle not found scenario appropriately
    }

    var materialCheckouts = material.Checkouts.Select(co =>
        new CheckoutDTO
        {
            Id = co.Id,
            MaterialId = co.MaterialId,
            PatronId = co.PatronId,
            Patron = new PatronDTO
            {
                Id = co.Patron.Id,
                FirstName = co.Patron.FirstName,
                LastName = co.Patron.LastName,
                Address = co.Patron.Address,
                Email = co.Patron.Email,
                IsActive = co.Patron.IsActive
            },
            CheckoutDate = co.CheckoutDate,
            ReturnDate = co.ReturnDate
        }).ToList();

    return Results.Ok(new MaterialDTO
    {
        Id = material.Id,
        MaterialName = material.MaterialName,
        MaterialTypeId = material.MaterialTypeId,
        GenreId = material.GenreId,
        OutOfCirculationSince = material.OutOfCirculationSince,
        Checkouts = materialCheckouts
    });
});

app.Run();