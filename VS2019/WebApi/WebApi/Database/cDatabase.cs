using System.Data;
using System.Data.SqlClient;
using WebApi.Models;

namespace WebApi.DB
{
    public static class cDatabase
    {
        private static string connectionString = "Data Source=DESKTOP-MAGJ7HQ\\SQLEXPRESS;Initial Catalog=USER_Managment;User Id=sa;Password=talage;";
        private static cDatabaseAccess dbo = new cDatabaseConn(connectionString).dbo;
        public static DataTable GetUsers()
        {
            SqlParameter[] parameters = new SqlParameter[] { };
            return dbo.RunProcedure("SP_UESR_SelectAll", parameters, "USER").Tables[0];
        }
       
        public static void SaveUser(User newUser)
        {
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("FirstName", newUser.FirstName),
                new SqlParameter("LastName", newUser.LastName),
            };

            dbo.RunProcedure("SP_USER_Save", parameters, "USER");

        }

    }
}