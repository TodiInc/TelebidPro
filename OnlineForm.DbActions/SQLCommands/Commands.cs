using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineForm.DbActions.Entity;

namespace OnlineForm.DbActions.SQLCommands
{
    internal class Commands
    {
        // User sql commands
        public string CreateUser()
        {
            return $@"INSERT INTO Users ({User.FirstNameColumn}, {User.LastNameColumn}, {User.EmailColumn}, {User.PasswordColumn})
                     VALUES ('Todi','Boi','todiboi@gmail.com','nqmavreme');";
        }
        public string GetUser()
        {
            return "SELECT Id FROM USERS WHERE Id = 1";
        }
        public string UpdateUser()
        {
            return $@"UPDATE Users
                     SET {User.FirstNameColumn} = 'Yogi', 
                         {User.LastNameColumn} = 'Lori', 
                         {User.EmailColumn} = 'yogilori@gmail.com', 
                         {User.PasswordColumn} = 'vecheimavreme';";
        }
    }
}
