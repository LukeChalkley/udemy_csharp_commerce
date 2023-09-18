using System.Linq.Expressions;
using Bulky.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bulky.DataAccess.Repositories;

public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    /// <summary>
    /// 
    /// </summary>
    private readonly ILogger<Category> _logger;

    /// <summary>
    /// 
    /// </summary>
    private readonly ApplicationDbContext _categoryContext;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public CategoryRepository(ILogger<Category> logger, 
                              ApplicationDbContext context) : base(logger, context)
    {
        _categoryContext = context;
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="catToUpdate"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Update(Category catToUpdate)
    {
        _logger.LogInformation("Performing Update() for category.");
        _categoryContext.Categories.Update(catToUpdate);
        _categoryContext.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Save()
    {
        _logger.LogInformation("Performing Save() for Categories.");
        _categoryContext.SaveChanges();
    }
}