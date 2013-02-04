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
        string pasoAsignacion = "nroHabitacion";        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FormAdelantoDinero()
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
                            DetallesHabitacion detalles = Habitacion.obtenerDetalles(nroHab);
                            dgvOpcionesElegidas.Rows[0].Cells[0].Value = dgvOpcionesElegidas.Rows[0].Cells[0].Value.ToString() + " " + nroHab;
                            dgvOpcionesElegidas.Rows[1].Cells[0].Value = dgvOpcionesElegidas.Rows[1].Cells[0].Value.ToString() + " " + String.Format("{0:C}", detalles.impHabitacion);
                           
                            labelNroHab.Text = "Adelanto en Efectivo $ ";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "efectivo";

                            break;

                        case "efectivo":

                            if (!(string.IsNullOrEmpty(tbNroHab.Text) || tbNroHab.Text == "0"))
                            {
                                decimal montoEfectivo = decimal.Parse(tbNroHab.Text.Replace('.',','));
                                Habitacion.Adelanto((fPrincipal)this.Owner, nroHab, montoEfectivo, "E");                                
                            }
                            dgvOpcionesElegidas.Rows[2].Cells[0].Value = dgvOpcionesElegidas.Rows[2].Cells[0].Value.ToString() + " " + String.Format("{0:C}", decimal.Parse(tbNroHab.Text.Replace('.', ',')));
                            labelNroHab.Text = "Adelanto con Tarjeta $ ";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "tarjeta";
                            
                            break;

                        case "tarjeta":

                            if (string.IsNullOrEmpty(tbNroHab.Text) || tbNroHab.Text == "0")
                            {
                                volverFormPrincipal();
                                return;                                
                            }
                            dgvOpcionesElegidas.Rows[3].Cells[0].Value = dgvOpcionesElegidas.Rows[3].Cells[0].Value.ToString() + " " + String.Format("{0:C}", decimal.Parse(tbNroHab.Text.Replace('.', ',')));
                            decimal montoTarjeta = decimal.Parse(tbNroHab.Text.Replace('.', ','));
                            Habitacion.Adelanto((fPrincipal)this.Owner,nroHab, montoTarjeta, "T");
                            volverFormPrincipal();
                            return;
                            break;

                        default:
                            break;
                    }
                    tbNroHab.SelectionStart = tbNroHab.TextLength;
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
                log.Error(ex.Message + " - " + ex.StackTrace);
            }
        }

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación a cancelar*";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal.conn);
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
            dgvOpcionesElegidas.Rows.Add("Habitación Nro:");
            dgvOpcionesElegidas.Rows.Add("Monto a Pagar:");
            dgvOpcionesElegidas.Rows.Add("Adelanto en Efectivo:");
            dgvOpcionesElegidas.Rows.Add("Adelanto con Tarjeta:");
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
