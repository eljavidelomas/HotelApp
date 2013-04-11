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


    public partial class FormAvisosHorarios : Form
    {
        int nroHab;
        int avisoSel;
        int hora;
        string pasoAsignacion = "nroHabitacion";
        List<Aviso> lAvisos = new List<Aviso>();
        Dictionary<int, Aviso> dictAvisosSel = new Dictionary<int, Aviso>();
        Dictionary<int, Aviso> dictAvisos = new Dictionary<int, Aviso>();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FormAvisosHorarios()
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
            if (keyData == Keys.F7)
            {
                Alarma.desactivar();
                Habitacion.quitarAviso((fPrincipal)this.Owner, ((fPrincipal)this.Owner).alarmas[0].nroHab, ((fPrincipal)this.Owner).alarmas[0].id);                
                ((fPrincipal)this.Owner).alarmas.RemoveAt(0);    
            }
            if (pasoAsignacion == "confirmar" || pasoAsignacion == "quitar")
            {
                if (keyData == Keys.Enter)
                    tbNroHab_KeyPress(this.tbNroHab, new KeyPressEventArgs((char)keyData));
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
                            lAvisos = Habitacion.obtenerAvisos(nroHab);
                            dgvOpcionesElegidas.Rows[0].Cells[0].Value = dgvOpcionesElegidas.Rows[0].Cells[0].Value.ToString() + " " + nroHab;
                            foreach (Aviso aviso in lAvisos)
                            {
                                dgvOpcionesElegidas.Rows.Add(aviso.mensaje + " " + aviso.hora.ToShortTimeString());
                                dictAvisosSel.Add(aviso.id, aviso);
                            }
                            labelNroHab.Text = "Seleccione Aviso ";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "aviso";
                            panelPromos.Visible = true;

                            break;

                        case "aviso":

                            avisoSel = string.IsNullOrEmpty(tbNroHab.Text) ? 0 : int.Parse(tbNroHab.Text);
                            if (!dictAvisos.ContainsKey(avisoSel))
                            {
                                labelMensaje.Text = "* El Aviso seleccionado no existe *";
                                labelMensaje.Visible = true;
                                return;
                            }

                            labelMensaje.Visible = false;
                            dgvOpcionesElegidas.Rows.Add(dictAvisos[avisoSel].mensaje);
                            labelNroHab.Text = "Hora del Aviso ";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "hora";

                            break;

                        case "hora":

                            if (string.IsNullOrEmpty(tbNroHab.Text))
                            {
                                labelMensaje.Text = "* Hora incorrecta *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            if (tbNroHab.Text == "0")
                            {
                                if (!validarAlarmaExiste(avisoSel))
                                {
                                    labelMensaje.Text = "* El Aviso elegido no esta seteado para esta habitación *";
                                    labelMensaje.Visible = true;
                                    return;
                                }
                                labelNroHab.Text = "Confirma eliminación? ";
                                tbNroHab.Visible = false;
                                pasoAsignacion = "quitar";
                                break;
                            }
                            if (dictAvisosSel.ContainsKey(avisoSel))
                            {
                                labelMensaje.Text = "* El Aviso seleccionado ya fue seteado *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            if (tbNroHab.Text.Length < 4)
                            {
                                labelMensaje.Text = "* Hora incorrecta *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            hora = int.Parse(tbNroHab.Text);
                            if ((hora / 100 > 23) || (hora % 100) > 59)
                            {
                                labelMensaje.Text = "* Hora incorrecta *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            int indice = dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None);
                            labelMensaje.Visible = false;
                            dgvOpcionesElegidas.Rows[indice].Cells[0].Value = dgvOpcionesElegidas.Rows[indice].Cells[0].Value.ToString() + " " + hora.ToString().PadLeft(4,'0').Insert(2, ":");

                            pasoAsignacion = "confirmar";
                            labelNroHab.Text = "Confirma Aviso?";
                            tbNroHab.Visible = false;
                            break;

                        case "confirmar":
                            Habitacion.agregarAviso((fPrincipal)this.Owner ,nroHab, hora, avisoSel);
                            volverFormPrincipal();
                            return;

                        case "quitar":
                            Habitacion.quitarAviso((fPrincipal)this.Owner, nroHab, avisoSel);
                            volverFormPrincipal();
                            return;

                        default:
                            break;
                    }
                    tbNroHab.Select(0, tbNroHab.TextLength);
                    dgvListadoAvisos.ClearSelection();
                    dgvOpcionesElegidas.ClearSelection();

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

        private bool validarAlarmaExiste(int aviso)
        {            
            if (!dictAvisosSel.ContainsKey(aviso))
                return false;
            return true;            
        }

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
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
            try
            {
                foreach (Aviso av in Habitacion.listadoAvisos())
                {
                    dgvListadoAvisos.Rows.Add(av.id.ToString(), av.mensaje);
                    dictAvisos.Add(av.id, av);
                }
                dgvOpcionesElegidas.Rows.Add("Habitación Nro:");
                dgvOpcionesElegidas.ClearSelection();
                dgvListadoAvisos.ClearSelection();
            }
            catch (Exception ex)
            {
                labelMensaje.Text = ex.Message;
                labelMensaje.Visible = true;
                log.Error(ex.Message + " - " + ex.StackTrace);
            }
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
