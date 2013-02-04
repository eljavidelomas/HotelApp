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
    

    public partial class FormCancelarHab : Form
    {
        
        string pasoAsignacion = "nroHabitacion";        
        int nroHab;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormCancelarHab()
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
                            dgvOpcionesElegidas.Rows[0].Cells[1].Value = dgvOpcionesElegidas.Rows[0].Cells[1].Value.ToString() + " " + nroHab;
                            dgvOpcionesElegidas.Rows[1].Cells[1].Value = dgvOpcionesElegidas.Rows[1].Cells[1].Value.ToString() + " " + detalles.nombrePromo;
                            dgvOpcionesElegidas.Rows[2].Cells[1].Value = dgvOpcionesElegidas.Rows[2].Cells[1].Value.ToString() + " " + detalles.nroSocio;
                            dgvOpcionesElegidas.Rows[3].Cells[1].Value = dgvOpcionesElegidas.Rows[3].Cells[1].Value.ToString() + " " + detalles.ptosCambiados;
                            dgvOpcionesElegidas.Rows[4].Cells[1].Value = dgvOpcionesElegidas.Rows[4].Cells[1].Value.ToString() + " " + (detalles.pernocte == 0? "No":"Si");



                            labelNroHab.Text = "¿Confirma Cancelar?";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "cancelar";

                            break;

                        case "cancelar":

                            if (string.IsNullOrEmpty(tbNroHab.Text))
                            {
                                labelMensaje.Text = "0 - No cancela la habitación.\r\n1 - Cancela la habitación.";
                                labelMensaje.Visible = true;
                            }
                            else if (int.Parse(tbNroHab.Text) == 1)
                            {
                                Habitacion.Cancelar((fPrincipal)this.Owner, nroHab);
                                volverFormPrincipal();
                            }
                            else if (int.Parse(tbNroHab.Text) == 0)
                            {
                                volverFormPrincipal();
                            }
                            else
                            {
                                labelMensaje.Text = "0 - No cancela la habitación.\r\n1 - Cancela la habitación.";
                                labelMensaje.Visible = true;
                            }

                            break;

                        default:
                            break;
                    }
                    tbNroHab.SelectionStart = tbNroHab.TextLength;
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
            this.opcionesAsignarHabitacionTableAdapter.Fill(this.hotelDataSet2.OpcionesAsignarHabitacion);
            dgvOpcionesElegidas.Rows[1].Cells[1].Value = "Promoción:";
            dgvOpcionesElegidas.Rows[3].Cells[1].Value = "Puntos Cambiados:";
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
