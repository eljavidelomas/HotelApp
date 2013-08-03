using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hoteles.Entities
{
    static public class LoggerProxy
    {        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static public void Info(string msj)
        {
            if (tools.obtenerParametroInt("loggin") == 1)
                log.Info(msj);
        }

        static public void Error(string msj)
        {
            if (tools.obtenerParametroInt("loggin") == 1)
                log.Error(msj);
        }

        static public void ErrorSinBD(string msj)
        {            
                log.Error(msj);
        }

    }
}
