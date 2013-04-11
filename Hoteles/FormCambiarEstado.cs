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


    public partial class FormCambiarEstado : Form
    {
        string pasoAsignacion = "nroHabitacion";
        int nroHab;
        string estHab;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormCambiarEstado()
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
            if (pasoAsignacion == "confirmar")
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

                            labelNroHab.Text = "¿Confirma Cambio de Estado?";
                            tbNroHab.Text = "0";
                            tbNroHab.Visible = false;
                            pasoAsignacion = "confirmar";

                            break;

                        case "confirmar":
                            if (estHab == "M" || estHab == "D")
                                estHab = "X";
                            else if (estHab == "X")
                                estHab = "D";
                            Habitacion.CambiarEstado((fPrincipal)this.Owner, nroHab,estHab);
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
            }
        }

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación a cambiar de estado*";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                estHab = ds.Tables[0].Rows[0]["estado"].ToString();
                if ( estHab == "A" || estHab == "O")
                    return "* La habitación no puede estar ni asignada ni ocupada. *";
            }
            else
                return "* El número de habitación no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {

        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }
    }
}
