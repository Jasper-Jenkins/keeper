using System.Collections.Generic;
using System.Data;
using API_Users.Models;
using Dapper;

namespace API_Users.Repositories
{
  public class KeepRepository : DbContext
  {
    public KeepRepository(IDbConnection db) : base(db)
    {

    }
    // Create Keep
    public Keep CreateKeep(Keep newKeep)
    {
      int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name, description, authorId, share, view, publish)
                VALUES (@Name, @Description, @AuthorId, @Share, @View, @Publish);
                SELECT LAST_INSERT_ID();
            ", newKeep);
      newKeep.Id = id;
      return newKeep;
    //   {
    //       Id = newKeep.Id,
    //       Name = newKeep.Name,
    //       Description = newKeep.Description,
    //       AuthorId = newKeep.AuthorId
    //   };
    }
    // GetAll Keep
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }
    // GetbyAuthor
    public IEnumerable<Keep> GetbyAuthorId(string id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE authorId = @id;", new { id });
    }
    // GetbyId
    public Keep GetbyKeepId(int id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id });
    }
    // Edit
    public Keep EditKeep(int id, Keep post)
    {
      post.Id = id;
      var i = _db.Execute(@"
                UPDATE keeps SET
                    name = @Name,
                    description = @Description
                WHERE id = @Id
            ", post);
      if (i > 0)
      {
        return post;
      }
      return null;
    }
    // Delete
    public bool DeleteKeep(int id) //string authorId
    {
      var i = _db.Execute(@"
      DELETE FROM keeps
      WHERE id = @id  //AND authorId = @authorId
      LIMIT 1;
      ", new { id });
      if (i > 0)
      {
        return true;
      }
      return false;
    }

    // Add get user favs to user
  }





}