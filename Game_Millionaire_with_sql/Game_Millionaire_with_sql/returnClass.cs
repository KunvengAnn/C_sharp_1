using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Millionaire_with_sql
{
    class returnClass
    {
        private string conStr = ConfigurationManager.ConnectionStrings["Question"].ConnectionString;

        public string scalarReturn(string q)
        {
            string s = " ";
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand(q,conn);
                s = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                s = " ";
            }
            return s;
        }
    }
}
