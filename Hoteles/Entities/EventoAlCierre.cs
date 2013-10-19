using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Hoteles.Entities
{
    public class EventoAlCierre
    {
        public int id;
        public string nombre;
        public int stock;
        public decimal precio;
        public bool promo;
        public int cantidadConsumida;


        public static void grabarApertura(int habitacion, string detalle)
        {
            try
            {
                SqlCommand comm;
                comm = new SqlCommand("eventosCierre_insertarApertura", fPrincipal2.conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@habitacion", habitacion);
                if (!String.IsNullOrEmpty(detalle))                             
                    comm.Parameters.AddWithValue("@detalle", detalle);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Fallo la grabacion de Eventos Al Cierre \r\n" + ex.Message + "-" + ex.StackTrace);
            }
        }

        public static void grabarCierre(int habitacion,string detalle)
        {
            try
            {
                SqlCommand comm;
                comm = new SqlCommand("eventosCierre_insertarCierre", fPrincipal2.conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@habitacion", habitacion);
                if(!String.IsNullOrEmpty(detalle))
                    comm.Parameters.AddWithValue("@detalle", detalle);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Fallo la grabacion de Eventos Al Cierre \r\n" + ex.Message + "-" + ex.StackTrace);
            }
        }

        public static DataTable consultarBitacora()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("eventosCierre_consultar", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                return ds.Tables[0];
            }
            
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Fallo la grabacion de Eventos Al Cierre \r\n" + ex.Message + "-" + ex.StackTrace);
                return null;
            }
            
        }
    }
}
