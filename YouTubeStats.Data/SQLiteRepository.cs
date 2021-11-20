using Dapper;

using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YouTubeStats.Data.Conracts;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YouTubeStats.Data
{
  public enum CRUD { Insert, Update, Delete, Get, List };

  public class SQLiteRepository<T> : IRepository<T> where T : class, new()
  {
    public string ConnectionString { get; set; }

    public SQLiteRepository()
    {

    }

    public SQLiteRepository(string connectionString) : this()
    {
      this.ConnectionString = connectionString;
    }

    private async ValueTask<int> UsingConnection(Func<IDbConnection, int> dbTask)
    {
      return await Task.Run(() =>
      {
        var retVal = 0;
        using (var connection = new SqliteConnection(this.ConnectionString))
        {
          connection.Open();
          using (var sqlTransaction = connection.BeginTransaction())
          {
            retVal = dbTask(connection);
            sqlTransaction.Commit();
          }
        }
        return retVal;
      });
    }

    private string BuildCRUDSql(CRUD crud, T entity)
    {
      var props = entity.GetType().GetProperties()
                                  .Where(x => x.GetCustomAttributes(typeof(QueryParamIgnoreAttribute), true).Length == 0);
      var propNames = props.Select(x => x.Name).ToArray();
      var sb = new StringBuilder();

      if (crud == CRUD.Insert)
      {
        sb.Append($"insert into {entity.GetType().Name} (");
        sb.Append(string.Join(',', propNames));
        sb.Append(") values (");
        var paramNames = props.Select(x => "@" + x.Name).ToArray();
        sb.Append(string.Join(',', paramNames));
        sb.Append(")");
      }

      if (crud == CRUD.Update)
      {
        sb.Append($"update {entity.GetType().Name} set ");
        var paramNames = props.Where(x => x.GetCustomAttributes(typeof(KeyAttribute), true).Length == 0)
                              .Select(x => $"{x.Name} = @{x.Name}").ToArray();

        sb.Append(string.Join(',', paramNames));
        sb.Append($" where Id = @Id");
      }

      if (crud == CRUD.Delete)
      {
        sb.Append($"delete from {entity.GetType().Name} ");
        sb.Append($"where Id = @Id");
      }

      return sb.ToString();
    }

    public async ValueTask<int> AddAsync(T entity)
    {
      return await this.UsingConnection(connection =>
      {
        var sql = this.BuildCRUDSql(CRUD.Insert, entity);
        return connection.ExecuteAsync(sql, entity).Result;
      });
    }

    public async ValueTask<int> AddRangeAsync(IEnumerable<T> entities)
    {
      return await this.UsingConnection(connection =>
      {
        var mock = Activator.CreateInstance<T>();
        var sql = this.BuildCRUDSql(CRUD.Insert, mock);
        return connection.ExecuteAsync(sql, entities.ToArray()).Result;
      });
    }

    public async ValueTask<int> RemoveAsync(string id)
    {
      return await this.UsingConnection(connection =>
      {
        var mock = Activator.CreateInstance<T>();
        var sql = this.BuildCRUDSql(CRUD.Delete, mock);
        return connection.Execute(sql, new { Id = id});
      });
    }

    public async ValueTask<int> RemoveRangeAsync(IEnumerable<string> ids)
    {
      return await this.UsingConnection(connection =>
      {                                                                                               
        var mock = Activator.CreateInstance<T>();
        var sql = this.BuildCRUDSql(CRUD.Delete, mock);        
        return connection.Execute(sql, ids.Select( x => new { Id = x}).ToArray());
      });
    }

    public async ValueTask<int> UpdateAsync(T entity)
    {
      return await this.UsingConnection(connection =>
      {
        var sql = this.BuildCRUDSql(CRUD.Update, entity);
        return connection.Execute(sql, entity);
      });
    }

    public async ValueTask<int> SaveOrUpdate(T entity)
    {
      var id = entity.GetType().GetProperties()
                                .Where(x => x.GetCustomAttributes(typeof(KeyAttribute), true).Length == 1)
                                .Select(x => x.GetValue(entity)).ToArray();

      var item = await GetByIdAsync(id[0].ToString());
      return item == null ? await AddAsync(entity) : await UpdateAsync(entity);
    }

    public async Task<T> GetByIdAsync(string id)
    {
      using (var connection = new SqliteConnection(this.ConnectionString))
      {
        connection.Open();
        var qry = await connection.QueryFirstOrDefaultAsync<T>($"select * from {typeof(T).Name} where Id = @Id", new {Id = id});

        return qry;
      }
    }

    public async Task<List<T>> GetAllAsync()
    {
      using (var connection = new SqliteConnection(this.ConnectionString))
      {
        connection.Open();
        var qry = await connection.QueryAsync<T>($"select * from {typeof(T).Name}");

        return qry.ToList();
      }
    }

    public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate, object value = null)
    {
      return await Task.Run(() =>
      {
         using (var connection = new SqliteConnection(this.ConnectionString))
         {
           connection.Open();          
           var qry = connection.Query<T>($"select * from {typeof(T).Name}", value).AsQueryable().Where(predicate);
           return qry.ToList();
         }
     });
    }
    
  }
}
