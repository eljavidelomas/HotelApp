using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Hoteles.Entities;

namespace Hoteles
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {                
                Application.Run(new fPrincipal2());
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + "-" + ex.StackTrace);
            }
        }
    }
}
