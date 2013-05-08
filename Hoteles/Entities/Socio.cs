using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public class Socio
    {
        public int id;
        public int nroSocio;
        public int puntaje;
        public DateTime fechaAlta;
        public DateTime fechaVencimientoPuntaje;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Socio()
        {
            id = 0;
        }

        private Socio(DataRow dr)
        {
            id = int.Parse(dr["id"].ToString());
            nroSocio = int.Parse(dr["nroSocio"].ToString());
            puntaje = int.Parse(dr["puntos"].ToString());
            fechaAlta = DateTime.Parse(dr["fechaAltaSocio"].ToString());
            DateTime.TryParse(dr["fechaVencimientoPuntaje"].ToString(), out fechaVencimientoPuntaje);
        }

        public static Socio registrarYobtener(int nroSocio)
        {
            Socio socio;
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("socios_registrar", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroSocio", nroSocio);
            try
            {
                dataAdapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    socio = new Socio(ds.Tables[0].Rows[0]);
                else
                    socio = null;
            }
            catch (Exception ex)
            {
                log.Error("Socio - registrarYobtener = "+ex.Message+ex.StackTrace);
                socio = null;
            }

            return socio;
        }


        internal void descontarPuntos(int puntos)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("socios_descontarPuntos", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@puntos", puntos);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroSocio", this.nroSocio);
            try
            {
                dataAdapter.Fill(new DataSet());
                this.puntaje -= puntos;
            }
            catch (Exception ex)
            {
                log.Error("Socio - registrarYobtener = " + ex.Message + ex.StackTrace);                
            }
        }
    }
}
