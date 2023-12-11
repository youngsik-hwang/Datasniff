using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datasniff
{
    public class MariaDB
    {                               
        public static string ConnectStr()
        {
            return string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4};"
                                         , "localhost", "3306", "manner", "root", "hhhsql");
        }
    }
}
