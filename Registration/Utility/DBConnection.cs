using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace Registration.Utility
{
    public class DBConnection
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString; }
        }
        public static string dbProviderName
        {
            get { return ConfigurationManager.ConnectionStrings["LocalSqlServer"].ProviderName; }
        }
    }
}