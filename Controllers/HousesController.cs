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
  public class HousesController : ControllerBase
  {
    private readonly HousesService _hs;

    public HousesController(HousesService hs)
    {
      _hs = hs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<House>> GetAll()
    {
      try
      {
        return Ok(_hs.GetAll());
      }
      catch (System.Exception err)
      {

        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<House> GetById(int id)
    {
      try
      {
        return Ok(_hs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<House> Create([FromBody] House newHouse)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
         throw new Exception("Must be logged in to create.");
        }
        newHouse.UserId = user.Value;
        //newHouse.UserId = "fix me";
        return Ok(_hs.Create(newHouse));
      }
        catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
         throw new Exception("you must be logged in to delete");
        }
        string userId = user.Value;
        //string userId = "fix me";
        return Ok(_hs.Delete(id, userId));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<House> Edit(int id, [FromBody] House updatedHouse)
    {
      try
      {
        return Ok(_hs.Edit(id, updatedHouse));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}