using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Model
{
    class Model
    {
        int anio;

        public int Anio { get => anio; set => anio = value; }

        public DataTable MostrarTabla()
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(Connect.c);
            SqlCommand cmd = new SqlCommand("exec dbo.ProcEmpleadosRec @Anio", con);

            cmd.Parameters.Add("@Anio", Anio);

            con.Open();
            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(dt);
            con.Close();
            da.Dispose();
            return dt;
        }
    }
}
