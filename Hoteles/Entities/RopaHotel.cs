using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public static class RopaHotel
    {
        static public DataTable ObtenerSaldoAnterior()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("ropaHotel_obtenerSaldoAnterior", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;            
            try
            {
                dataAdapter.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                LoggerProxy.Error("Falla en RopaHotel-ObtenerSaldoAnterior \r\n"+ex.Message + "-" + ex.StackTrace);
                return new DataTable();
            }
        }


        internal static void ActualizarSaldoFinal(Dictionary<int, int> saldoFinal)
        {
            try
            {
                SqlCommand comm;

                comm = new SqlCommand("ropaHotel_ActualizarSaldoFinal", fPrincipal2.conn);
                comm.CommandType = CommandType.StoredProcedure;
                
                foreach (int id in saldoFinal.Keys)
                {
                    comm.Parameters.AddWithValue("@id", id);
                    comm.Parameters.AddWithValue("@cant", saldoFinal[id]);                    
                    comm.ExecuteNonQuery();                    
                    comm.Parameters.RemoveAt("@id");
                    comm.Parameters.RemoveAt("@cant");                    
                }                
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
