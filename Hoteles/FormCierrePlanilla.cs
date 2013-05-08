using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Hoteles.Entities;
using System.Data.SqlClient;
using System.Globalization;

namespace Hoteles
{


    public partial class FormCierrePlanilla : Form
    {

        string pasoAsignacion = "conserje";
        int conserjeNuevo;
        int clave;
        decimal efectivoEnCaja;
        decimal tarjetaEnCaja;
        decimal totEfectivo;
        decimal totTarjeta;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormCierrePlanilla()
        {
            InitializeComponent();
            GoFullscreen(true);
            tbNroHab.Focus();
        }

        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
            tbNroHab.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                volverFormPrincipal();
                return true;
            }
            if (pasoAsignacion == "confirmar" || pasoAsignacion=="confirmaImpresion")
                if (keyData == Keys.Enter)
                    tbNroHab_KeyPress(this.tbNroHab, new KeyPressEventArgs((char)keyData));

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void volverFormPrincipal()
        {
            this.Owner.Show();
            this.Owner.Focus();
            this.Hide();
            this.Close();
        }

        private void tbNroHab_KeyPress(object sender, KeyPressEventArgs e)
        {
            string msj;
            try
            {
                if ((char)Keys.Enter == e.KeyChar)
                {
                    e.Handled = true;

                    switch (pasoAsignacion)
                    {
                        case "conserje":

                            msj = validarNroConserje(tbNroHab);
                            if (msj != string.Empty)
                            {
                                labelMensaje.Text = msj;
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;

                            conserjeNuevo = int.Parse(tbNroHab.Text);                            
                            dgvOpcionesElegidas.Rows[3].Cells[0].Value = dgvOpcionesElegidas.Rows[3].Cells[0].Value.ToString() + " " + new Conserje(conserjeNuevo).nombre;
                            
                            labelNroHab.Text = "Ingrese Contraseña";
                            tbNroHab.Text = "";                            
                            pasoAsignacion = "login";

                            break;

                        case "login":
                            
                            clave = string.IsNullOrEmpty(tbNroHab.Text) ? 0 : int.Parse(tbNroHab.Text);
                            if (!Conserje.ValidarPass(conserjeNuevo,clave.ToString()))
                            {
                                labelMensaje.Text = "* La contraseña ingresada es incorrecta *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;

                            efectivoEnCaja = decimal.Parse(tbNroHab.Text);
                            labelNroHab.Text = "Efectivo en Caja";
                            tbNroHab.Text = "0";                            
                            pasoAsignacion = "efectivo";                        

                            break;

                        case "efectivo":

                            if (string.IsNullOrEmpty(tbNroHab.Text))
                            {
                                labelMensaje.Text = "* Debe ingresar el monto de efectivo inicial *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;

                            efectivoEnCaja = decimal.Parse(tbNroHab.Text);
                            dgvOpcionesElegidas.Rows[4].Cells[0].Value = dgvOpcionesElegidas.Rows[4].Cells[0].Value.ToString() + " " + string.Format("{0:c}",efectivoEnCaja);
                                                        
                            labelNroHab.Text = "Importe Tarjeta en Caja";
                            tbNroHab.Text = "0";                            
                            pasoAsignacion = "tarjeta";

                            break;

                        case "tarjeta":
                            if (string.IsNullOrEmpty(tbNroHab.Text))
                            {
                                labelMensaje.Text = "* Debe ingresar el monto de tarjeta inicial *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;

                            tarjetaEnCaja = decimal.Parse(tbNroHab.Text);
                            dgvOpcionesElegidas.Rows[5].Cells[0].Value = dgvOpcionesElegidas.Rows[5].Cells[0].Value.ToString() + " " + string.Format("{0:c}",tarjetaEnCaja);
                            labelNroHab.Text = "¿ Confirmar ?";
                            tbNroHab.Text = "0";
                            tbNroHab.Visible = false;
                            pasoAsignacion = "confirmar";

                            /*--- Modifico el dgv Promos ---*/
                            dgvPromos.Rows.Clear();
                            dgvPromos.RowTemplate.Height = 80;
                            dgvPromos.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
                            dgvPromos.Columns[1].HeaderText = " Opciones ";
                            dgvPromos.Columns.RemoveAt(0);
                            dgvPromos.Rows.Add("Esc - Cancelar");
                            dgvPromos.Rows.Add("Enter - Confirmar");
                            dgvPromos.ClearSelection();
                            panelPromos.Visible = true;
                            /*-----------------------------------------------*/

                            break;


                        case "confirmar":

                            this.confirmarCierre();
                            labelNroHab.Text = "¿Confirma impresión?";
                            pasoAsignacion = "confirmaImpresion";
                            break;

                        case "confirmaImpresion":
                            ((fPrincipal2)this.Owner).conserjeActual = Conserje.Login(conserjeNuevo, clave);
                            ((fPrincipal2)this.Owner).labelConserje.Text = "Conserje:" + ((fPrincipal2)this.Owner).conserjeActual.nombre;
                            confirmarImpresion();
                            
                            volverFormPrincipal();

                            break;

                        default:
                            break;
                    }
                    tbNroHab.Select(0, tbNroHab.TextLength);
                    return;
                }
                if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
                {
                    if (e.KeyChar == '+')
                    {
                        e.KeyChar = (char)Keys.Back;
                        tbNroHab_KeyPress(sender, e);
                    }
                    else
                        e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + " - " + ex.StackTrace);
                labelMensaje.Visible = true;
                labelMensaje.Text=ex.Message;
            }
        }

        private void eliminarTurnosCerrados(SqlConnection conn,SqlTransaction tran)
        {
            SqlCommand comm;
            comm = new SqlCommand("cierresCajas_eliminarTurnosCerrados", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Transaction = tran;
            comm.ExecuteNonQuery();
        }

        private void confirmarCierre()
        {
            using (SqlConnection conn = new SqlConnection(fPrincipal2.conn.ConnectionString))
            {                
                SqlTransaction transaccion = null;
                Totales totales = new Totales();
                conn.Open();
                transaccion = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                decimal efectivoInicialCierreActual = this.obtenerEfectivoInicialCierreActual();               
                try
                {
                    List<FilaPlanilla> filas = this.contabilizarTurnosYGastos(conn, transaccion,totales);
                    new Impresora().ImprimirPlanillaCierre(filas,totales,efectivoInicialCierreActual,efectivoEnCaja, ((fPrincipal2)this.Owner).conserjeActual,labelMensaje);
                    
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();                    
                    throw new Exception(ex.Message);
                }
            }
        }

        private void confirmarImpresion()
        {
            using (SqlConnection conn = new SqlConnection(fPrincipal2.conn.ConnectionString))
            {
                SqlTransaction transaccion = null;
                Totales totales = new Totales();
                conn.Open();
                transaccion = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                decimal efectivoInicialCierreActual = this.obtenerEfectivoInicialCierreActual();
                try
                {                   
                    this.cerrarPlanillaCaja(totEfectivo, totTarjeta, conn, transaccion);
                    this.abrirPlanillaCaja(efectivoEnCaja, tarjetaEnCaja, conserjeNuevo, conn, transaccion);
                    if (tools.obtenerParametroInt("eliminarRegistros") == 1)
                        eliminarTurnosCerrados(conn,transaccion);

                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        private decimal obtenerEfectivoInicialCierreActual()
        {
            SqlDataAdapter comm = new SqlDataAdapter("cierresCajas_obtenerCierreActual", fPrincipal2.conn);
            DataSet ds = new DataSet();
            comm.SelectCommand.CommandType = CommandType.StoredProcedure;
            comm.Fill(ds);

            return decimal.Parse(ds.Tables[0].Rows[0]["efectivoInicial"].ToString());
        }


      
        private string validarNroConserje(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de Conserje *";
            if (int.Parse(tbNroHab.Text) == ((fPrincipal2)this.Owner).conserjeActual.usuario)            
                return "* El conserje nuevo es igual al conserje actual *";            
            if (!Conserje.Validar(tbNroHab.Text))
                return "* El Conserje ingresado no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            FormCierrePlanilla.obtenerMontosTotales(out totEfectivo, out totTarjeta);
            dgvOpcionesElegidas.Rows.Add("Conserje Actual:  " + ((fPrincipal2)this.Owner).conserjeActual.nombre);
            dgvOpcionesElegidas.Rows.Add("Total Efectivo:   " + string.Format("{0:C}", totEfectivo));
            dgvOpcionesElegidas.Rows.Add("Total Tarjeta:    " + string.Format("{0:C}", totTarjeta));
            dgvOpcionesElegidas.Rows.Add("Conserje Nuevo:   ");
            dgvOpcionesElegidas.Rows.Add("Efectivo Inicial: ");
            dgvOpcionesElegidas.Rows.Add("Tarjeta Inicial:  ");
            int altoFila, altoFilaExtraMedioPagos;
            tools.calcularAlturas(dgvOpcionesElegidas.Height - dgvOpcionesElegidas.ColumnHeadersHeight, 8, out altoFila, out altoFilaExtraMedioPagos);
            dgvOpcionesElegidas.RowTemplate.Height = altoFila;
            dgvOpcionesElegidas.ClearSelection();
            panelPromos.Visible = false;
        }

        private void labelTitulo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.DrawLine(new Pen(Color.BlueViolet, 1.5f), 0, g.ClipBounds.Height - 5, g.ClipBounds.Width, g.ClipBounds.Height - 5);
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }

        private void abrirPlanillaCaja(decimal efectivoInicial, decimal tarjetaInicial, int conserjeNuevo,SqlConnection con,SqlTransaction tran)
        {
            SqlCommand comm = new SqlCommand("cierresCajas_abrirCierre", con);
            comm.Transaction = tran;
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@efIni", efectivoInicial);
            comm.Parameters.AddWithValue("@tarjIni", tarjetaInicial);
            comm.Parameters.AddWithValue("@conserjeId", conserjeNuevo);
            comm.ExecuteNonQuery();
        }

        private void cerrarPlanillaCaja(decimal totEfectivo, decimal totTarjeta, SqlConnection con, SqlTransaction tran)
        {
            SqlCommand comm = new SqlCommand("cierresCajas_hacerCierre", con);
            comm.Transaction = tran;
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@totEfectivo", totEfectivo);
            comm.Parameters.AddWithValue("@totTarjeta", totTarjeta);
            comm.ExecuteNonQuery();
        }

        private List<FilaPlanilla> contabilizarTurnosYGastos(SqlConnection con, SqlTransaction tran,Totales totales)
        {
            DataSet ds = new DataSet();
            List<FilaPlanilla> filas = new List<FilaPlanilla>();
            int nroOrd = 1;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("cierresCajas_contabilizarTurnosCerrados", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Transaction = tran;
            dataAdapter.Fill(ds);
            FilaPlanilla fila;
                      
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fila = new FilaPlanilla(dr, nroOrd);
                filas.Add(fila);
                totales.totalTurnos += fila.turnos;
                totales.totalExtras += fila.extras;
                totales.totalBar += fila.bar;
                totales.totalDescuento += fila.descuento;
                totales.totalTotal += fila.total;
                totales.totalEfectivo += fila.efectivo;
                totales.totalTarjeta += fila.tarjeta;                
                nroOrd++;
            }
            
            dataAdapter.SelectCommand.CommandText = "cierresCajas_contabilizarTurnosAbiertos";
            ds.Clear();
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fila = new FilaPlanilla();
                fila.nro = nroOrd;
                fila.nroHab = int.Parse(dr["nroHabitacion"].ToString());
                fila.desde = DateTime.Parse(dr["desde"].ToString());
                fila.socio = "Adelanto";
                decimal.TryParse(dr["efectivoCerrado"].ToString(),out fila.efectivo);
                decimal.TryParse(dr["tarjetaCerrado"].ToString(),out fila.tarjeta);
                filas.Add(fila);
                totales.totalEfectivo += fila.efectivo;
                totales.totalTarjeta += fila.tarjeta;
                nroOrd++;
            }

            dataAdapter.SelectCommand.CommandText = "cierresCajas_contabilizarGastos";
            ds.Clear();
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                fila = new FilaPlanilla();
                fila.nro = 0;
                fila.nroHab = 0;
                fila.desde = DateTime.Parse(dr["fecha"].ToString());
                fila.socio = dr["nombre"].ToString();                
                decimal.TryParse(dr["monto"].ToString(), out fila.gastos);                
                filas.Add(fila);
                totales.totalGastos += fila.gastos;
            }


            return filas;
        }



        public static void obtenerMontosTotales(out decimal totEfectivo, out decimal totTarjeta)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("cierresCajas_obtenerTotales", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.Fill(ds);

            totEfectivo = decimal.Parse(ds.Tables[0].Rows[0]["efectivo"].ToString());
            totTarjeta = decimal.Parse(ds.Tables[0].Rows[0]["tarjeta"].ToString());
        }
    }
}

