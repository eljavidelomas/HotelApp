using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public class Conserje
    {
        public string nombre;
        public string apellido;
        public int usuario;
        public int clave;

        private Conserje(DataRow dr)
        {
            nombre = dr["nombre"].ToString();
            apellido = dr["apellido"].ToString();
            usuario = int.Parse(dr["usuario"].ToString());
            clave = int.Parse(dr["clave"].ToString());
        }

        public static Conserje obtenerConserjeActual()
        {
            DataSet ds = new DataSet();
            Conserje conserje;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from conserjes where logueado = 1", fPrincipal.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
                conserje = new Conserje(ds.Tables[0].Rows[0]);
            else
                conserje = null;

            return conserje;
        }

        public static Conserje Login(int usuario, int clave)
        {
            DataSet ds = new DataSet();
            using (SqlConnection connection = new SqlConnection(fPrincipal.conn.ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("conserjeLogin", connection);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                adapter.SelectCommand.Parameters.AddWithValue("@usuario", usuario);
                adapter.SelectCommand.Parameters.AddWithValue("@clave", clave);    
                adapter.Fill(ds);                
            }
            if (ds.Tables[0].Rows.Count > 0)            
                return new Conserje(ds.Tables[0].Rows[0]);

            return null;
        }
    }
}
