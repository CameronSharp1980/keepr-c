using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using keepr_c.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr_c.Repositories
{
    public class KeepRepository
    {
        private readonly IDbConnection _db;

        public KeepRepository(IDbConnection db)
        {
            _db = db;
        }

        // Find One Find Many add update delete
        public IEnumerable<Keep> GetAll()
        {
            return _db.Query<Keep>("SELECT * FROM keeps");
        }

        public Keep GetById(int id)
        {
            return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM keeps WHERE id = {id}", id);
        }

        public Keep Add(Keep keep)
        {
            int socialDefaults = 0;
            //INSERT INTO keeps - inserts the arguments to the matching parameters(order is important), then executes a separate SELECT query to get the ID of the last inserted item, and then auto increments to get a new id(provided auto increment is set on the table).
            //the new { keep.Name.... etc} is the object constructor that will be used in the insert query.
            int id = _db.ExecuteScalar<int>(@"
                        INSERT INTO keeps (Name, Description, UserId, ImageUrl, Views, Keeps, Shares)
                        VALUES(@Name, @Description, @UserId, @ImageUrl, @socialDefaults, @socialDefaults, @socialDefaults);
                        SELECT LAST_INSERT_ID()", new
            {
                keep.Name,
                keep.Description,
                keep.UserId,
                keep.ImageUrl,
                socialDefaults
            });
            keep.Id = id;
            return keep;
        }

        public Keep GetOneByIdAndUpdate(int id, Keep keep)
        {
            //Queries for the first Keep that matches the id passed in. If it doesn't find it, it defaults to handle the error gracefully without crashing. If it finds the id, it updates the fields with the data you are sending.
            return _db.QueryFirstOrDefault<Keep>($@"
                UPDATE keeps SET  
                    Name = @Name,
                    Description = @Description,
                    ImageUrl = @ImageUrl
                WHERE Id = {id};
                SELECT * FROM keeps WHERE id = {id};", keep);
        }

        public string FindByIdAndRemove(int id)
        {
            var success = _db.Execute($@"
                DELETE FROM keeps WHERE Id = {id}
            ", id);
            return success > 0 ? "success" : "umm that didnt work";
        }
    }
}