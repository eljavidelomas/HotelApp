using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Administrador.Entities;

namespace Administrador
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                LoggerProxy.Error("lalala");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FAdministrador());
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
                LoggerProxy.Info(ex.Message + " - " + ex.StackTrace);                
            }
        }
    }
}
