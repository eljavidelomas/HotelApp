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


    public partial class FormAdelantoDinero : Form
    {
        int nroHab;
        int medioPago;
        decimal monto=0;
        int puntos=0;
        string pasoAsignacion = "nroHabitacion";
        DetallesHabitacion detallesHab;
        Dictionary<int, string> dictMediosDePago = new Dictionary<int, string>();
        Socio socio;


        public FormAdelantoDinero()
        {
            InitializeComponent();
            this.tableLayoutPanel2.BackColor = tools.backColorTableLayout;
            this.labelTitulo.BackColor = tools.backColorTitulo;
            this.labelMensaje.BackColor = tools.backColorMsjError;
            this.panelIngresoDatos.BackColor = tools.backColorIngresoDatos;
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
            if (pasoAsignacion == "confirmar")
                if (keyData == Keys.Enter)
                    tbNroHab_KeyPress(this.tbNroHab, new KeyPressEventArgs((char)keyData));

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void volverFormPrincipal()
        {
            LoggerProxy.Info("Salir Adelanto de Dinero");
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
                        case "nroHabitacion":

                            msj = validarNroHabitacion(tbNroHab);
                            if (msj != string.Empty)
                            {
                                labelMensaje.Text = msj;
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;

                            nroHab = int.Parse(tbNroHab.Text);
                            detallesHab = Habitacion.obtenerDetalles(nroHab);
                            decimal saldoAfavor = decimal.Parse(detallesHab.ptosCambiados.ToString()) - detallesHab.impHabitacion < 0 ? 0 : decimal.Parse(detallesHab.ptosCambiados.ToString()) - detallesHab.impHabitacion;
                            dgvOpcionesElegidas.Rows[0].Cells[0].Value = dgvOpcionesElegidas.Rows[0].Cells[0].Value.ToString() + "    " + nroHab;
                            decimal importeAux2 = detallesHab.impHabitacion - decimal.Parse(detallesHab.ptosCambiados);
                            importeAux2 = importeAux2 < 0 ? 0 : importeAux2;// Si es negativo ,pongo cero.
                            dgvOpcionesElegidas.Rows[1].Cells[0].Value = dgvOpcionesElegidas.Rows[1].Cells[0].Value.ToString() + "    " + String.Format("{0:C}",importeAux2 );
                            dgvOpcionesElegidas.Rows[2].Cells[0].Value = dgvOpcionesElegidas.Rows[2].Cells[0].Value.ToString() + " " + detallesHab.ptosCambiados;
                            dgvOpcionesElegidas.Rows[3].Cells[0].Value = dgvOpcionesElegidas.Rows[3].Cells[0].Value.ToString() + "     " + String.Format("{0:C}", saldoAfavor); ;
                           
                            labelNroHab.Text = "Medio de Pago ";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "medioPago";
                            panelPromos.Visible = true;
                            dgvMedioPago.ClearSelection();

                            break;

                        case "medioPago":

                            medioPago = string.IsNullOrEmpty(tbNroHab.Text) ? 0 : int.Parse(tbNroHab.Text);
                            if (!dictMediosDePago.ContainsKey(medioPago))
                            {
                                labelMensaje.Text = "* El medio de Pago no existe *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;
                            
                            //Agrego el tema de los Puntos

                            if (dictMediosDePago[medioPago].ToLower().Contains("puntos"))
                            {
                                if (string.IsNullOrEmpty(detallesHab.nroSocio))
                                {
                                    labelMensaje.Text = "* El cliente no es socio *";
                                    labelMensaje.Visible = true;
                                    return;
                                }
                                socio = Socio.registrarYobtener(int.Parse(detallesHab.nroSocio));
                                
                                /*--- Modificar panel medios de pago---*/
                                dgvMedioPago.Rows.Clear();
                                dgvMedioPago.Columns[1].HeaderText = "Datos Socio";
                                dgvMedioPago.Rows.Add("","Puntos: "+ socio.puntaje);
                                dgvMedioPago.Rows.Add("", "Vencimiento: " + socio.fechaVencimientoPuntaje.ToString("dd-MM-yyyy"));
                                /*-------------------------------------*/
                                labelNroHab.Text = "Puntos a Cambiar";
                                pasoAsignacion = "puntos";
                            }
                            else
                            {
                                labelNroHab.Text = "Monto a Adelantar $ ";
                                pasoAsignacion = "monto";
                            }
                            dgvOpcionesElegidas.Rows[4].Cells[0].Value = dgvOpcionesElegidas.Rows[4].Cells[0].Value.ToString() + "    " + dictMediosDePago[medioPago];
                            tbNroHab.Text = "0";                            
                            
                            break;

                        case "monto":

                            if (string.IsNullOrEmpty(tbNroHab.Text) || tbNroHab.Text == "0")
                            {
                                labelMensaje.Text = "* El monto debe ser mayor a cero *";
                                labelMensaje.Visible = true;
                                return;                                
                            }
                            monto = decimal.Parse(tbNroHab.Text.Replace('.', ','));
                            if (monto > detallesHab.impHabitacion - decimal.Parse(detallesHab.ptosCambiados) )
                            {
                                labelMensaje.Text = "* El monto debe ser inferior o igual al total *";
                                labelMensaje.Visible = true;
                                return;    
                            }
                            labelMensaje.Visible = false;
                            dgvOpcionesElegidas.Rows[5].Cells[0].Value = dgvOpcionesElegidas.Rows[5].Cells[0].Value.ToString() + "  " + String.Format("{0:C}", decimal.Parse(tbNroHab.Text.Replace('.', ',')));
                            
                            pasoAsignacion = "confirmar";
                            labelNroHab.Text = "Confirma Adelanto?";
                            tbNroHab.Visible = false;
                            mostrarOpcionConfirmar();                            

                            break;

                        case "puntos":

                            if (string.IsNullOrEmpty(tbNroHab.Text) || tbNroHab.Text == "0")
                            {
                                labelMensaje.Text = "* La cantidad de puntos debe ser mayor a cero *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            puntos = int.Parse(tbNroHab.Text);
                            if (puntos > socio.puntaje)
                            {
                                labelMensaje.Text = "* Puntaje insuficiente *";
                                tbNroHab.Clear();
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;
                            dgvOpcionesElegidas.Rows[5].Cells[0].Value = dgvOpcionesElegidas.Rows[5].Cells[0].Value.ToString() + " " + puntos.ToString();

                            pasoAsignacion = "confirmar";
                            labelNroHab.Text = "Confirma Adelanto?";
                            tbNroHab.Visible = false;

                            /*--- Modifico el dgv Promos ---*/
                            mostrarOpcionConfirmar();

                            break;

                        case "confirmar":
                            
                            if(puntos == 0)
                                Habitacion.Adelanto((fPrincipal2)this.Owner, nroHab, monto, medioPago);
                            else
                                //adelanto puntos y se los descuento al socio.
                                Habitacion.AdelantarPuntos((fPrincipal2)this.Owner, nroHab, puntos,ref socio);

                            LoggerProxy.Info(string.Format("Ejecuto Adelanto de Dinero - Hab:{0}  Monto:{1}",nroHab,monto));
                            volverFormPrincipal();
                            return;                            

                        default:
                            break;
                    }
                    tbNroHab.Select(0, tbNroHab.TextLength);
                    dgvMedioPago.ClearSelection();
                    //tbNroHab.SelectionStart = tbNroHab.TextLength;
                    return;
                }
                if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' || (e.KeyChar == '.' && (pasoAsignacion == "nroHabitacion" || tbNroHab.Text.Contains('.'))))
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
                labelMensaje.Text = ex.Message;
                labelMensaje.Visible = true;
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
            }
        }

        private void mostrarOpcionConfirmar()
        {
            dgvMedioPago.Rows.Clear();
            dgvMedioPago.RowTemplate.Height = 80;
            dgvMedioPago.BackgroundColor = Color.White;
            dgvMedioPago.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
            dgvMedioPago.Columns[1].HeaderText = " Opciones ";
            dgvMedioPago.Columns.RemoveAt(0);
            dgvMedioPago.Rows.Add("Esc - Cancelar");
            dgvMedioPago.Rows.Add("Enter - Confirmar");
            dgvMedioPago.ClearSelection();
            panelPromos.Visible = true;
        }

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación a cancelar*";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal2.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["estado"].ToString() != "A" && ds.Tables[0].Rows[0]["estado"].ToString() != "O")
                    return "* La habitación no está asignada ni ocupada.*";
            }
            else
                return "* El número de habitación no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            int altoFila, altoFilaExtraMedioPagos;
            panelPromos.Visible = true;

            this.mediosDePagoTableAdapter.Fill(this.hotelDataSet.mediosDePago);
            dgvMedioPago.DataSource = null;
            tools.calcularAlturas(dgvMedioPago.Height - dgvMedioPago.ColumnHeadersHeight, hotelDataSet.mediosDePago.Count > tools.minCantFilas ? hotelDataSet.mediosDePago.Count : tools.minCantFilas, out altoFila, out altoFilaExtraMedioPagos);
            dgvMedioPago.RowTemplate.Height = altoFila;

            foreach (DataRow dr in hotelDataSet.mediosDePago)
            {
                dictMediosDePago.Add(int.Parse(dr[0].ToString()), dr[1].ToString());
                dgvMedioPago.Rows.Add(dr[0].ToString(), dr[1].ToString());
            }
            // ----  Completando la tabla mediosPagos  ----//
            tools.completarDG(dgvMedioPago, altoFilaExtraMedioPagos);
            panelPromos.Visible = false;
            //---------------------------------------------------------------------------//
            
            dgvOpcionesElegidas.Rows.Add("Habitación Nro:");
            dgvOpcionesElegidas.Rows.Add("Monto a Pagar:");
            dgvOpcionesElegidas.Rows.Add("Puntos canjeados:");
            dgvOpcionesElegidas.Rows.Add("Saldo a Favor:");
            dgvOpcionesElegidas.Rows.Add("Medio de Pago:"); // 4           
            dgvOpcionesElegidas.Rows.Add("Cant a Adelantar:");
            dgvOpcionesElegidas.ClearSelection();
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
    }
}
