using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineForm.DbActions.Entity
{
    public class User
    {
        public const string EmailColumn = "Email";
        public const string FirstNameColumn = "FirstName";
        public const string LastNameColumn = "LastName";
        public const string PasswordColumn = "Password";

        public int Id { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
}