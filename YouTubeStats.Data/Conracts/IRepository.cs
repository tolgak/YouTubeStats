using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeStats.Data.Conracts
{
  public interface IRepository<T> where T : class
  {
    Task<T> GetByIdAsync(string id);
    Task<List<T>> GetAllAsync();    
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, object value= null);

    ValueTask<int> AddAsync(T entity);
    ValueTask<int> AddRangeAsync(IEnumerable<T> entities);
    ValueTask<int> RemoveAsync(string id);
    ValueTask<int> RemoveRangeAsync(IEnumerable<string> ids);

    //Task<int> CommitAsync();
    //int Cancel();
    //bool HasChanges();
  }
}
