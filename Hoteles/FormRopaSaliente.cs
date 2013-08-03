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
    public partial class FormRopaSaliente: Form
    {
        string pasoAsignacion = "articulo";
        bool ropaSaliente = true;
        int nroArtElegido;
        int nroHab;
        Socio socio = new Socio();
        Dictionary<int, string> DictArticulos = new Dictionary<int, string>();
        Dictionary<int, int> DictArticulosPedidos = new Dictionary<int, int>();
        //Articulo artElegido;
        int artElegido;


        public FormRopaSaliente(bool saliente)
        {
            InitializeComponent();
            if (!saliente)// si es entrante :
            {
                labelTitulo.Text = "Ropa Devuelta del Lavadero";
                ropaSaliente = false;
            }
            
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
            int indiceFilaAct = 0;
            if (keyData == Keys.Escape)
            {
                if (pasoAsignacion == "cantidad" && nroArtElegido != 0)
                {
                    dgvOpcionesElegidas.Rows.RemoveAt(dgvOpcionesElegidas.Rows.Count - 1);
                    labelNroHab.Text = "Ingresar Nro.Art ";
                    tbNroHab.Text = "";                    
                    pasoAsignacion = "articulo";
                }
                else
                {
                    volverFormPrincipal();
                    return true;
                }                
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
            LoggerProxy.Info("Salir Pedido de Bar");
            this.Owner.Show();
            this.Owner.Focus();            
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
                            if(ropaSaliente)
                                labelNroHab.Text = "¿ Confirma Envío ?";
                            else
                                labelNroHab.Text = "¿ Confirma Recepción ?";
                            tbNroHab.Text = "1";
                            tbNroHab.Visible = false;

                            /*--- Modifico el dgv Promos ---*/
                            
                            dgvPromos.Rows.Clear();
                            dgvPromos.RowTemplate.Height = 80;
                            dgvPromos.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
                            dgvPromos.Columns[1].HeaderText = " Opciones ";                            
                            dgvPromos.Columns.RemoveAt(0);
                            
                            dgvPromos.Rows.Add("Esc - Cancelar");
                            dgvPromos.Rows.Add("Enter - Confirmar");
                            dgvPromos.ClearSelection();
                            /*-----------------------------------------------*/

                            break;
                        }
                        labelMensaje.Visible = false;
                        nroArtElegido = int.Parse(tbNroHab.Text);
                        dgvOpcionesElegidas.Rows.Add(DictArticulos[nroArtElegido]);
                        int ultFila = dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None);
                        dgvOpcionesElegidas.Rows[ultFila].DefaultCellStyle.ForeColor = Color.Red;
                        dgvOpcionesElegidas.FirstDisplayedScrollingRowIndex = ultFila;
                        dgvOpcionesElegidas.ClearSelection();
                        this.artElegido = nroArtElegido;
                        pasoAsignacion = "cantidad";
                        tbNroHab.Text = "1";
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
                                if (ropaSaliente)
                                {
                                    Articulo.generarSalidaRopa(DictArticulosPedidos);
                                    LoggerProxy.Info(string.Format("Ejecuto Salida Ropa"));
                                }
                                else
                                {
                                    Articulo.generarEntradaRopa(DictArticulosPedidos);
                                    LoggerProxy.Info(string.Format("Ejecuto Entrada Ropa"));
                                }
                                //if(tools.obtenerParametroInt("emisionPedidos") == 1 )
                                //    new Impresora().ImprimirSolicitudBar(labelMensaje, DictArticulosPedidos, nroHab);
                                volverFormPrincipal();
                                
                            }
                            catch (Exception ex)
                            {
                                labelMensaje.Text = "Ha ocurrido un error.Revisar los Logs.";
                                labelMensaje.Visible = true;
                                LoggerProxy.Error("Error al generar Salida de ropa - " + ex.Message + " " + ex.StackTrace);
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

            foreach (DataRow dr in Articulo.obtenerListaRopa().Rows)
            {
                dgvPromos.Rows.Add(dr[0].ToString(), dr[1].ToString());
                DictArticulos.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
      
            dgvPromos.ClearSelection();            
            dgvOpcionesElegidas.ClearSelection();
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }

    }
}
