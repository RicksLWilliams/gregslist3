using System;
using System.Collections.Generic;
using System.Security.Claims;
using fullstack_gregslist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_gregslist.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    private readonly JobsService _js;

    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> GetAll()
    {
      try
      {
        return Ok(_js.GetAll());
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> GetById(int id)
    {
      try
      {
        return Ok(_js.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    //[Authorize]
    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        // Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        //if (user == null)
        //{
        //  throw new Exception("Must be logged in to create.");
        //}
        //newCar.UserId = user.Value;
        newJob.UserId = "fix me";
        return Ok(_js.Create(newJob));
      }
        catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    //[Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        //Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        //if (user == null)
        //{
        //  throw new Exception("you must be logged in to delete");
        //}
        //string userId = user.Value;
        string userId = "fix me";
        return Ok(_js.Delete(id, userId));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Job> Edit(int id, [FromBody] Job updatedJob)
    {
      try
      {
        return Ok(_js.Edit(id, updatedJob));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}