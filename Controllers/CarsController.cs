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
  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;

    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAll()
    {
      try
      {
        return Ok(_cs.GetAll());
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
      try
      {
        return Ok(_cs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    //[Authorize]
    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        // Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        //if (user == null)
        //{
        //  throw new Exception("Must be logged in to create.");
        //}
        //newCar.UserId = user.Value;
        newCar.UserId = "fix me";
        return Ok(_cs.Create(newCar));
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
        return Ok(_cs.Delete(id, userId));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Car> Edit(int id, [FromBody] Car updatedCar)
    {
      try
      {
        return Ok(_cs.Edit(id, updatedCar));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}