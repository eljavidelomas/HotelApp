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
        int opcion;
        List<Aviso> lAvisos = new List<Aviso>();
        Dictionary<int, Aviso> dictAlarmasSel = new Dictionary<int, Aviso>();
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
                if (((fPrincipal2)this.Owner).alarmas.Count > 0 && pasoAsignacion=="opcion")
                {
                    if (((fPrincipal2)this.Owner).alarmas[0].nroHab == nroHab)
                    {
                        Alarma.desactivar();
                        Habitacion.quitarAlarma((fPrincipal2)this.Owner, ((fPrincipal2)this.Owner).alarmas[0].nroHab, ((fPrincipal2)this.Owner).alarmas[0].id);

                        fPrincipal2.dicAlarmasSonando.Remove(((fPrincipal2)this.Owner).alarmas[0].nroHab);
                        ((fPrincipal2)this.Owner).alarmas.RemoveAt(0);


                        //---   Redibujo el listado de turnos
                        tools.actualizarListadoTurnos(((fPrincipal2)this.Owner).dataGridView1, ((fPrincipal2)this.Owner).dataGridView2);
                        volverFormPrincipal();
                    }

                }
            }
            if (pasoAsignacion == "confirmar" || pasoAsignacion == "quitar" || pasoAsignacion== "confirmarAviso" || pasoAsignacion=="quitarAviso")
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
                            dgvOpcionesElegidas.Rows[0].Cells[0].Value = dgvOpcionesElegidas.Rows[0].Cells[0].Value.ToString() + " " + nroHab;

                            lAvisos = Habitacion.obtenerAlarmas(nroHab);
                            foreach (Aviso aviso in lAvisos)
                            {
                                dgvOpcionesElegidas.Rows.Add(aviso.mensaje + "  -  " + aviso.hora.ToString("HH:mm"));
                                dictAlarmasSel.Add(aviso.id, aviso);
                            }
                            lAvisos.Clear();
                            lAvisos = Habitacion.obtenerAvisos(nroHab);
                            foreach (Aviso aviso in lAvisos)
                            {
                                dgvOpcionesElegidas.Rows.Add(aviso.mensaje);
                                dictAvisosSel.Add(aviso.id, aviso);
                            }
                            
                            dgvListadoAvisos.Rows.Clear();
                            dgvListadoAvisos.Columns[1].HeaderText = " Opciones ";
                            dgvListadoAvisos.Rows.Add(1, "Alarmas");
                            dgvListadoAvisos.Rows.Add(2, "Avisos");
                            dgvListadoAvisos.Visible = true;

                            labelNroHab.Text = "Ingrese Opción ";
                            tbNroHab.Text = "1";
                            pasoAsignacion = "opcion";
                            panelPromos.Visible = true;

                            break;
                        
                        case "opcion":
                            int.TryParse(tbNroHab.Text,out opcion);
                            if (opcion == 1)
                            {                               
                                try
                                {
                                    dgvListadoAvisos.Rows.Clear();
                                    foreach (Aviso av in Habitacion.listadoAlarmas())
                                    {
                                        dgvListadoAvisos.Rows.Add(av.id.ToString(), av.mensaje);
                                        dictAvisos.Add(av.id, av);
                                    }                                    
                                    dgvOpcionesElegidas.ClearSelection();
                                    dgvListadoAvisos.ClearSelection();
                                }
                                catch (Exception ex)
                                {
                                    labelMensaje.Text = ex.Message;
                                    labelMensaje.Visible = true;
                                    log.Error(ex.Message + " - " + ex.StackTrace);
                                }
                                labelNroHab.Text = "Seleccione Alarma ";
                                tbNroHab.Text = dictAvisos.Keys.First().ToString();
                                pasoAsignacion = "alarma";
                                panelPromos.Visible = true;
                            }
                            else if (opcion == 2)
                            {
                                try
                                {
                                    dgvListadoAvisos.Rows.Clear();
                                    foreach (Aviso av in Habitacion.listadoAvisos())
                                    {
                                        dgvListadoAvisos.Rows.Add(av.id.ToString(), av.mensaje);
                                        dictAvisos.Add(av.id, av);
                                    }
                                    dgvOpcionesElegidas.ClearSelection();
                                    dgvListadoAvisos.ClearSelection();
                                }
                                catch (Exception ex)
                                {
                                    labelMensaje.Text = ex.Message;
                                    labelMensaje.Visible = true;
                                    log.Error(ex.Message + " - " + ex.StackTrace);
                                }
                                labelNroHab.Text = "Seleccione Aviso";
                                tbNroHab.Text = dictAvisos.Keys.First().ToString();
                                pasoAsignacion = "aviso";
                                panelPromos.Visible = true;
                            }
                            else
                            {
                                labelMensaje.Text = "* La opción elegida no existe *";
                                labelMensaje.Visible = true;
                            }

                            break;

                        case "alarma":

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

                                /*--- Modifico el dgv Promos ---*/
                                dgvListadoAvisos.Rows.Clear();
                                dgvListadoAvisos.RowTemplate.Height = 80;
                                dgvListadoAvisos.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
                                dgvListadoAvisos.Columns[1].HeaderText = " Opciones ";
                                dgvListadoAvisos.Columns.RemoveAt(0);
                                dgvListadoAvisos.Rows.Add("Esc - Cancelar");
                                dgvListadoAvisos.Rows.Add("Enter - Confirmar");
                                dgvListadoAvisos.ClearSelection();
                                panelPromos.Visible = true;
                                /*-----------------------------------------------*/

                                break;
                            }
                            if (dictAlarmasSel.ContainsKey(avisoSel))
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

                            /*--- Modifico el dgv Promos ---*/
                            dgvListadoAvisos.Rows.Clear();
                            dgvListadoAvisos.RowTemplate.Height = 80;
                            dgvListadoAvisos.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
                            dgvListadoAvisos.Columns[1].HeaderText = " Opciones ";
                            dgvListadoAvisos.Columns.RemoveAt(0);
                            dgvListadoAvisos.Rows.Add("Esc - Cancelar");
                            dgvListadoAvisos.Rows.Add("Enter - Confirmar");
                            dgvListadoAvisos.ClearSelection();
                            panelPromos.Visible = true;
                            /*-----------------------------------------------*/

                            break;

                        case "aviso":
                            
                            if (tbNroHab.Text[0] == '.')
                            {
                                tbNroHab.Text = tbNroHab.Text.Replace(".", "");
                                avisoSel = string.IsNullOrEmpty(tbNroHab.Text) ? 0 : int.Parse(tbNroHab.Text);
                                if (!dictAvisosSel.ContainsKey(avisoSel))
                                {
                                    labelMensaje.Text = "* El Aviso seleccionado no fue cargado *";
                                    labelMensaje.Visible = true;
                                    return;
                                }
                                labelMensaje.Visible = false;
                                dgvOpcionesElegidas.Rows.Add(dictAvisos[avisoSel].mensaje);
                                dgvOpcionesElegidas.Rows[dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None)].DefaultCellStyle.ForeColor = Color.Red;
                                labelNroHab.Text = "Confirma Eliminar Aviso?";
                                tbNroHab.Visible = false;
                                pasoAsignacion = "quitarAviso";                                                                
                            }
                            else
                            {
                                avisoSel = string.IsNullOrEmpty(tbNroHab.Text) ? 0 : int.Parse(tbNroHab.Text);

                                if (!dictAvisos.ContainsKey(avisoSel))
                                {
                                    labelMensaje.Text = "* El Aviso seleccionado no existe *";
                                    labelMensaje.Visible = true;
                                    return;
                                }

                                labelMensaje.Visible = false;
                                dgvOpcionesElegidas.Rows.Add(dictAvisos[avisoSel].mensaje);
                                labelNroHab.Text = "Confirma Aviso?";
                                tbNroHab.Visible = false;
                                pasoAsignacion = "confirmarAviso";
                            }
                            /*--- Modifico el dgv Promos ---*/
                            dgvListadoAvisos.Rows.Clear();
                            dgvListadoAvisos.RowTemplate.Height = 80;
                            dgvListadoAvisos.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
                            dgvListadoAvisos.Columns[1].HeaderText = " Opciones ";
                            dgvListadoAvisos.Columns.RemoveAt(0);
                            dgvListadoAvisos.Rows.Add("Esc - Cancelar");
                            dgvListadoAvisos.Rows.Add("Enter - Confirmar");
                            dgvListadoAvisos.ClearSelection();
                            panelPromos.Visible = true;
                            /*-----------------------------------------------*/

                            break;

                        case "confirmar":
                            Habitacion.agregarAlarma((fPrincipal2)this.Owner ,nroHab, hora, avisoSel);
                            volverFormPrincipal();
                            return;

                        case "confirmarAviso":
                            Habitacion.agregarAviso((fPrincipal2)this.Owner, nroHab,avisoSel);
                            volverFormPrincipal();
                            return;

                        case "quitar":
                            Habitacion.quitarAlarma((fPrincipal2)this.Owner, nroHab, avisoSel);
                            tools.actualizarListadoTurnos(((fPrincipal2)this.Owner).dataGridView1, ((fPrincipal2)this.Owner).dataGridView2);
                            volverFormPrincipal();
                            return;
                            
                        case "quitarAviso":
                            Habitacion.quitarAviso((fPrincipal2)this.Owner, nroHab, avisoSel);
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
            if (!dictAlarmasSel.ContainsKey(aviso))
                return false;
            return true;            
        }

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
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
            dgvOpcionesElegidas.Rows.Add("Habitación Nro:");
            dgvOpcionesElegidas.ClearSelection();
            dgvListadoAvisos.ClearSelection();
            //try
            //{
            //    foreach (Aviso av in Habitacion.listadoAvisos())
            //    {
            //        dgvListadoAvisos.Rows.Add(av.id.ToString(), av.mensaje);
            //        dictAvisos.Add(av.id, av);
            //    }
               
            //}
            //catch (Exception ex)
            //{
            //    labelMensaje.Text = ex.Message;
            //    labelMensaje.Visible = true;
            //    log.Error(ex.Message + " - " + ex.StackTrace);
            //}
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
