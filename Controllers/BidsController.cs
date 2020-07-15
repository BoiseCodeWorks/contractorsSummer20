using System;
using System.Collections.Generic;
using contractorssummer2020.Models;
using contractorssummer2020.Services;
using Microsoft.AspNetCore.Mvc;

namespace contractorssummer2020.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BidsController : ControllerBase
  {
    private readonly BidsService _bs;
    public BidsController(BidsService bs)
    {
      _bs = bs;
    }



    // [HttpGet("{id}")]
    // public ActionResult<Bid> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_bs.Get(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    public ActionResult<Bid> Create([FromBody] Bid newBid)
    {
      try
      {
        return Ok(_bs.Create(newBid));
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
        return Ok(_bs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}