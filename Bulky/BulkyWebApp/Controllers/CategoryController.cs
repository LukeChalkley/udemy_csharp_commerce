using Microsoft.AspNetCore.Mvc;

namespace BulkyWebApp.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}