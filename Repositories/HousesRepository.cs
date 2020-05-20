using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using fullstack_gregslist.Models;

namespace fullstack_gregslist.Repositories
{
  public class HousesRepository
  {
    private readonly IDbConnection _db;

    public HousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal House Create(House newHouse)
    {
      string sql = @"
        INSERT INTO houses
        (bedrooms, bathrooms, year, price, levels, imgUrl, description, userId )
        VALUES
        (@Bedrooms,@bathrooms, @Year, @Price, @Levels, @ImgUrl, @Description, @UserId );
        SELECT LAST_INSERT_ID()";
      newHouse.Id = _db.ExecuteScalar<int>(sql, newHouse);
      return newHouse;
    }

    internal House GetById(int id)
    {
      string sql = "SELECT * FROM houses WHERE id = @Id";
      return _db.QueryFirstOrDefault<House>(sql, new { id });
    }

    internal IEnumerable<House> GetAll()
    {
      string sql = "SELECT * FROM houses";
      return _db.Query<House>(sql);
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM Houses WHERE id = @Id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }

    internal House Edit(House houseToUpdate)
    {
      string sql = @"
        UPDATE houses
        SET
          Bedrooms = @Bedrooms,
          Bathrooms = @Bathrooms,
          Levels = @Levels,
          Year = @Year,
          Price = @Price,
          ImgUrl = @ImgUrl,
          Description = @Description
        WHERE id = @Id LIMIT 1";
      _db.Execute(sql, houseToUpdate);
      return houseToUpdate;
    }

  }
}