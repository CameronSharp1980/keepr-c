using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr_c.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr_c.Repositories
{
    public class VaultRepository
    {
        private readonly IDbConnection _db;

        public VaultRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Vault> GetAll()
        {
            return _db.Query<Vault>("SELECT * FROM vaults");
        }

        public Vault GetById(int id)
        {
            return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM vaults WHERE id = {id}", id);
        }

        public Vault Add(Vault vault)
        {
            //INSERT INTO vaults - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { vault.Name.... etc} is the object constructor that will be used in the insert query.
            int id = _db.ExecuteScalar<int>(@"
                        INSERT INTO vaults (Name, Description, UserId)
                        VALUES(@Name, @Description, @UserId);
                        SELECT LAST_INSERT_ID()", new
            {
                vault.Name,
                vault.Description,
                vault.UserId
            });
            vault.Id = id;
            return vault;
        }

        public Vault GetOneByIdAndUpdate(int id, Vault vault)
        {
            //Queries for the first Vault that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
            return _db.QueryFirstOrDefault<Vault>($@"
                UPDATE vaults SET  
                    Name = @Name,
                    Description = @Description
                WHERE Id = {id};
                SELECT * FROM vaults WHERE id = {id};", vault);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM vaults WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}