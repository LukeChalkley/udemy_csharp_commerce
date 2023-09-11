using BulkyWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebApp.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public CategoryController(ILogger<CategoryController> logger,
                              ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    // GET
    public IActionResult Index()
    {
        var allCategories = _dbContext.Categories.ToList();

        return View();
    }
}