using System.Data;
using keepr_c.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace keepr_c.Repositories
{
    public class UserRepository : DbContext
    {
        public UserRepository(IDbConnection db) : base(db)
        {
        }

        public UserReturnModel Register(RegisterUserModel creds)
        {
            // encrypt the password??
            creds.Password = BCrypt.Net.BCrypt.HashPassword(creds.Password);
            //sql
            try
            {

                int id = _db.ExecuteScalar<int>(@"
                INSERT INTO users (Username, Email, Password, AvatarUrl, FirstName, LastName)
                VALUES (@Username, @Email, @Password, @AvatarUrl, @FirstName, @LastName);
                SELECT LAST_INSERT_ID();
            ", creds);

                return new UserReturnModel()
                {
                    Id = id,
                    Username = creds.Username,
                    Email = creds.Email,
                    AvatarUrl = creds.AvatarUrl,
                    FirstName = creds.FirstName,
                    LastName = creds.LastName
                };
            }
            catch (MySqlException e)
            {
                System.Console.WriteLine("ERROR: " + e.Message);
                return null;
            }
        }

        public UserReturnModel Login(LoginUserModel creds)
        {
            // more sql
            User user = _db.QueryFirstOrDefault<User>(@"
                SELECT * FROM users WHERE email = @Email
            ", creds);
            if (user != null)
            {
                var valid = BCrypt.Net.BCrypt.Verify(creds.Password, user.Password);
                if (valid)
                {
                    return user.GetReturnModel();
                }
            }
            return null;
        }

        //Shouldn't lookup by email?
        //If you want to use below you need to re-enable a line found in
        // UserReturnModel.cs
        #region GetUserByEmail-Function-Unused
        // internal UserReturnModel GetUserByEmail(string email)
        // {
        //     User user = _db.QueryFirstOrDefault<User>(@"
        //         SELECT * FROM sharpusers WHERE email = @Email
        //     ", new { email });
        //     return user.GetReturnModel();
        // }
        #endregion

        internal UserReturnModel GetUserById(string id)
        {
            User savedUser = _db.QueryFirstOrDefault<User>(@"
            SELECT * FROM users WHERE id = @id
            ", new { id });
            if (savedUser != null)
            {
                return savedUser.GetReturnModel();
            }
            return null;
        }

        internal UserReturnModel UpdateUser(UserReturnModel user)
        {
            var i = _db.Execute(@"
                UPDATE users SET
                    email = @Email,
                    username = @Username
                WHERE id = @id
            ", user);
            if (i > 0)
            {
                return user;
            }
            return null;

        }

        internal string ChangeUserPassword(ChangeUserPasswordModel user)
        {
            User savedUser = _db.QueryFirstOrDefault<User>(@"
            SELECT * FROM users WHERE id = @id
            ", user);

            var valid = BCrypt.Net.BCrypt.Verify(user.OldPassword, savedUser.Password);
            if (valid)
            {
                user.NewPassword = BCrypt.Net.BCrypt.HashPassword(user.NewPassword);
                var i = _db.Execute(@"
                    UPDATE users SET
                        password = @NewPassword
                    WHERE id = @id
                ", user);
                return "Good Job";
            }
            return "Umm nope!";
        }
    }
}