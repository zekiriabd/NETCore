using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ORM
{
    public class DBUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class DBUserList
    {
        private static string connectionString = "Data Source=DESKTOP-MAGJ7HQ\\SQLEXPRESS;Initial Catalog=USER_Managment;User Id=sa;Password=talage;";
        private static cDatabaseAccess dbo = new cDatabaseConn(connectionString).dbo;
        public List<DBUser> GetUsers()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            DataTable tb = dbo.RunProcedure("SP_UESR_SelectAll", parameters, "USER").Tables[0];

            List<DBUser> oUsers = new List<DBUser>();
            foreach (DataRow row in tb.Rows)
            {
                oUsers.Add(new DBUser()
                {
                    UserId = Convert.ToInt16(row["USER_ID"]),
                    FirstName = row["FIRST_NAME"].ToString(),
                    LastName = row["LAST_NAME"].ToString()
                });
            };
            return oUsers;
        }

        public void SaveUser(DBUser newUser)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("FirstName", newUser.FirstName),
                new SqlParameter("LastName", newUser.LastName),
            };

            dbo.RunProcedure("SP_USER_Save", parameters, "USER");

        }
    }
}