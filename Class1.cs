using System;
using System.Data.SqlClient;

namespace Addoreference
{
    public class Class1
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public void SelectData()
        {
            con = getcon();
            cmd = new SqlCommand("select * from emp where eid=12");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr[i] + " ");
                }
                Console.WriteLine();
            }
        }

        private static SqlConnection getcon()
        {
            con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=assess;Integrated Security=true");
            con.Open();
            return con;
        }
        public void InsertData(int eid, string efname, string elname, string city, string country, string phone)
        {
            try
            {
                con = getcon();
                cmd = new SqlCommand("intocus", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                /* cmd = new SqlCommand("insert into customer values(@eid,@efname,@elname,@city,@country,@phone)", con);*/
                cmd.Parameters.AddWithValue("@eid", eid);
                cmd.Parameters.AddWithValue("@efname", efname);
                cmd.Parameters.AddWithValue("@elname", elname);
                cmd.Parameters.AddWithValue("@city", city);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Connection = con;
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine(i + " rows affected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

    }
}
