using BulkyWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("DefaultConnection")));   //GetConnectionString comes from appsettings.json.

var app = builder.Build();

// Configure the HTTP request pipeline.
/*
    If we have various named environments, we can use
        app.Environment.IsEnvironment()
    which passes an environment name and checks.
*/
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // ? refers to nullable. May not be supplied.

app.Run();