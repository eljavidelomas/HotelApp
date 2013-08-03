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
using Hoteles.Properties;

namespace Hoteles
{


    public partial class FormCambiarEstado : Form
    {
        string pasoAsignacion = "nroHabitacion";
        int nroHab;
        int opcion;
        int maxFilas;
        int cantHab;
        string estHab;
        Dictionary<int, string> dOpciones = new Dictionary<int, string>();
        DataGridView tabla1;
        DataGridView tabla2;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public FormCambiarEstado()
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
            LoggerProxy.Info("Salir Cambiar Estado");
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
                            labelTitulo.Text += " - " + nroHab.ToString();
                            labelNroHab.Text = "Ingresar Opción";
                            dgvOpciones.Visible = true;
                            tbNroHab.Text = dOpciones.Keys.ElementAt(0).ToString();

                            pasoAsignacion = "opcion";

                            break;

                        case "opcion":
                            opcion = string.IsNullOrEmpty(tbNroHab.Text) ? 0 : int.Parse(tbNroHab.Text);
                            if (!dOpciones.ContainsKey(opcion))
                            {
                                labelMensaje.Text = "* La opción elegida no existe *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;

                            labelNroHab.Text = "¿Confirma Cambio de Estado?";
                            tbNroHab.Text = "0";
                            tbNroHab.Visible = false;
                            pasoAsignacion = "confirmar";

                            /*--- Modifico el dgv Promos ---*/
                            dgvOpciones.Rows.Clear();
                            dgvOpciones.RowTemplate.Height = 80;
                            dgvOpciones.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
                            dgvOpciones.Columns[1].HeaderText = " Opciones ";
                            dgvOpciones.Columns.RemoveAt(0);
                            dgvOpciones.Rows.Add("Esc - Cancelar");
                            dgvOpciones.Rows.Add("Enter - Confirmar");
                            dgvOpciones.ClearSelection();
                            
                            /*-----------------------------------------------*/

                            break;

                        case "confirmar":

                            switch (opcion)
                            {
                                case 1:

                                    if (estHab == "M" || estHab == "D")
                                        estHab = "X";
                                    else if (estHab == "X")
                                        estHab = "D";

                                    Habitacion.CambiarEstado((fPrincipal2)this.Owner, nroHab, estHab);
                                    ((fPrincipal2)Owner).borrarPB_parpadeo(nroHab);
                                    LoggerProxy.Info(string.Format("Ejecuto Cambio Habitación - Hab:{0} Opcion:{1}",nroHab,dOpciones[opcion]));
                                    volverFormPrincipal();
                                    break;

                                default:
                                    labelMensaje.Text = "* No implementado *";
                                    labelMensaje.Visible = true;
                                    break;
                            }

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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal2.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                estHab = ds.Tables[0].Rows[0]["estado"].ToString();
                if (estHab == "A" || estHab == "O")
                    return "* La habitación no puede estar ni asignada ni ocupada. *";
            }
            else
                return "* El número de habitación no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {            
            int altoFilaExtraMedioPagos;            
            tabla1 = TablaTurnos.nuevaTabla();
            tabla2 = TablaTurnos.nuevaTabla();

            tabla1.DefaultCellStyle.BackColor = Color.White;
            tabla2.DefaultCellStyle.BackColor = Color.White;
            tabla2.Columns[8].Visible = tabla1.Columns[8].Visible = true;
         
            this.tableLayoutPanel3.Controls.Add(tabla1, 0, 0);

            int altoFila;
            int altoFilaExtra;
            tools.calcularAlturas(tabla1.Height - tabla1.ColumnHeadersHeight, fPrincipal2.maxFilas, out altoFila, out altoFilaExtra);
            tabla1.RowTemplate.Height = altoFila;
            tabla2.RowTemplate.Height = altoFila;
            tabla1.ColumnHeadersHeight = tabla1.ColumnHeadersHeight + altoFilaExtra;
            tabla2.ColumnHeadersHeight = tabla1.ColumnHeadersHeight;
            float tamFuente = 10f + (3.6f - (0.1f * cantHab));
            tabla1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", tamFuente, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabla2.DefaultCellStyle.Font = tabla1.DefaultCellStyle.Font;            
            this.tableLayoutPanel3.Controls.Add(tabla2, 1, 0);

            tools.actualizarListadoTurnos(tabla1, tabla2);
            tabla1.Columns.RemoveAt(7);
            tabla1.Columns.RemoveAt(6);
            tabla2.Columns.RemoveAt(7);
            tabla2.Columns.RemoveAt(6);
            
            tools.calcularAlturas(dgvOpciones.Height - dgvOpciones.ColumnHeadersHeight, opcionesCambEst.opcionesCambioEstado.Count > tools.minCantFilas ? opcionesCambEst.opcionesCambioEstado.Count : tools.minCantFilas, out altoFila, out altoFilaExtraMedioPagos);
            dgvOpciones.RowTemplate.Height = altoFila;
            this.opcionesCambioEstadoTableAdapter.Fill(this.opcionesCambEst.opcionesCambioEstado);
            dgvOpciones.DataSource = null;
            foreach (DataRow dr in opcionesCambEst.opcionesCambioEstado)
            {
                dOpciones.Add(int.Parse(dr[0].ToString()), dr[1].ToString());
                dgvOpciones.Rows.Add(dr[0].ToString(), dr[1].ToString());
            }

            // ----  Completando la tabla mediosPagos  ----//
            tools.completarDG(dgvOpciones, altoFilaExtraMedioPagos);
            dgvOpciones.ClearSelection();
            tabla1.ClearSelection();
            tabla2.ClearSelection();
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }

        public void dibujar(int maxFilas, int cantHab, SqlDataReader reader)
        {
            if (tabla1.Rows.Count > 0)
            {
                tabla1.Rows.Clear();
            }
            if (tabla2 != null)
            {
                this.tableLayoutPanel3.Controls.Remove(tabla2);
                tabla2.Rows.Clear();
                tabla2 = null;
            }
            int ultFila = 0;
            while (ultFila < maxFilas && reader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                tabla1.DefaultCellStyle.BackColor = Color.White;
                tabla1.Rows.Add(reader["nroHabitacion"], reader["categoria2"].ToString() == "" ? reader["categoria"] : reader["categoria2"]);
                ultFila = tabla1.Rows.GetLastRow(DataGridViewElementStates.None);

                if (reader["estado"].ToString() == "D") // Disponible
                {
                    tabla1.Rows[ultFila].Cells["estado"].Value = "D";

                    tabla1.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.vacio);
                    tabla1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                }
                else if (reader["estado"].ToString() == "A") // Asignada
                {
                    tabla1.Rows[ultFila].Cells["estado"].Value = "A";

                    tabla1.Rows[ultFila].DefaultCellStyle.Font = new Font(tabla1.DefaultCellStyle.Font, FontStyle.Bold);
                    //Si hay alarmas
                    if (reader["aviso"].ToString() != "")
                        tabla1.Rows[ultFila].Cells["alarma"].Value = ((System.Drawing.Image)Resources.relojdespertador);
                    tabla1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                }
                else if (reader["estado"].ToString() == "O") // Ocupada
                {
                    tabla1.Rows[ultFila].Cells["estado"].Value = "O";
                    tabla1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);

                    tabla1.Rows[ultFila].DefaultCellStyle.Font = new Font(tabla1.DefaultCellStyle.Font, FontStyle.Bold);
                    tabla1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Tomato;
                    if (reader["aviso"].ToString() != "")
                        tabla1.Rows[ultFila].Cells["alarma"].Value = ((System.Drawing.Image)Resources.relojdespertador);
                }
                else if (reader["estado"].ToString() == "M") // Mucama
                {
                    tabla1.Rows[ultFila].Cells["estado"].Value = "M"; // Mucama
                    tabla1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                    tabla1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Yellow;
                }
                else // Otro...
                {
                    //tabla1.Rows[ultFila].DefaultCellStyle.BackColor = Color.Gainsboro;
                    tabla1.Rows[ultFila].Cells["estado"].Value = "X"; // deshabilitado
                    tabla1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.vacio);
                    tabla1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Gainsboro;
                }
            }
            if (cantHab > maxFilas)
            {
                ultFila = 0;
                tabla2 = TablaTurnos.nuevaTabla();                
                tabla2.DefaultCellStyle.BackColor = Color.White;
                tabla2.Columns[8].Visible = true;
                tabla2.Columns.RemoveAt(7);
                tabla2.Columns.RemoveAt(6);
                tabla2.DefaultCellStyle.Font = tabla1.DefaultCellStyle.Font;
                tabla2.ColumnHeadersHeight = tabla1.ColumnHeadersHeight;
                tabla2.RowTemplate.Height = tabla1.RowTemplate.Height;
                this.tableLayoutPanel3.Controls.Add(tabla2, 1, 0);

                while (reader.Read() && ultFila < 24)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    tabla2.Rows.Add(reader["nroHabitacion"], reader["categoria"]);
                    ultFila = tabla2.Rows.GetLastRow(DataGridViewElementStates.None);


                    if (reader["estado"].ToString() == "D")
                    {
                        tabla2.Rows[ultFila].Cells["estado"].Value = "D";

                        tabla2.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.vacio);
                        tabla2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                    }
                    else if (reader["estado"].ToString() == "A")
                    {
                        tabla2.Rows[ultFila].Cells["estado"].Value = "A";

                        tabla2.Rows[ultFila].DefaultCellStyle.Font = new Font(tabla1.DefaultCellStyle.Font, FontStyle.Bold);
                        //Si hay alarmas
                        if (reader["aviso"].ToString() != "")
                            tabla2.Rows[ultFila].Cells["alarma"].Value = ((System.Drawing.Image)Resources.relojdespertador);
                        tabla2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                    }
                    else if (reader["estado"].ToString() == "O") // Ocupada
                    {
                        tabla2.Rows[ultFila].Cells["estado"].Value = "O";
                        tabla2.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);

                        tabla2.Rows[ultFila].DefaultCellStyle.Font = new Font(tabla2.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                        tabla2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Tomato;
                        if (reader["aviso"].ToString() != "")
                            tabla2.Rows[ultFila].Cells["alarma"].Value = ((System.Drawing.Image)Resources.relojdespertador);
                    }
                    else if (reader["estado"].ToString() == "M") // Mucama
                    {
                        tabla2.Rows[ultFila].Cells["estado"].Value = "M"; // Mucama
                        tabla2.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                        tabla2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Yellow;
                    }
                    else // Otro...
                    {
                        //tabla2.Rows[ultFila].DefaultCellStyle.BackColor = Color.Gainsboro;
                        tabla2.Rows[ultFila].Cells["estado"].Value = "X"; // deshabilitado
                        tabla2.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.vacio);
                        tabla2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Gainsboro;
                    }
                }
                tabla2.ClearSelection();
            }
            tabla1.ClearSelection();
            reader.Close();
        }
    }
}
