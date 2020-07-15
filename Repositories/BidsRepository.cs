using System;
using System.Collections.Generic;
using System.Data;
using contractorssummer2020.Models;
using Dapper;

namespace contractorssummer2020.Repositories
{
  public class BidsRepository
  {
    private readonly IDbConnection _db;

    public BidsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal void Delete(int id)
    {
      string sql = "DELETE FROM bids WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal void Create(Bid newBid)
    {
      string sql = @"
        INSERT INTO bids
        (contractorId, jobId, price)
        VALUES
        (@ContractorId, @JobId, @Price);
        SELECT LAST_INSERT_ID();";
      _db.ExecuteScalar<int>(sql, newBid);
    }

    internal IEnumerable<BidViewModel> GetBidsByJobId(int id)
    {
      string sql = @"
        SELECT *,
        c.name as contractorName,
        j.name as jobName,
        b.id as bidId FROM bids b
        INNER JOIN contractors c on c.id = b.contractorId
        INNER JOIN jobs j on j.id = b.jobId
        WHERE (jobId = @id)        
        ";
      return _db.Query<BidViewModel>(sql, new { id });

    }
    internal IEnumerable<BidViewModel> GetBidsByContractorId(int id)
    {
      string sql = @"
        SELECT 
            *,
            c.name as contractorName,
            j.name as jobName,
            b.id as bidId 
        FROM bids b
            INNER JOIN contractors c on c.id = b.contractorId
            INNER JOIN jobs j on j.id = b.jobId
        WHERE (contractorId = @id)        
        ";
      return _db.Query<BidViewModel>(sql, new { id });

    }
  }
}