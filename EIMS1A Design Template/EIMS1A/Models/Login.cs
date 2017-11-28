using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Sql;
using System.Data.SqlClient;

namespace EIMS1A.Models
{
    public class Login
    {
        
        public string username { get; set; }
        public string password { get; set; }
        public bool CHECKUSER(string username, string password)
        {
            bool flag = false;
            SqlConnection con = new SqlConnection("Data Source=10.208.11.65; Initial Catalog=EIMSDB1A; uid=sa; password=p@$$w0rd");
            con.Open();
            SqlCommand cmd = new SqlCommand(" Select * from users_master_1A where username ='" + username + "' and password='" + password + "'", con);
       
         flag = Convert.ToBoolean(cmd.ExecuteScalar());
            return flag;
        }
    }
   
}