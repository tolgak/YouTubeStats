using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouTubeStats.Data
{
  public class SQLiteQueryProcessor
  {
    public string ConnectionString { get; set; }
    public SQLiteQueryProcessor()
    {

    }
    public SQLiteQueryProcessor(string connectionString) : this()
    {
      this.ConnectionString = connectionString;
    }



    public async Task<List<History>> RunQuery(string sql, object parameters = null)
    {
      using (var connection = new SqliteConnection(this.ConnectionString))
      {
        connection.Open();
        var qry = await connection.QueryAsync<History>(sql, parameters);
        return qry.ToList();
      }
    }

    //public async Task<dynamic> RunQuery(string sql, object parameters = null)
    //{
    //  using (var connection = new SqliteConnection(this.ConnectionString))
    //  {
    //    connection.Open();
    //    IEnumerable<dynamic> qry = await connection.QueryAsync(sql, parameters);
    //    return qry;
    //  }
    //}


  }
}
