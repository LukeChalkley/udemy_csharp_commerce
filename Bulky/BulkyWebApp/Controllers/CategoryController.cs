using BulkyWebApp.Data;
using BulkyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        return View(allCategories);
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(Category categoryToAdd)
    {
        var existingCategory = _dbContext.Categories.SingleOrDefault(cat => cat.Name == categoryToAdd.Name);

        if (existingCategory != null)
            ModelState.AddModelError("Name", "Category already exists.");

        if (!ModelState.IsValid) return View();
        
        _dbContext.Categories.Add(categoryToAdd);
        _dbContext.SaveChanges();

        TempData["PageMessage"] = $"Successfully added category {categoryToAdd.Name}.";
        
        return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public IActionResult Edit(int? ID)
    {
        if (!ID.HasValue)
            return NotFound();
        
        var categoryToEdit = _dbContext.Categories.Find(ID);

        if (categoryToEdit == null)
            return NotFound();
        
        return View(categoryToEdit);
    }
    
    [HttpPost]
    public IActionResult Edit(Category categoryToEdit)
    {
        var existingCategory = _dbContext.Categories.SingleOrDefault(cat => cat.Name == categoryToEdit.Name);

        if (existingCategory != null && categoryToEdit.Id != existingCategory.Id)
            ModelState.AddModelError("Name", "Cannot edit category to match existing category.");

        if (ModelState.IsValid)
        { 
            _dbContext.Update(categoryToEdit);
            _dbContext.SaveChanges();
            
            TempData["PageMessage"] = $"Successfully edited category {categoryToEdit.Name}.";
            
            var allCategories = _dbContext.Categories.ToList();
            
            return View("Index", allCategories);
        }

        return View();
    }
    
    [HttpGet]
    public IActionResult Delete(int? ID)
    {
        if (!ID.HasValue)
            return NotFound();
        
        var categoryToEdit = _dbContext.Categories.Find(ID);

        if (categoryToEdit == null)
            return NotFound();
        
        return View(categoryToEdit);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? ID)
    {
        if (!ID.HasValue)
            return NotFound();
        
        var categoryToDelete = _dbContext.Categories.Find(ID);

        var catToDeleteName = categoryToDelete.Name;
        
        _dbContext.Categories.Remove(categoryToDelete);
        _dbContext.SaveChanges();

        TempData["PageMessage"] = $"Successfully edited category {catToDeleteName}.";
        
        var allCategories = _dbContext.Categories.ToList();
        
        return View("Index", allCategories);
    }
}