using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Job Create(Job newJob)
    {
      string sql = @"
        INSERT INTO jobs
        (userId, company, jobTitle, hours, rate, description)
        VALUES
        (@UserId, @Company, @JobTitle, @Hours, @Rate, @Description);
        SELECT LAST_INSERT_ID()";
      newJob.Id = _db.ExecuteScalar<int>(sql, newJob);
      return newJob;
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @Id";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal IEnumerable<Job> GetAll()
    {
      string sql = "SELECT * FROM jobs";
      return _db.Query<Job>(sql);
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM jobs WHERE id = @Id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }

    internal Job Edit(Job jobToUpdate)
    {
      // (userId, company, jobTitle, hours, rate, description)
      string sql = @"
        UPDATE jobs
        SET
          company = @Company,
          jobTitle = @JobTitle,
          hours = @Hours,
          rate = @Rate,
          description = @Description
        WHERE id = @Id LIMIT 1";
      _db.Execute(sql, jobToUpdate);
      return jobToUpdate;
    }

  }
}