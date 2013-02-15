using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public class Tarifa
    {
        public int id;

        public int categoriaId;
        public int catOriginalId;
        public DateTime desde;
        public DateTime hasta;
        public int dia;
        public int duracion;
        public decimal precio;
        public decimal precioMinuto;
        public bool pernocte;
        public int extension;
        public decimal precioTN;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Tarifa()
        {
            id = 0;
        }

        private Tarifa(DataRow dr)
        {
            id = int.Parse(dr["id"].ToString());
            if (id > 0)
            {
                categoriaId = int.Parse(dr["catId"].ToString());
                catOriginalId = int.Parse(dr["catOriginalId"].ToString());
                desde = DateTime.Parse(dr["desde"].ToString());
                hasta = DateTime.Parse(dr["hasta"].ToString());
                int.TryParse(dr["dia"].ToString(), out dia);
                int.TryParse(dr["duracion"].ToString(), out duracion);
                decimal.TryParse(dr["precio"].ToString(), out precio);
                decimal.TryParse(dr["precioMinuto"].ToString(), out precioMinuto);
                int.TryParse(dr["extension"].ToString(), out extension);
                decimal.TryParse(dr["precioTN"].ToString(), out precioTN);
                bool.TryParse(dr["pernocte"].ToString(), out pernocte);
            }


        }

        public static Tarifa obtenerTarifaActual(int nroHab, DateTime hora)
        {
            DataSet ds = new DataSet();
            Tarifa tarifa;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("obtenerTarifaConId", fPrincipal.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            if (hora != DateTime.MinValue)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@hora", hora);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                tarifa = new Tarifa(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    log.Info("Tarifa.obtenerTarifaActual - No se encontro tarifa. Datos: SP:obtenerTarifaConId; nroHab:" + nroHab + " hora:" + hora.ToString("yyyy-MM-dd HH:mm:ss"));                    
                }
                else
                    log.Error("Tarifa.obtenerTarifaActual = " + ex.Message + ex.StackTrace);
                
                tarifa = null;
            }

            return tarifa;
        }


    }
}
