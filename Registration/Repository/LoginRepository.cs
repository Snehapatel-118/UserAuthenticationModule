using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Configuration;
using Registration.Models;
using Registration.Utility;

namespace Registration.Repository
{
    public class LoginRepository
    {
        public EMPRegistration GetEmployee(string Email, string password)
        {
            EMPRegistration user = null;
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
                {
                    SqlCommand selectCommand = new SqlCommand("Employee_Login", connection);
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.AddWithValue("@Password", password);
                    selectCommand.Parameters.AddWithValue("@Email", Email);
                    SqlDataAdapter da = new SqlDataAdapter(selectCommand);
                    connection.Open();
                    da.Fill(dataTable);
                    connection.Close();
                    if ((dataTable != null) && (dataTable.Rows.Count > 0))
                    {
                        user = new EMPRegistration();
                        user.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return user;
        }
    }
}