using System;
using System.Collections.Generic;
using contractorssummer2020.Models;
using contractorssummer2020.Repositories;

namespace contractorssummer2020.Services
{
  public class JobsService
  {
    private readonly JobsRepository _repo;
    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Job> Get()
    {
      return _repo.Get();
    }

    public Job Get(int id)
    {
      Job exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public Job Create(Job newJob)
    {
      int id = _repo.Create(newJob);
      newJob.Id = id;
      return newJob;
    }
    public string Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}