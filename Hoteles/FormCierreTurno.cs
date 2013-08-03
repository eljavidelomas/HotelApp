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


    public partial class FormCierreTurno : Form
    {
        public int nroHab;
        public int medioPago;
        int altoFilaExtraOpElegidas;
        int altoFilaExtraMedioPagos;
        int puntos;
        public decimal descuento;
        public Decimal impDescArt;
        public decimal impExtras;
        public decimal impDescHab;
        public decimal impArt;
        public decimal impHab;
        public decimal efectivo;
        public decimal tarjeta;
        string pasoAsignacion = "nroHabitacion";
        public DetallesHabitacion detallesHab = new DetallesHabitacion();
        Dictionary<int, string> dictMediosDePago = new Dictionary<int, string>();        


        public FormCierreTurno()
        {
            InitializeComponent();
            this.tableLayoutPanel2.BackColor = tools.backColorTableLayout;
            this.labelTitulo.BackColor = tools.backColorTitulo;
            this.labelMensaje.BackColor = tools.backColorMsjError;
            this.flowLayoutPanel1.BackColor = tools.backColorIngresoDatos;
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
            LoggerProxy.Info("Salir Cierre Turno");
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
                            DataRow detalles = Habitacion.preCierre(nroHab);
                            
                            impHab = decimal.Parse(detalles[0].ToString());
                            impArt = decimal.Parse(detalles[1].ToString());
                            impExtras = decimal.Parse(detalles[2].ToString());
                            impDescArt = decimal.Parse(detalles[3].ToString());
                            efectivo = decimal.Parse(detalles[4].ToString());
                            tarjeta = decimal.Parse(detalles[5].ToString());
                            puntos = detalles["puntos"].ToString() == ""? 0 : int.Parse(detalles["puntos"].ToString());
                            impDescHab = decimal.Parse(puntos.ToString()) + decimal.Parse(detalles["descHabitacion"].ToString());
                            detallesHab.impHabitacion = impHab + impExtras + impArt - impDescArt - impDescHab - efectivo - tarjeta;
                            dgvOpcionesElegidas.Rows[0].Cells[0].Value = dgvOpcionesElegidas.Rows[0].Cells[0].Value.ToString() + " " + nroHab;
                            dgvOpcionesElegidas.Rows[1].Cells[1].Value = String.Format("{0:C}", impHab+impExtras);
                            dgvOpcionesElegidas.Rows[2].Cells[1].Value = String.Format("{0:C}", impArt);
                            dgvOpcionesElegidas.Rows[3].Cells[1].Value = String.Format("- {0:C}", impDescArt);
                            dgvOpcionesElegidas.Rows[4].Cells[1].Value = String.Format("- {0:C}", impDescHab);
                            dgvOpcionesElegidas.Rows[5].Cells[1].Value = String.Format("{0:C}", efectivo);
                            dgvOpcionesElegidas.Rows[6].Cells[1].Value = String.Format("{0:C}", tarjeta);
                            
                                                       
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
                            dgvOpcionesElegidas.Rows[7].Cells[1].Value = dictMediosDePago[medioPago];
                            labelNroHab.Text = "Monto a Descontar ";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "descuento";
                            
                            break;

                        case "descuento":
                            
                            if (!decimal.TryParse(tbNroHab.Text.Replace('.', ','),out descuento))
                            {
                                labelMensaje.Text = "* El valor de descuento ingresado es incorrecto *";
                                labelMensaje.Visible = true;
                                return;                                
                            }
                            
                            if (descuento > detallesHab.impHabitacion)
                            {
                                labelMensaje.Text = "* El descuento debe ser inferior o igual al total *";
                                labelMensaje.Visible = true;
                                return;    
                            }
                            labelMensaje.Visible = false;
                            dgvOpcionesElegidas.Rows[8].Cells[1].Value =  String.Format("{0:C}", decimal.Parse(tbNroHab.Text.Replace('.', ',')));

                            detallesHab.impHabitacion = detallesHab.impHabitacion - descuento <= 0 ? 0 : detallesHab.impHabitacion - descuento;
                            pasoAsignacion = "confirmar";
                            dgvOpcionesElegidas.Rows.Add();
                            dgvOpcionesElegidas.Rows.Add("Total a pagar   "+ String.Format("{0:C}", detallesHab.impHabitacion));
                            dgvOpcionesElegidas.Rows[dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.ForeColor = Color.Red;
                            dgvOpcionesElegidas.Rows[dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.BackColor= Color.Black;
                            dgvOpcionesElegidas.Rows[dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.Font = new Font("Arial", 24f,FontStyle.Bold);
                            dgvOpcionesElegidas.Rows[dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None)].Height = (int) (dgvOpcionesElegidas.Rows[dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None)].Height) + altoFilaExtraOpElegidas;
                            labelNroHab.Text = "Confirma Cierre?";
                            tbNroHab.Visible = false;
                            break;

                        case "confirmar":
                            FormCierreTurnoCliente formCliente = new FormCierreTurnoCliente();
                            formCliente.Owner = this;
                            formCliente.Show();
                            this.Hide();
                            formCliente.Activate();
                            this.dgvMedioPago.ClearSelection();
                            return;
                            
                        default:
                            break;
                    }
                    tbNroHab.Select(0, tbNroHab.TextLength);
                    
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
            int altoFila;            
            tools.calcularAlturas(dgvOpcionesElegidas.Height-dgvOpcionesElegidas.ColumnHeadersHeight, 11f, out altoFila, out altoFilaExtraOpElegidas);            
            dgvOpcionesElegidas.RowTemplate.Height = altoFila;

            panelPromos.Visible = true;
                                    
            this.mediosDePagoTableAdapter.Fill(this.hotelDataSet.mediosDePago);
            dgvMedioPago.DataSource = null;
            tools.calcularAlturas(dgvMedioPago.Height - dgvMedioPago.ColumnHeadersHeight, hotelDataSet.mediosDePago.Count>tools.minCantFilas?hotelDataSet.mediosDePago.Count:tools.minCantFilas, out altoFila, out altoFilaExtraMedioPagos);
            dgvMedioPago.RowTemplate.Height = altoFila;
           
            foreach (DataRow dr in hotelDataSet.mediosDePago)
            {
                dictMediosDePago.Add(int.Parse(dr[0].ToString()), dr[1].ToString());
                dgvMedioPago.Rows.Add(dr[0].ToString(), dr[1].ToString());
            }
            // ----  Completando la tabla mediosPagos  ----//
            if (hotelDataSet.mediosDePago.Count < tools.minCantFilas)
            {
                for (int i = tools.minCantFilas; i - hotelDataSet.mediosDePago.Count > 0; i--)
                {
                    dgvMedioPago.Rows.Add();
                }
            }
            if (altoFilaExtraMedioPagos > 0)
                dgvMedioPago.Rows[dgvMedioPago.Rows.GetLastRow(DataGridViewElementStates.None)].Height += altoFilaExtraMedioPagos;

            panelPromos.Visible = false;
            //---------------------------------------------------------------------------//

            dgvOpcionesElegidas.Rows.Add("Habitación Nro:");
            dgvOpcionesElegidas.Rows.Add("Monto Total Habitacion:");
            dgvOpcionesElegidas.Rows.Add("Monto Total Articulos:");
            dgvOpcionesElegidas.Rows.Add("Descuento por Articulos:"); // 3
            dgvOpcionesElegidas.Rows.Add("Descuento por Promociones:");
            dgvOpcionesElegidas.Rows.Add("Adelantado Efectivo:");
            dgvOpcionesElegidas.Rows.Add("Adelantado Tarjeta:");             
            dgvOpcionesElegidas.Rows.Add("Medio de Pago:");
            dgvOpcionesElegidas.Rows.Add("Descuento:");

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
