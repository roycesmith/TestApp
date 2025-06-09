using Microsoft.EntityFrameworkCore;
using TestApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<TestAppContext>(options =>
options.UseSqlite(
builder.Configuration.GetConnectionString("TestAppContext") ??
throw new InvalidOperationException("Connection string 'TestApp' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    // Seed the database with initial data.
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// map apicontoller to /api/todo

app.MapControllers();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

Seed.Initialize(app.Services.CreateScope().ServiceProvider.GetRequiredService<TestAppContext>());

app.Run();

