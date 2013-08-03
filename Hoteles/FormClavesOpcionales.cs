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
        int nroClaveSel;
        string estHab;
        List<int> claves = new List<int>();
        int claveAdmin = int.Parse(tools.obtenerParametroString("claveAcceso"));

        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormClavesOpcionales()
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
            LoggerProxy.Info("Salir Claves Opcionales");
            this.Owner.Show();
            this.Owner.Focus();
            this.Hide();
            this.Close();
        }
        private void irFormRopaSaliente()
        {
            FormRopaSaliente ropaSaliente = new FormRopaSaliente(true);
            ropaSaliente.Owner = this.Owner;
            ropaSaliente.Show();            
            ropaSaliente.Activate();
            ropaSaliente.tbNroHab.Focus();
            //this.Hide();
            this.Close();
        }
        private void irFormRopaEntrante()
        {
            FormRopaSaliente ropaSaliente = new FormRopaSaliente(false);
            ropaSaliente.Owner = this.Owner;
            ropaSaliente.Show();
            ropaSaliente.Activate();
            ropaSaliente.tbNroHab.Focus();
            //this.Hide();
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

                            nroClaveSel = int.Parse(tbNroHab.Text);
                            switch (nroClaveSel)
                            {
                                case 1:
                                    actualizarParametroString("ordenListado", "NroHabitacion");
                                    break;

                                case 2:
                                    actualizarParametroString("ordenListado", "HorarioSalida");
                                    break;

                                case 3:
                                    pasoAsignacion = "ropaSalida";
                                    tbNroHab_KeyPress(sender, e);
                                    return;                                    

                                case 4:
                                    pasoAsignacion = "ropaEntrada";
                                    tbNroHab_KeyPress(sender, e);
                                    return;

                                default:
                                    break;
                            }

                            if (nroClaveSel != claveAdmin)
                            {
                                tools.actualizarListadoTurnos(((fPrincipal2)this.Owner).dataGridView1, ((fPrincipal2)this.Owner).dataGridView2);
                                volverFormPrincipal();
                                return;
                            }
                                                        
                            break;

                        case "ropaSalida":
                            irFormRopaSaliente();
                            break;

                        case "ropaEntrada":
                            irFormRopaEntrante();
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
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
            }
        }

        private string validarNroClave(TextBox tbNroHab)
        {
            int claveSel;
            if (tbNroHab.Text == String.Empty || !int.TryParse(tbNroHab.Text, out claveSel))
                return "* Debe ingresar un Nro de Clave válido *";

            if (!claves.Contains(claveSel))
                return "* La clave seleccionado no es válida *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            //Cargar claves 
            dgvOpcionesElegidas.Rows.Add("1", "Ordenar Listado por Nro.Habitación");
            //dgvOpcionesElegidas2.Rows.Add("14", "Menu de Administración");
            dgvOpcionesElegidas.Rows.Add("2", "Ordenar Listado por Estado Habitación");
            dgvOpcionesElegidas.Rows.Add("3", "Ropa Enviada Lavadero");
            dgvOpcionesElegidas.Rows.Add("4", "Ropa devuelta del Lavadero");
            //dgvOpcionesElegidas2.Rows.Add("1113", "Menu de configuración de la app");
            
            dgvOpcionesElegidas.ClearSelection();
            //dgvOpcionesElegidas2.ClearSelection();


            claves.Add(1);
            claves.Add(2);
            claves.Add(3);
            claves.Add(4);
            claves.Add(claveAdmin);
        }


        private void actualizarParametroString(string parametro, string valor)
        {
            SqlCommand comm;
            try
            {
                comm = new SqlCommand("update parametros set val1_string = '" + valor + "' where nombre = '" + parametro + "'", fPrincipal2.conn);
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
            }
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }
    }
}
