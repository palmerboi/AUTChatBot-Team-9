using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace AUTChatBot.BotDatabase
{
    public class SQLDatabaseClient
    {

        public SqlConnection GetSQLConnection()
        {
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
            cb.DataSource = "sqlserverautpapers.database.windows.net";
        }

        
    }
}