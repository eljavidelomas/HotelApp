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
        public int cantidadConsumida;


        public Articulo(int id, string nombre, decimal precio,int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidadConsumida = cantidad;
        }
        static public DataTable obtenerListaArticulos()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("articulos_obtenerListado", fPrincipal2.conn);
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("articulos_obtenerConsumos", fPrincipal2.conn);
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

        static public Array obtenerNombrePrecioArticulo(int articuloId)
        {
            DataSet ds = new DataSet();
            Array datos = Array.CreateInstance(typeof(Object), 2);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("articulos_obtenerNombre", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@artId", articuloId);
            try
            {
                dataAdapter.Fill(ds);
                datos.SetValue((ds.Tables[0].Rows[0][0]).ToString(), 0);
                datos.SetValue(decimal.Parse((ds.Tables[0].Rows[0][1]).ToString()),1);
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        static public bool generarPedidoBar(fPrincipal2 fPrincipal, Dictionary<int, int> pedido, int nroHab)
        {
            try
            {
                SqlCommand comm;
                comm = new SqlCommand("articulos_insertar", fPrincipal2.conn);
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

                tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);
                //comm.CommandText = "listaTurnos_2";
                //comm.Parameters.Clear();
                //comm.Parameters.AddWithValue("@orden", tools.obtenerParametroString("ordenListado"));
                //fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        static public bool anularPedidoBar(fPrincipal2 fPrincipal, Dictionary<int, int> pedido, int nroHab)
        {
            try
            {
                SqlCommand comm;
                comm = new SqlCommand("articulos_anularPedido", fPrincipal2.conn);
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

                tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);
                //comm.CommandText = "listaTurnos_2";
                //comm.Parameters.Clear();
                //comm.Parameters.AddWithValue("@orden", tools.obtenerParametroString("ordenListado"));
                //fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
