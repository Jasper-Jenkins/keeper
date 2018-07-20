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
                INSERT INTO keeps (name, description, imageUrl, authorId, share, view, publish)
                VALUES (@Name, @Description, @ImageUrl, @AuthorId, @Share, @View, @Publish);
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
    public IEnumerable<Keep> GetAllKeepsByPublish(string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM keeps
      WHERE publish = 1
      OR authorId = @userId;", new { userId });
    }
    // GetbyAuthor
    public IEnumerable<Keep> GetbyAuthorId(string id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE authorId = @id;", new { id });
    }
    //GetbyVault
    public IEnumerable<Keep> GetbyVaultId(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE vaultId = @id;", new { id });
    }
     public IEnumerable<Keep> GetbyKeepId1(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE keepId = @id;", new { id });
    }
    // GetbyId
    public Keep GetbyKeepId(int id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @id;", new { id });
    }
    // Edit
    // public Keep EditKeep(int id, Keep newKeep)
    // {
    //   newKeep.Id = id;
    //   var i = _db.Execute(@"
    //             UPDATE keeps SET
    //                views = views + 1
    //             WHERE id = @Id
    //         ", newKeep);
    //   if (i > 0)
    //   {
    //     return newKeep;
    //   }
    //   return null;
    // }   
    public Keep UpdateKeepViews(int id, Keep newKeep)
    {
      newKeep.Id = id;
      var i = _db.Execute(@"
                UPDATE keeps SET
                   view = view + 1
                WHERE id = @Id
            ", newKeep);
      if (i > 0)
      {
        return newKeep;
      }
      return null;
    }
     public Keep PublishKeep(int id, Keep newKeep)
    {
      newKeep.Id = id;
      var i = _db.Execute(@"
                UPDATE keeps SET
              
                publish = @Publish
                WHERE id = @Id
            ", newKeep);
      if (i > 0)
      {
        return newKeep;
      }
      return null;
    }
    // Delete
    public bool DeleteKeep(int id, string authorId) //string authorId
    {
      var i = _db.Execute(@"
      DELETE FROM keeps
      WHERE id = @id
      AND authorId = @authorId
      LIMIT 1;
      ", new { id, authorId });   //
      if (i > 0)
      {
         var j = _db.Execute(@"
        DELETE FROM vaultkeeps
        WHERE keepId = @id;
        ", new { id });
        return true;
      }
      return false;
    }

    // Add get user favs to user
  }





}
