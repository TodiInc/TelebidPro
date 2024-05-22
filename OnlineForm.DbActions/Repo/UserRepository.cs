using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineForm.DbActions.SQLCommands;
using System.Data.SqlClient;

namespace OnlineForm.DbActions.Repo
{
    public class UserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void CreateUser()
        {
            
        }
        public void GetUser()
        {

        }
        public void UpdateUser()
        {

        }
    }
}
