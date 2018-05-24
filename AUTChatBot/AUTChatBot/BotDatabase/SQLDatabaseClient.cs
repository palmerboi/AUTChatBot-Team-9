using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace AUTChatBot.BotDatabase
{
    public class SQLDatabaseClient
    {

        public static SqlConnection GetSQLConnection()
        {
            SqlConnectionStringBuilder cb = new SqlConnectionStringBuilder();
            cb.DataSource = "sqlserverautpapers.database.windows.net";
            cb.UserID = "group9";
            cb.Password = "Hello@world9";
            cb.InitialCatalog = "Team9SQLDatabase";

            return new SqlConnection(cb.ConnectionString);
        }

        public static Paper GetPaper(String PaperVar, Boolean PaperCode)
        {
            SqlConnection sqlC = GetSQLConnection();

            sqlC.Open();

            StringBuilder sb = new StringBuilder();

            if (!PaperCode)
            {
                sb.Append("SELECT PaperCode FROM Papers WHERE PaperName='" + PaperVar + "'");
            }
            else
            {
                sb.Append("SELECT PaperName FROM Papers WHERE PaperCode='" + PaperVar.ToUpper() + "'");
            }

            String sql = sb.ToString();

            using (SqlCommand command = new SqlCommand(sql, sqlC))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    if (PaperCode)
                    {
                        return new Paper(reader.GetString(0), PaperVar);
                    }
                    else
                    {
                        return new Paper(PaperVar, reader.GetString(0));
                    }
                }
            }
            
        }

        public class Paper
        {
            public String PaperName;
            public String PaperCode;
            public Paper(String PaperName, String PaperCode)
            {
                this.PaperCode = PaperCode;
                this.PaperName = PaperName;
            }
        }

        
    }
}