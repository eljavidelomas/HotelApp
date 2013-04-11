using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Hoteles.Entities
{
    public class Gasto
    {
        public int id;
        public int cuentaId;
        public DateTime fecha;
        public decimal monto;
        public int conserjeId;
        public int cierreId;


        public Gasto(DataRow dr)
        {
            id = int.Parse(dr["id"].ToString());
            cuentaId = int.Parse(dr["cuentaGastoId"].ToString());
            fecha = DateTime.Parse(dr["fecha"].ToString());
            monto = decimal.Parse(dr["monto"].ToString());
            conserjeId = int.Parse(dr["conserjeId"].ToString());
            cierreId = int.Parse(dr["cierreId"].ToString());
        }


        static public DataTable obtenerListaCuentasGastos()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from cuentasGastos", fPrincipal.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.Text;
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

        static public DataTable obtenerGastos(int conserjeId)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("gastos_obtenerListado", fPrincipal.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@conserjeId", conserjeId);
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
                
        internal static void insertar(int nroCuenta, decimal monto)
        {
            try
            {
                SqlCommand comm;
                comm = new SqlCommand("gastos_insertar", fPrincipal.conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@nroCuenta", nroCuenta);
                comm.Parameters.AddWithValue("@monto", monto);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static void devolver(int nroCuenta, decimal monto)
        {
            try
            {
                SqlCommand comm;
                comm = new SqlCommand("gastos_devolver", fPrincipal.conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@nroCuenta", nroCuenta);
                comm.Parameters.AddWithValue("@monto", monto);
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
