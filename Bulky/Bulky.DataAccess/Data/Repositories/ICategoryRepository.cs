using Bulky.Models;

namespace Bulky.DataAccess.Repositories;

public interface ICategoryRepository : IRepository<Category>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="catToUpdate"></param>
    void Update(Category catToUpdate);

    /// <summary>
    /// 
    /// </summary>
    void Save();
}