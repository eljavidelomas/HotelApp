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
        PrintDocument formulario = new PrintDocument();
        private Font fuente;
        private int tipoImpresion = 0;
        int NroHab;
        int cantLineas;
        List<string> textoAImprimir= null;

        #region Metodos Internos

        internal void ImprimirSolicitudBar(Label msjError, Dictionary<int, int> artPedidos, int nroHab)
        {
            Dictionary<int, int> pedidoBar;

            try
            {
                pedidoBar = artPedidos;
                NroHab = nroHab;

                string ticket = Settings.Default.ticketCocina.Replace("##FECHA", DateTime.Now.ToString("dd-MM-yyyy")).
                    Replace("##HORA", DateTime.Now.ToShortTimeString()).Replace("##NRO", obtenerNroTicketCocina().ToString()).
                    Replace("##HAB", this.NroHab.ToString());
                foreach (int articulo in pedidoBar.Keys)
                {
                    ticket = ticket + pedidoBar[articulo].ToString().PadLeft(3, ' ') + "   " + Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(0).ToString().PadRight(20, ' ') + ((decimal)Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(1) * pedidoBar[articulo]).ToString().PadLeft(8, ' ') + "\r\n";
                }
                try
                {
                    guardarArchivoTemp(ticket,out cantLineas);
                    if (tools.obtenerParametroString("emisionPedidos") == "Duplicado")
                        tipoImpresion = 2;//Bar duplicado                    
                    formulario.PrinterSettings.PrinterName = obtenerImpresora("Cocina");//Seleccionar impresora cocina                    
                    configurarImpresora(ref formulario,cantLineas,0);
                    formulario.Print();
                }
                catch (Exception e)
                {
                    msjError.Text = e.Message;
                    LoggerProxy.Error(e.Message + " - " + e.StackTrace);
                }
            }
            catch (Exception ex)
            {
                msjError.Text = ex.Message;
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
            }

        }

        internal void ImprimirGasto(Label msjError, decimal monto, string gasto)
        {
            try
            {                
                string ticket = Settings.Default.ticketGasto.Replace("##FECHA", DateTime.Now.ToString("dd-MM-yyyy")).
                Replace("##HORA", DateTime.Now.ToShortTimeString()).Replace("##NRO", obtenerNroTicketCocina().ToString());
                ticket = ticket + string.Format("{0:C}", monto).PadLeft(8) + "    " + gasto + "\r\n";

                try
                {                    
                    guardarArchivoTemp(ticket,out cantLineas);
                    configurarImpresora(ref formulario, cantLineas,0);                    
                    formulario.PrinterSettings.PrinterName = obtenerImpresora("Tickets");// PrinterSettings.InstalledPrinters[2];//Seleccionar impresora cocina
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
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
            }

        }

        internal void ImprimirPlanillaCierre(List<FilaPlanilla> filas, Totales totales, decimal efectivoInicial, decimal efectivoEnCaja, Conserje conserje, Label msjError)
        {
            try
            {
                //--------  Listado Articulos

                string stockArt = Settings.Default.listadoArtStock.
                    Replace("##nmHotel", tools.obtenerParametroString("nombreHotel").PadRight(45));

                List<FilaListArt> articulosConsumidos = obtenerArticulosConsumidos(tools.obtenerParametroString("stockCierreCaja"));

                foreach (FilaListArt fila in articulosConsumidos)
                {
                    stockArt = stockArt + "\r\n" + fila.ToString();
                }
                stockArt += "\r\n\r\n\r\n\r\n";
                //--------  Fin Listado Articulos


                //--------  Planilla cierre turnos

                string planillaCierre = Settings.Default.planillaCierre.
                    Replace("##conserjeId", conserje.usuario.ToString().PadRight(7)).
                    Replace("##conserjeNm", (conserje.nombre + " " + conserje.apellido).PadRight(20)).
                    Replace("##fecha", String.Format("{0:ddd}", DateTime.Now).ToUpper() + " " + DateTime.Now.ToString("dd/MM/yyyy")).
                    Replace("##hora", DateTime.Now.ToString("HH:mm")).
                    Replace("##nroArq", obtenerNroPlanilla().ToString());

                foreach (FilaPlanilla fila in filas)
                {
                    planillaCierre = planillaCierre + "\r\n" + fila.ToString();
                }
                planillaCierre += "\r\n" + "".PadRight(124, '=') + "\r\n" +
                       String.Format("{0:N2}", totales.totalTurnos).PadLeft(41) + "    " +
                       String.Format("{0:N2}", totales.totalExtras).PadLeft(6) + "    " +
                       String.Format("{0:N2}", totales.totalBar).PadLeft(6) + "    " +
                       String.Format("{0:N2}", totales.totalDescuento).PadLeft(6) + "     " +
                       String.Format("{0:N2}", totales.totalTotal).PadLeft(8) + "    " +
                       String.Format("{0:N2}", totales.totalEfectivo).PadLeft(8) + "   " +
                       String.Format("{0:N2}", totales.totalTarjeta).PadLeft(8) + "    " +
                       String.Format("{0:N2}", totales.totalGastos).PadLeft(8) + "\r\n";

                decimal ingEgre = totales.totalEfectivo - totales.totalGastos;

                planillaCierre += "\r\n" + "".PadLeft(70) + "Saldo Inicial  :  " + String.Format("{0:N2}", efectivoInicial).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Ingreso-Egreso :  " + String.Format("{0:N2}", ingEgre).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Total en Caja  :  " + String.Format("{0:N2}", (efectivoInicial + ingEgre)).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Deposito buzón :  " + String.Format("{0:N2}", (efectivoInicial + ingEgre - efectivoEnCaja)).PadLeft(8) +
                          "\r\n" + "".PadLeft(70) + "Queda en Caja  :  " + String.Format("{0:N2}", efectivoEnCaja).PadLeft(8);

                planillaCierre += "\r\n\r\n\r\n\r\n";
                //------    Fin planilla cierre turno

                string ticketRopaConsumida = "";
                if (tools.obtenerParametroInt("consumoRopaCierre") == 1)
                {
                    //--------  Planilla Ropa Consumida
                    ticketRopaConsumida = Settings.Default.listadoRopaConsumida;
                    List<FilaRopaConsumida> ropaConsumida = obtenerRopaConsumida();

                    foreach (FilaRopaConsumida fila in ropaConsumida)
                    {
                        if (fila.categoria == "TOTAL")
                            ticketRopaConsumida += "\r\n";
                        ticketRopaConsumida += fila.ToString() + "\r\n";
                    }
                    //--------  Fin Planilla Ropa Consumida
                }

                try
                {                    
                    string ticketSalida = stockArt + planillaCierre + ticketRopaConsumida;
                    guardarArchivoTemp(ticketSalida,out cantLineas);
                    configurarImpresora(ref formulario,cantLineas,8);                    
                    formulario.PrinterSettings.PrinterName = obtenerImpresora("Caja");//Seleccionar impresora Caja
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
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
            }
        }


       private void configurarImpresora(ref PrintDocument form,int cantLineas,float tamFuente)
        {
            float tamFuenteAux = tamFuente == 0 ? 16 : (float)tamFuente;
            //form.DefaultPageSettings.PaperSize = form.PrinterSettings.PaperSizes[((int)PaperKind.A3) - 1];
            form.PrintController = new StandardPrintController();
            form.PrintPage += new PrintPageEventHandler(imprimirArchivo);
            fuente = new System.Drawing.Font("consolas", tamFuenteAux);
            float tamPorLinea = fuente.GetHeight(form.PrinterSettings.CreateMeasurementGraphics());
            float altoHoja = (cantLineas + 1) * tamPorLinea;
            if (altoHoja > 1088)//alto hoja A4
                //altoHoja = 1188;
                altoHoja = 4 * tamPorLinea;
            form.DefaultPageSettings.PaperSize = new PaperSize("Custom", 960,(int) Math.Ceiling(altoHoja));
            form.DefaultPageSettings.Margins = new Margins(60, 60, 0, 0);// 1 mm  X 4 = 60  => 60 = 15 mm            
            
        }

        #endregion

        #region Metodos privados

        private void imprimirArchivo(object obj, PrintPageEventArgs e)
        {
            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;

            float linesPerPage = e.MarginBounds.Height / fuente.GetHeight(e.Graphics);
            //StreamReader fileToPrint = new System.IO.StreamReader(Settings.Default.archImprimir);
            if (textoAImprimir == null)
            {
                textoAImprimir = new List<string>();
                String aux;
                StreamReader fileToPrint = new StreamReader(Settings.Default.archImprimir);
                while ((aux = fileToPrint.ReadLine()) != null)
                    textoAImprimir.Add(aux);
            }

            while (count < (int)linesPerPage)
            {
                if (textoAImprimir.Count == 0)
                {
                    e.HasMorePages = false;
                    return;
                }
                line = textoAImprimir[0];
                textoAImprimir.RemoveAt(0);
                yPos = topMargin + count * fuente.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, fuente, Brushes.Black, leftMargin, yPos, new StringFormat());
                if(tipoImpresion==2)//barDoble
                    e.Graphics.DrawString(line, fuente, Brushes.Black, e.PageSettings.PaperSize.Width / 2, yPos, new StringFormat());
                count++;
            }

            if (textoAImprimir.Count > 0 )
            {
                e.HasMorePages = true;
            }
        }

        private void guardarArchivoTemp(string ticket,out int CantLineas)
        {
            CantLineas = 0;

            StreamWriter sw = new StreamWriter(Settings.Default.archImprimir);
            ticket = ticket.Replace("\\r", "\r").Replace("\\n", "\n");
            cantLineas = ticket.Replace("\r\n","\n").Split('\n').Count();
            sw.Write(ticket);           
            sw.Close();            
        }

        private void imprimirArchivoDoble(object obj, PrintPageEventArgs e)
        {
            float yPos = 0f;
            int count = 0;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            string line = null;

            float linesPerPage = e.MarginBounds.Height / fuente.GetHeight(e.Graphics);
            if (textoAImprimir == null)
            {
                textoAImprimir = new List<string>();
                String aux;
                StreamReader fileToPrint = new StreamReader(Settings.Default.archImprimir);
                while ((aux = fileToPrint.ReadLine()) != null)
                    textoAImprimir.Add(aux);
            }
            
            while (count < linesPerPage)
            {
                //line = fileToPrint.ReadLine();
                if (textoAImprimir.Count == 0)
                {
                    e.HasMorePages = false;
                    return;
                }
                line = textoAImprimir[0];
                textoAImprimir.RemoveAt(0);
                //if (line == null)
                //{
                //    break;
                //}
                yPos = topMargin + count * fuente.GetHeight(e.Graphics);
                e.Graphics.DrawString(line, fuente, Brushes.Black, leftMargin, yPos, new StringFormat());
                e.Graphics.DrawString(line, fuente, Brushes.Black, e.PageSettings.PaperSize.Width / 2, yPos, new StringFormat());
                count++;
            }
            if (textoAImprimir.Count > 0)
            {
                e.HasMorePages = true;
            }
        }

        private int obtenerNroTicketCocina()
        {
            SqlCommand comm;
            comm = new SqlCommand("parametros_obtenerNroTicketCocina", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;
            return (int)comm.ExecuteScalar();
        }

        private int obtenerNroPlanilla()
        {
            SqlCommand comm;
            comm = new SqlCommand("parametros_obtenerNroPlanilla", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;
            return (int)comm.ExecuteScalar();
        }

        private string obtenerImpresora(string impresora)
        {
            SqlCommand comm;
            comm = new SqlCommand("select val1_string from parametros where nombre = 'Impresora" + impresora + "'", fPrincipal2.conn);

            return comm.ExecuteScalar().ToString();
        }

        private List<FilaListArt> obtenerArticulosConsumidos(string p)
        {
            List<FilaListArt> filas = new List<FilaListArt>();
            DataSet ds = new DataSet();
            string sp = "";
            bool stock = false;
            switch (p)
            {
                case "S":
                    sp = "articulosConsumidos_obtenerTodos";
                    stock = true;
                    break;
                case "s":
                    sp = "articulosConsumidos_obtenerTodos";
                    stock = false;
                    break;
                case "C":
                    sp = "articulosConsumidos_obtenerSoloConsumidos";
                    stock = true;
                    break;
                case "c":
                    sp = "articulosConsumidos_obtenerSoloConsumidos";
                    stock = false;
                    break;
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sp, fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@stock", stock);

            try
            {
                dataAdapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    filas.Add(new FilaListArt(row));
                }

                return filas;
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(" Impresora.cs , metodo: obtenerArticulosConsumidos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer listado articulos consumidos *");
            }
        }

        private List<FilaRopaConsumida> obtenerRopaConsumida()
        {
            List<FilaRopaConsumida> resp = new List<FilaRopaConsumida>();
            DataSet ds = new DataSet();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("ropaConsumida_obtener", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    resp.Add(new FilaRopaConsumida(row));
                }

                return resp;
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(" Impresora.cs , metodo: obtenerArticulosConsumidos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer listado articulos consumidos *");
            }

        }

        #endregion

        //private void Pedido_Bar(object obj, PrintPageEventArgs ev)
        //{
        //    float pos_x = 10;
        //    float pos_y = 20;
        //    string ticket = Settings.Default.ticketCocina.Replace("##FECHA", DateTime.Now.ToString("dd-MM-YYYY")).
        //        Replace("##HORA", DateTime.Now.ToShortTimeString()).Replace("##NRO", obtenerNroTicketCocina().ToString()).
        //        Replace("##HAB", this.NroHab.ToString());
        //    foreach (int articulo in pedidoBar.Keys)
        //    {
        //        ticket = ticket + pedidoBar[articulo] + " " + Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(0) + " " + Articulo.obtenerNombrePrecioArticulo(articulo).GetValue(1) + "\r\n";
        //    }

        //    ev.Graphics.DrawString(ticket, fuente, Brushes.Black, pos_x, pos_y, new StringFormat());

        //}
    }

}


