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

// The librarians would like to see a list of all the circulating materials. 
// Include the Genre and MaterialType. Exclude materials that have a OutOfCirculationSince value.

app.Run();