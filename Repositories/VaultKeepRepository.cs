using System.Collections.Generic;
using System.Data;
using API_Users.Models;
using Dapper;

namespace API_Users.Repositories
{
  public class VaultKeepRepository : DbContext
  {
    public VaultKeepRepository(IDbConnection db) : base(db)
    {
    }
    // Create VaultKeep
      public VaultKeep CreateVaultKeep(VaultKeep newKeep, int keepId)
    {
      var i = _db.Execute(@"
                UPDATE keeps SET
                    share = share + 1
                WHERE id = @keepId;
            ", new {keepId});
      if (i > 0)
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultKeeps (keepId, authorId, vaultId)
                VALUES (@KeepId, @AuthorId, @VaultId);
                SELECT LAST_INSERT_ID();
            ", newKeep);
        return newKeep;  
        // return "Successfully Added!";
      }
      return null;
    //   return "Failed To Add!";
    }



    // public VaultKeep CreateVaultKeep(VaultKeep newVaultKeep)
    // {
    //   int id = _db.ExecuteScalar<int>(@"
    //             INSERT INTO vaultkeeps (vaultId, keepId, authorId)
    //             VALUES (@VaultId, @KeepId, @AuthorId);
    //             SELECT LAST_INSERT_ID();
    //         ", newVaultKeep);
    //   newVaultKeep.Id = id;
    //   return newVaultKeep;
    // //   {
    // //       Id = newVaultKeep.Id, 
    // //       Name = newVaultKeep.Name,
    // //       Description = newVaultKeep.Description,
    // //       AuthorId = newVaultKeep.AuthorId
    // //   };
    // }
    // GetAll VaultKeep
    public IEnumerable<VaultKeep> GetAll()
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps;");
    }
    // GetbyAuthor
    public IEnumerable<VaultKeep> GetbyAuthorId(string id)
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps WHERE authorId = @id;", new { id });
    }

    public IEnumerable<VaultKeep> GetbyVaultId(int id)
    {
      return _db.Query<VaultKeep>(@"SELECT * FROM vaultkeep
              INNER JOIN keeps ON keeps.id = vaultkeep.keepId 
              WHERE vaultkeep.vaultId = @id;
              ", new { id });
    }
    // GetbyId
    public VaultKeep GetbyVaultKeepId(int id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM vaultkeeps WHERE vaultId = @id;", new { id });
    }
    // Edit
    public VaultKeep EditVaultKeep(int id, VaultKeep vaultkeep)
    {
      vaultkeep.Id = id;
      var i = _db.Execute(@"
                UPDATE vaultkeeps SET
                    name = @Name,
                    description = @Description
                WHERE id = @Id
            ", vaultkeep);
      if (i > 0)
      {
        return vaultkeep;
      }
      return null;
    }
    // Delete
    public bool DeleteVaultKeep(int id) //string authorId
    {
      var i = _db.Execute(@"
      DELETE FROM vaultkeeps
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
