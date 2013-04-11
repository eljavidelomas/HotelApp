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


    public partial class FormClavesOpcionales : Form
    {
        string pasoAsignacion = "nroClave";
        int nroHab;
        string estHab;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormClavesOpcionales()
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
                        case "nroClave":

                            msj = validarNroClave(tbNroHab);
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

        private string validarNroClave(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar un Nro de Clave *";
            //DataSet ds = new DataSet();
            //SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal.conn);
            //dataAdapter.Fill(ds);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    estHab = ds.Tables[0].Rows[0]["estado"].ToString();
            //    if ( estHab == "A" || estHab == "O")
            //        return "* La habitación no puede estar ni asignada ni ocupada. *";
            //}
            //else
            //    return "* El número de habitación no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            //Cargar claves 
            dgvOpcionesElegidas.Rows.Add("1234", "Menu de configuración de la app");
            dgvOpcionesElegidas2.Rows.Add("14", "Menu de Administración");
            dgvOpcionesElegidas.Rows.Add("55674", "Menu de datos Hotel");
            dgvOpcionesElegidas2.Rows.Add("1113", "Menu de configuración de la app");
            dgvOpcionesElegidas.Rows.Add("5434", "Menu de configuración de la app");
        

            dgvOpcionesElegidas.ClearSelection();
            dgvOpcionesElegidas2.ClearSelection();
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }
    }
}
