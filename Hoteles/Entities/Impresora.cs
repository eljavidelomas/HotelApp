using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Drawing;
using Hoteles.Properties;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Hoteles.Entities
{
    class Impresora
    {
        private Font fuente = new Font("Arial", 12);
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Dictionary<int, int> pedidoBar;
        int NroHab;

        public void ImprimirSolicitudBar(Label msjError, Dictionary<int, int> artPedidos, int nroHab)
        {
            try
            {
                pedidoBar = artPedidos;
                NroHab = nroHab;
                PrintDocument formulario = new PrintDocument();
                string ticket = Settings.Default.ticketCocina.Replace("##FECHA", DateTime.Now.ToString("dd-MM-yyyy")).
               Replace("##HORA", DateTime.Now.ToShortTimeString()).Replace("##NRO", obtenerNroTicketCocina().ToString()).
               Replace("##HAB", this.NroHab.ToString());
                foreach (int articulo in pedidoBar.Keys)
                {
                    ticket = ticket + pedidoBar[articulo].ToString().PadLeft(3, ' ') + "   " + Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(0).ToString().PadRight(20, ' ') + ((decimal)Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(1) * pedidoBar[articulo]).ToString().PadLeft(8, ' ') + "\r\n";
                }
                try
                {
                    StreamWriter sw = new StreamWriter(Settings.Default.archImprimir);
                    ticket = ticket.Replace("\\r", "\r").Replace("\\n", "\n");
                    sw.Write(ticket);
                    sw.Close();
                    formulario.PrintPage += new PrintPageEventHandler(imprimirArchivo);
                    formulario.PrintController = new StandardPrintController();
                    formulario.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[2];//Seleccionar impresora cocina
                    formulario.Print();
                }
                catch (Exception e)
                {
                    msjError.Text = e.Message;
                }
            }
            catch (Exception ex)
            {
                msjError.Text = ex.Message;
                log.Error(ex.Message + " - " + ex.StackTrace);
            }

        }

        private void Pedido_Bar(object obj, PrintPageEventArgs ev)
        {
            float pos_x = 10;
            float pos_y = 20;
            string ticket = Settings.Default.ticketCocina.Replace("##FECHA", DateTime.Now.ToString("dd-MM-YYYY")).
                Replace("##HORA", DateTime.Now.ToShortTimeString()).Replace("##NRO", obtenerNroTicketCocina().ToString()).
                Replace("##HAB", this.NroHab.ToString());
            foreach (int articulo in pedidoBar.Keys)
            {
                ticket = ticket + pedidoBar[articulo] + " " + Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(0) + " " + Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(1) + "\r\n";
            }

            ev.Graphics.DrawString(ticket, fuente, Brushes.Black, pos_x, pos_y, new StringFormat());

        }

        private void imprimirArchivo(object obj, PrintPageEventArgs e)
        {
            float yPos = 0f;
            int count = 0;
            float leftMargin = 25;// e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;
            Font printFont = new System.Drawing.Font("consolas", 8);
            float linesPerPage = e.MarginBounds.Height / printFont.GetHeight(e.Graphics);
            StreamReader fileToPrint = new System.IO.StreamReader(Settings.Default.archImprimir);

            while (count < linesPerPage)
            {
                line = fileToPrint.ReadLine();
                if (line == null)
                {
                    break;
                }
                yPos = topMargin + count * printFont.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null)
            {
                e.HasMorePages = true;
            }
        }

        private int obtenerNroTicketCocina()
        {
            SqlCommand comm;
            comm = new SqlCommand("parametros_obtenerNroTicketCocina", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;
            return (int)comm.ExecuteScalar();
        }

        private int obtenerNroPlanilla()
        {
            SqlCommand comm;
            comm = new SqlCommand("parametros_obtenerNroPlanilla", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;
            return (int)comm.ExecuteScalar();
        }

        internal void ImprimirPlanillaCierre(List<FilaPlanilla> filas, Totales totales,decimal efectivoInicial, decimal efectivoEnCaja, Conserje conserje, Label msjError)
        {
            try
            {

                PrintDocument formulario = new PrintDocument();
                string ticket = Settings.Default.planillaCierre.
                    Replace("##conserjeId", conserje.usuario.ToString().PadRight(7)).
                    Replace("##conserjeNm", (conserje.nombre + " " + conserje.apellido).PadRight(20)).
                    Replace("##fecha", String.Format("{0:ddd}", DateTime.Now).ToUpper() + " " + DateTime.Now.ToString("dd/MM/yyyy")).
                    Replace("##hora", DateTime.Now.ToShortTimeString());
                    
                    

                foreach (FilaPlanilla fila in filas)
                {
                    ticket = ticket + "\r\n" + fila.ToString();
                }
                ticket += "\r\n" + "".PadRight(124, '=') + "\r\n" +
                       String.Format("{0:N2}",totales.totalTurnos).PadLeft(41) + "    " +
                       String.Format("{0:N2}",totales.totalExtras).PadLeft(6) + "    " +
                       String.Format("{0:N2}",totales.totalBar).PadLeft(6) + "    " +
                       String.Format("{0:N2}",totales.totalDescuento).PadLeft(6) + "     " +
                       String.Format("{0:N2}",totales.totalTotal).PadLeft(8) + "    " +
                       String.Format("{0:N2}",totales.totalEfectivo).PadLeft(8) + "   " +
                       String.Format("{0:N2}",totales.totalTarjeta).PadLeft(8) + "    " +
                       String.Format("{0:N2}",totales.totalGastos).PadLeft(8)+ "\r\n";
                
                decimal ingEgre = totales.totalEfectivo - totales.totalGastos;

                ticket += "\r\n" + "".PadLeft(70) + "Saldo Inicial  :  " + String.Format("{0:N2}",efectivoInicial).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Ingreso-Egreso :  " + String.Format("{0:N2}",ingEgre).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Total en Caja  :  " + String.Format("{0:N2}",(efectivoInicial + ingEgre)).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Deposito buzón :  " + String.Format("{0:N2}",(efectivoInicial + ingEgre - efectivoEnCaja)).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Queda en Caja  :  " + String.Format("{0:N2}",efectivoEnCaja).PadLeft(8);

                try
                {
                    StreamWriter sw = new StreamWriter(Settings.Default.archImprimir);
                    ticket = ticket.Replace("\\r", "\r").Replace("\\n", "\n");
                    sw.Write(ticket);
                    sw.Close();
                    formulario.PrintPage += new PrintPageEventHandler(imprimirArchivo);
                    formulario.PrintController = new StandardPrintController();
                    formulario.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[2];//Seleccionar impresora cocina
                    formulario.OriginAtMargins = false;
                    formulario.PrinterSettings.DefaultPageSettings.Margins = new Margins(1, 1, 1, 1); // PrinterSettings.DefaultPageSettings.Margins.Left = 25;
                    formulario.Print();
                }
                catch (Exception e)
                {
                    msjError.Text = e.Message;
                }
            }
            catch (Exception ex)
            {
                msjError.Text = ex.Message;
                log.Error(ex.Message + " - " + ex.StackTrace);
            }
        }
    }
}
