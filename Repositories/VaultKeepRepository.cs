using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr_c.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr_c.Repositories
{
    public class VaultKeepRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        // public IEnumerable<VaultKeep> GetAll()
        // {
        //     return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
        // }

        // public VaultKeep GetById(int id)
        // {
        //     return _db.QueryFirstOrDefault<VaultKeep>($"SELECT * FROM vaultkeeps WHERE id = {id}", id);
        // }

        public IEnumerable<VaultKeepReturnModel> GetKeeps(int vaultId)
        {
            System.Console.WriteLine(vaultId);
            return _db.Query<VaultKeepReturnModel>($@"
                        SELECT * FROM vaultkeeps vk
                        INNER JOIN keeps k ON k.id = vk.keepId
                        WHERE (vaultId = {vaultId})
                        ");
        }

        //         SELECT * FROM vaultkeeps vk
        // INNER JOIN keeps k ON k.id = vk.keepId 
        // WHERE (vaultId = 2)

        public VaultKeep Add(VaultKeep vaultKeep)
        {
            //INSERT INTO vaultkeeps - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { vaultkeep.vaultId.... etc} is the object constructor that will be used in the insert query.
            int id = _db.ExecuteScalar<int>(@"
                        INSERT INTO vaultkeeps (VaultId, KeepId, UserId)
                        VALUES(@VaultId, @KeepId, @UserId);
                        SELECT LAST_INSERT_ID()", new
            {
                vaultKeep.VaultId,
                vaultKeep.KeepId,
                vaultKeep.UserId
            });
            vaultKeep.Id = id;
            return vaultKeep;
        }

        // public VaultKeep GetOneByIdAndUpdate(int id, VaultKeep vaultKeep)
        // {
        //     //Queries for the first VaultKeep that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
        //     return _db.QueryFirstOrDefault<VaultKeep>($@"
        //         UPDATE vaultkeeps SET  
        //             VaultId = @VaultId,
        //             KeepId = @KeepId
        //         WHERE Id = {id};
        //         SELECT * FROM vaultkeeps WHERE id = {id};", vaultKeep);
        // }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM vaultkeeps WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}