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
        public string CreateUser(string firstNamePlaceholder, string lastNamePlaceholder, string emailPlaceholder, string passwordPlaceholder)
        {
            return $@"INSERT INTO Users ({User.FirstNameColumn}, {User.LastNameColumn}, {User.EmailColumn}, {User.PasswordColumn})
                     VALUES ({firstNamePlaceholder}, {lastNamePlaceholder}, {emailPlaceholder}, {passwordPlaceholder});";
        }
        public string GetUserById(string idPlaceholder)
        {
            return $"SELECT * FROM USERS WHERE Id = {idPlaceholder};";
        }
        public string GetUserByNameAndPasswordAndEmail()
        {
            return $"SELECT * FROM USERS WHERE Id = {idPlaceholder};";
        }
        public string UpdateUser(string firstNamePlaceholder, string lastNamePlaceholder, string passwordPlaceholder)
        {
            return $@"UPDATE Users
                     SET {User.FirstNameColumn} = {firstNamePlaceholder}, 
                         {User.LastNameColumn} = {lastNamePlaceholder},
                         {User.PasswordColumn} = {passwordPlaceholder};";
        }
    }
}
