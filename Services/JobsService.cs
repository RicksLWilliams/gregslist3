using System;
using System.Collections.Generic;
using fullstack_gregslist.Models;
using fullstack_gregslist.Repositories;

namespace fullstack_gregslist.Controllers
{
  public class JobsService
  {
    private readonly JobsRepository _repo;

    public JobsService(JobsRepository repo)
    {
      _repo = repo;
    }

    internal Job Create(Job newJob)
    {
      return _repo.Create(newJob);
    }

    internal IEnumerable<Job> GetAll()
    {
      return _repo.GetAll();
    }
    public Job GetById(int id)
    {
      Job foundJob = _repo.GetById(id);
      if (foundJob == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundJob;
    }

    internal string Delete(int id, string userId)
    {
      Job foundJob = GetById(id);
      if (foundJob.UserId != userId)
      {
        throw new Exception("This is not your job!");
      }
      if (_repo.Delete(id, userId))
      {
        return "Sucessfully deleted.";
      }
      throw new Exception("Something bad happened");
    }

    internal Job Edit(int id, Job updatedJob)
    {
      Job foundJob = GetById(id);
      //NOTE GetById() is already handling our null checking
      foundJob.Company  = updatedJob.Company;
      foundJob.JobTitle   = updatedJob.JobTitle;
      foundJob.Hours   = updatedJob.Hours;
      foundJob.Rate = updatedJob.Rate;
      foundJob.Description = updatedJob.Description;
      return _repo.Edit(foundJob);
    }
  }
}