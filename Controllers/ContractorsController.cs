using System;
using System.Collections.Generic;
using contractorssummer2020.Models;
using contractorssummer2020.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorssummer2020.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _cs;

    public ContractorsController(ContractorsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> Get()
    {
      try
      {
        return Ok(_cs.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Contractor> Get(int id)
    {
      try
      {
        return Ok(_cs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
      try
      {
        return Ok(_cs.Create(newContractor));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_cs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}