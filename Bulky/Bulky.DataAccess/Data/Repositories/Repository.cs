using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bulky.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    /// <summary>
    /// 
    /// </summary>
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// 
    /// </summary>
    private readonly ILogger<T> _logger;

    /// <summary>
    /// 
    /// </summary>
    private DbSet<T> _dbSet;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public Repository(ILogger<T> logger, ApplicationDbContext context)
    {
        this._context = context;
        this._logger = logger;
        this._dbSet = context.Set<T>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public IEnumerable<T> GetAll()
    {
        _logger.LogInformation("Beginning query for GetAll.");
        return _dbSet.ToList();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
    {
        _logger.LogInformation("Beginning query for GetFirstOrDefault.");
        
        T result = _dbSet.FirstOrDefault(filter);

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Count => _dbSet.Count();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToAdd"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Add(T objToAdd)
    {
        _logger.LogInformation("About to perform Add().");
        _dbSet.Add(objToAdd);
        _context.SaveChanges();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToRemove"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Delete(T objToRemove)
    {
        _logger.LogInformation("About to perform Delete().");
        _dbSet.Remove(objToRemove);
        _context.SaveChanges();
    }

    public void Delete(IEnumerable<T> rangeToDelete)
    {
        throw new NotImplementedException();
    }
}