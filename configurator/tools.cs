using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Configurator
{
      public static class tools
    {

        public static string obtenerParametroString(string parametro)
        {
            SqlCommand comm;
            comm = new SqlCommand("select val1_string from parametros where nombre = '" + parametro + "'", fConfigurator.conn);
            try
            {
                return comm.ExecuteScalar().ToString();    
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public static int obtenerParametroInt(string parametro)
        {
            SqlCommand comm;
            int result = 0;
            comm = new SqlCommand("select val1 from parametros where nombre = '" + parametro + "'", fConfigurator.conn);

            int.TryParse(comm.ExecuteScalar().ToString(), out result);

            return result;
        }
    }
}
