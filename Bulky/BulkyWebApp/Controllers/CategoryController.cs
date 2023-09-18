using Bulky.DataAccess;
using Bulky.DataAccess.Repositories;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bulky.WebApp.Controllers;

public class CategoryController : Controller
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryRepository _categoryContext;

    public CategoryController(ILogger<CategoryController> logger, ICategoryRepository categoryContext)
    {
        _logger = logger;
        _categoryContext = categoryContext;
    }
    
    // GET
    public IActionResult Index()
    {
        var allCategories = _categoryContext.GetAll();

        return View(allCategories.ToList());
    }

    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Add(Category categoryToAdd)
    {
        var existingCategory = _categoryContext.GetFirstOrDefault(cat => cat.Name == categoryToAdd.Name);

        if (existingCategory != null)
            ModelState.AddModelError("Name", "Category already exists.");

        if (!ModelState.IsValid) return View();
        
        _categoryContext.Add(categoryToAdd);
        _categoryContext.Save();

        TempData["PageMessage"] = $"Successfully added category {categoryToAdd.Name}.";
        
        return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public IActionResult Edit(int? ID)
    {
        if (!ID.HasValue)
            return NotFound();
        
        var existingCategory = _categoryContext.GetFirstOrDefault(cat => cat.Id == ID);

        if (existingCategory == null)
            return NotFound();
        
        return View(existingCategory);
    }
    
    [HttpPost]
    public IActionResult Edit(Category categoryToEdit)
    {
        var existingCategory = _categoryContext.GetFirstOrDefault(cat => cat.Name == categoryToEdit.Name);

        if (existingCategory != null && categoryToEdit.Id != existingCategory.Id)
            ModelState.AddModelError("Name", "Cannot edit category to match existing category.");

        if (ModelState.IsValid)
        { 
            _categoryContext.Update(categoryToEdit);
            _categoryContext.Save();
            
            TempData["PageMessage"] = $"Successfully edited category {categoryToEdit.Name}.";

            var allCategories = _categoryContext.GetAll().ToList();
            
            return View("Index", allCategories);
        }

        return View();
    }
    
    [HttpGet]
    public IActionResult Delete(int? ID)
    {
        if (!ID.HasValue)
            return NotFound();
        
        var categoryToEdit = _categoryContext.GetFirstOrDefault(cat => cat.Id == ID);

        if (categoryToEdit == null)
            return NotFound();
        
        return View(categoryToEdit);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePost(int? ID)
    {
        if (!ID.HasValue)
            return NotFound();
        
        var categoryToDelete = _categoryContext.GetFirstOrDefault(cat => cat.Id == ID);

        var catToDeleteName = categoryToDelete.Name;
        
        _categoryContext.Delete(categoryToDelete);
        _categoryContext.Save();

        TempData["PageMessage"] = $"Successfully deleted category {catToDeleteName}.";

        var allCategories = _categoryContext.GetAll().ToList();
        
        return View("Index", allCategories);
    }
}