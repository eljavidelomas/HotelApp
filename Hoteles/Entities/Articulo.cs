using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Hoteles.Entities
{
    public class Articulo
    {
        public int id;
        public string nombre;
        public int stock;
        public decimal precio;
        public bool promo;


        public Articulo(int id, string nombre, decimal precio)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
        }
        static public DataTable obtenerListaArticulos()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("articulos_obtenerListado", fPrincipal.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static public DataTable obtenerConsumos(int nroHab)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("articulos_obtenerConsumos", fPrincipal.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            try
            {
                dataAdapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static public bool generarPedidoBar(fPrincipal fPrincipal, Dictionary<int, int> pedido, int nroHab)
        {
            try
            {
                SqlCommand comm;
                comm = new SqlCommand("articulos_insertar", fPrincipal.conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@nroHab", nroHab);

                foreach (int nroArt in pedido.Keys)
                {
                    comm.Parameters.AddWithValue("@nroArt", nroArt);
                    comm.Parameters.AddWithValue("@cant", pedido[nroArt]);
                    comm.ExecuteNonQuery();
                    comm.Parameters.RemoveAt("@nroArt");
                    comm.Parameters.RemoveAt("@cant");
                }

                comm.CommandText = "listaTurnos";
                comm.Parameters.Clear();
                fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

    }
}
