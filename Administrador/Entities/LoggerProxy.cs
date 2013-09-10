using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Administrador.Entities
{
    static public class LoggerProxy
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static public void Info(string msj)
        {

            log.Info(msj);
        }

        static public void Error(string msj)
        {

            log.Error(msj);
        }

        static public void ErrorSinBD(string msj)
        {
            log.Error(msj);
        }

    }
}
