using System;
using System.Collections.Generic;
using contractorssummer2020.Models;
using contractorssummer2020.Repositories;

namespace contractorssummer2020.Services
{
  public class BidsService
  {
    private readonly BidsRepository _repo;
    public BidsService(BidsRepository repo)
    {
      _repo = repo;
    }
    public string Create(Bid newBid)
    {
      _repo.Create(newBid);
      return "Bid created";
    }

    public string Delete(int id)
    {
      _repo.Delete(id);
      return "Succesfully Deleted";
    }

    public IEnumerable<BidViewModel> GetBidsByJobId(int id)
    {
      return _repo.GetBidsByJobId(id);
    }
    public IEnumerable<BidViewModel> GetBidsByContractorId(int id)
    {
      return _repo.GetBidsByContractorId(id);
    }
  }
}