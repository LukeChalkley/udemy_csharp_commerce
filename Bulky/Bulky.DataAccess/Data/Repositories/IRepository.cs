using System.Linq.Expressions;

namespace Bulky.DataAccess.Repositories;

public interface IRepository<T> where T : class
{
    /// <summary>
    /// Returns an IEnumerable collection of all the objects of type T in the repository.
    /// </summary>
    /// <returns>All objects in the repository as an IEnumerable.</returns>
    IEnumerable<T> GetAll();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter">The filter expression to apply to the query.</param>
    /// <returns>The first object that matches the filter expression, or a default value for no result.</returns>
    T GetFirstOrDefault(Expression<Func<T, bool>> filter);
    
    /// <summary>
    /// Returns the count of objects of type T in the repository.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToAdd"></param>
    void Add(T objToAdd);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objToRemove"></param>
    void Delete(T objToRemove);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rangeToDelete"></param>
    void Delete(IEnumerable<T> rangeToDelete);
}