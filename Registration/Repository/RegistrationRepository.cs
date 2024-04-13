using Registration.Models;
using Registration.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;


namespace Registration.Repository
{
        public class RegistrationRepository
        {
            public int ManageUsers(EMPRegistration model)
            {
                Int32 count;

                try
                {
                    using (SqlConnection con = new SqlConnection(DBConnection.ConnectionString))
                    {
                        Security secu = new Security();
                        string str = string.Empty;
                        if (model.Password != null)
                        {
                            str = secu.Encrypt(model.Password);
                        }
                        SqlCommand com = new SqlCommand("Emp_Registration", con);
                        com.CommandType = CommandType.StoredProcedure;
                        com.Parameters.AddWithValue("@Id", model.Id);
                        com.Parameters.AddWithValue("@FirstName", model.FirstName);
                        com.Parameters.AddWithValue("@LastName", model.LastName);
                        com.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                        com.Parameters.AddWithValue("@Email", model.Email);
                        com.Parameters.AddWithValue("@Password", str);

                        SqlDataAdapter da = new SqlDataAdapter(com);
                        con.Open();
                        count = Convert.ToInt32(com.ExecuteScalar());
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    count = -1;
                }
                return count;
            }

        }
    }
