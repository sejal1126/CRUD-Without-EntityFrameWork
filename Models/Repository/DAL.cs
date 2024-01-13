using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication2.Models.Repository
{
    public class DAL
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        public List<StudentRegistratonModel> GetDetails()

        {
            List<StudentRegistratonModel> lst = new List<StudentRegistratonModel>();
            SqlCommand cmd = new SqlCommand("sp_select",con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                lst.Add(new StudentRegistratonModel
                {
                    id = Convert.ToInt32(dr[0]),
                    email = Convert.ToString(dr[1]),
                   password = Convert.ToString(dr[2]),
                    name = Convert.ToString(dr[3]),
                });
            }
            return lst;
        }

        public bool Insertdetails(StudentRegistratonModel sr)
        {
            SqlCommand cmd = new SqlCommand("sp_insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",sr.id);
            cmd.Parameters.AddWithValue("@email", sr.email);
            cmd.Parameters.AddWithValue("@password", sr.password);
            cmd.Parameters.AddWithValue("@name", sr.name);
            con.Open();
            int i = 0;
            i=cmd.ExecuteNonQuery();
            con.Close();
            if (i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
          
        }
        public bool updatedetails(StudentRegistratonModel sr)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", sr.id);
            cmd.Parameters.AddWithValue("@email", sr.email);
            cmd.Parameters.AddWithValue("@password", sr.password);
            cmd.Parameters.AddWithValue("@name", sr.name);
            con.Open();
            int i = 0;
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool deletedetails(StudentRegistratonModel sr)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", sr.id);
            con.Open();
            int i = 0;
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}