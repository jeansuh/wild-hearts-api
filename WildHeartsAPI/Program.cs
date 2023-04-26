using Microsoft.EntityFrameworkCore;
using WildHeartsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<WildHeartsAPIDBContext>();

var app = builder.Build();

app.MapGet("/api/kemono/chapter/{chapter}", async (int chapter, WildHeartsAPIDBContext db) =>
    await db.Kemonos.Where(k=>k.Chapter==chapter).ToListAsync());

app.MapGet("/api/kemono/habitat/{habitat}", async (string habitat, WildHeartsAPIDBContext db) =>
    await db.Kemonos.Where(k => k.Habitat == habitat).ToListAsync());

app.MapGet("/api/material/kemonoid/{kemonoid}", async (int kemonoid, WildHeartsAPIDBContext db) =>
    await db.Materials.Where(m => m.KemonoId == kemonoid).ToListAsync());

app.MapGet("/api/material/materialname/{materialname}", async (string materialname, WildHeartsAPIDBContext db) =>
    await db.Materials.Where(m => m.MaterialName == materialname).ToListAsync());

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

