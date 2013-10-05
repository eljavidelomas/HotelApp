using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Hoteles.Entities;
using System.Threading;

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
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                Application.Run(new fPrincipal2());
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + "-" + ex.StackTrace);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LoggerProxy.ErrorSinBD(e.Exception.Message + " - " + e.Exception.StackTrace);
            MessageBox.Show(e.Exception.Message);
        }
    }
}
