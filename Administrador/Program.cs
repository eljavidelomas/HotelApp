using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Administrador.Entities;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

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
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FAdministrador());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message + "\r\n" + ex.StackTrace,"Excepcion - El programa se cerrara");
                LoggerProxy.ErrorSinBD(ex.Message + " - " + ex.StackTrace);                              
            }
        }
    }
}
