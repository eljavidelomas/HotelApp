﻿using System;
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
    public partial class FormPedidoBar : Form
    {
        string pasoAsignacion = "nroHabitacion";
        int nroArtElegido;
        int nroHab;
        Socio socio = new Socio();
        Dictionary<int, Articulo> DictArticulos = new Dictionary<int, Articulo>();
        Dictionary<int, int> DictArticulosPedidos = new Dictionary<int, int>();
        Articulo artElegido;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FormPedidoBar()
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
            int indiceFilaAct = 0;
            if (keyData == Keys.Escape)
            {
                volverFormPrincipal();

                return true;
            }
            if (keyData == Keys.F7)
            {
                return true;
            }
            if (keyData == Keys.Up)
            {
                indiceFilaAct = dgvPromos.Rows.GetFirstRow(DataGridViewElementStates.Displayed) - 1;
                dgvPromos.FirstDisplayedScrollingRowIndex = indiceFilaAct <= 0 ? 0 : indiceFilaAct;
                return true;
            }

            if (keyData == Keys.Down)
            {
                indiceFilaAct = dgvPromos.Rows.GetFirstRow(DataGridViewElementStates.Displayed) + 1;
                dgvPromos.FirstDisplayedScrollingRowIndex = indiceFilaAct >= dgvPromos.Rows.Count - 1 ? dgvPromos.Rows.Count - 1 : indiceFilaAct;
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
                        dgvOpcionesElegidas.ClearSelection();
                        foreach (DataRow dr in Articulo.obtenerConsumos(nroHab).Rows)
                        {
                            dgvOpcionesElegidas.Rows.Add(dr[1].ToString() + " " + dr[2].ToString(), String.Format("{0:C}", decimal.Parse(dr[3].ToString())));
                        }
                        labelNroHab.Text = "Ingresar Nro.Art ";
                        tbNroHab.Text = "0";
                        pasoAsignacion = "articulo";

                        break;

                    case "articulo":

                        msj = validarArticulo(tbNroHab);
                        if (msj != string.Empty)
                        {
                            labelMensaje.Visible = true;
                            labelMensaje.Text = msj;
                            return;
                        }
                        if (tbNroHab.Text == "0") //Esto significa que no quiere mas articulos.
                        {
                            labelNroHab.Text = "Confirma pedido ?";
                            tbNroHab.Text = "1";
                            tbNroHab.Visible = false;
                            break;
                        }
                        labelMensaje.Visible = false;
                        nroArtElegido = int.Parse(tbNroHab.Text);
                        dgvOpcionesElegidas.Rows.Add(DictArticulos[nroArtElegido].nombre);
                        int ultFila = dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None);
                        dgvOpcionesElegidas.Rows[ultFila].DefaultCellStyle.ForeColor = Color.Red;
                        dgvOpcionesElegidas.FirstDisplayedScrollingRowIndex = ultFila;
                        dgvOpcionesElegidas.ClearSelection();
                        this.artElegido = DictArticulos[nroArtElegido];
                        pasoAsignacion = "cantidad";
                        tbNroHab.Text = "0";
                        labelNroHab.Text = "Ingresar Cantidad de Articulos ";

                        break;

                    case "cantidad":

                        int cantidad;
                        if (tbNroHab.Text == "" || (cantidad = int.Parse(tbNroHab.Text)) == 0)
                        {
                            labelMensaje.Visible = true;
                            labelMensaje.Text = "* La cantidad debe ser un numero mayor a 0 *";
                            return;
                        }
                        labelMensaje.Visible = false;
                        if (DictArticulosPedidos.ContainsKey(nroArtElegido))
                            DictArticulosPedidos[nroArtElegido] += cantidad;
                        else
                            DictArticulosPedidos.Add(nroArtElegido, cantidad);
                        int indice = dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None);// [[3].Cells[1].Value = dgvOpcionesElegidas.Rows[3].Cells[1].Value.ToString() + " " + socio.puntaje;
                        dgvOpcionesElegidas.Rows[indice].Cells[0].Value = cantidad + " " + dgvOpcionesElegidas.Rows[indice].Cells[0].Value;
                        dgvOpcionesElegidas.Rows[indice].Cells[1].Value = String.Format("{0:C}", DictArticulos[nroArtElegido].precio * cantidad);
                        dgvOpcionesElegidas.ClearSelection();
                        labelNroHab.Text = "Ingresar Nro.Art ";
                        tbNroHab.Text = "0";
                        pasoAsignacion = "articulo";

                        break;

                    case "confirmar":

                        if (tbNroHab.Text == "")
                        {
                            labelMensaje.Visible = true;
                            labelMensaje.Text = "* La cantidad debe ser un numero mayor a 0 *";
                            return;
                        }
                        labelMensaje.Visible = false;
                        if (int.Parse(tbNroHab.Text) == 1)
                        {
                            try
                            {
                                Articulo.generarPedidoBar((fPrincipal)this.Owner, DictArticulosPedidos, nroHab);
                                volverFormPrincipal();
                                new Impresora().ImprimirSolicitudBar(labelMensaje, DictArticulosPedidos, nroHab);                                
                            }
                            catch (Exception ex)
                            {
                                labelMensaje.Text = "Ha ocurrido un error.Revisar los Logs.";
                                labelMensaje.Visible = true;
                                log.Error("Error al generar pedido de Bar - " + ex.Message + " " + ex.StackTrace);
                            }

                            return;
                        }
                        if (int.Parse(tbNroHab.Text) == 0)
                        {
                            volverFormPrincipal();
                            return;
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

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["estado"].ToString() != "O")
                    return "* La habitación no esta Ocupada *";
            }
            else
                return "* El número de habitación no existe *";

            return String.Empty;
        }

        private string validarArticulo(TextBox tbNroArt)
        {
            if (tbNroArt.Text == String.Empty)
                return "* Debe ingresar el número de Articulo *";

            if (int.Parse(tbNroArt.Text) == 0)
            {
                if (artElegido == null)
                    return "* El Articulo elegido no existe *";
                else
                {
                    pasoAsignacion = "confirmar";
                    return String.Empty;
                }
            }

            if (!DictArticulos.ContainsKey(int.Parse(tbNroArt.Text)))
                return "* El Articulo elegido no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            DataRowCollection articulos = Articulo.obtenerListaArticulos().Rows;
                       

            dgvPromos.RowTemplate.Height = tools.altoFilaBar;// con un heigt de 60 entran 6
            dgvOpcionesElegidas.RowTemplate.Height = tools.altoFilaBar;

            foreach (DataRow dr in articulos)
            {
                dgvPromos.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                DictArticulos.Add(Convert.ToInt32(dr[0]), new Articulo(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDecimal(dr[2]),0));
            }
            dgvPromos.Rows.RemoveAt(dgvPromos.Rows.GetLastRow(DataGridViewElementStates.None));
            dgvPromos.ClearSelection();
            dgvOpcionesElegidas.Rows.Add("Habitación Nro:");
            dgvOpcionesElegidas.ClearSelection();
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }

    }
}