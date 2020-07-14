using System.Collections.Generic;
using System.Data;
using contractorssummer2020.Models;
using Dapper;

namespace contractorssummer2020.Repositories
{
  public class ContractorsRepository
  {
    private readonly IDbConnection _db;
    public ContractorsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Contractor> Get()
    {
      string sql = "SELECT * FROM contractors";
      return _db.Query<Contractor>(sql);
    }

    public Contractor Get(int id)
    {
      string sql = "SELECT * FROM contractors WHERE id = @id";
      return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
    }

    public int Create(Contractor newContractor)
    {
      string sql = @"
                INSERT INTO contractors
                (name, location)
                VALUES
                (@Name, @Location);
                SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newContractor);
    }



    public void Delete(int id)
    {
      string sql = "DELETE FROM contractors WHERE id = @id";
      _db.Execute(sql, new { id });
    }


  }
}