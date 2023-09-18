using BulkyRazer.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("DefaultConnection")));   //GetConnectionString comes from appsettings.json.


builder.Services.AddRazorPages();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default", pattern: "{Controller=Home}/{action=Index}/{id?}"
);

app.Run();