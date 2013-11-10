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
using WindowsFormsApplication1;
using System.IO;

namespace Hoteles
{
    public partial class FormCompras : Form
    {
        string pasoAsignacion = "articulos";
        int nroArtElegido;
        int nroHab;
        int cantReposicion;
        int cantCompras;
        DateTime fecha;
        decimal punitario;

        Socio socio = new Socio();
        Dictionary<int, Articulo> DictArticulos = new Dictionary<int, Articulo>();

        Articulo artElegido;


        public FormCompras()
        {
            InitializeComponent();
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
                volverFormPrincipal();
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
            this.Hide();
            //if (tools.obtenerParametroString("emisionPedidos") == "No")
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

                        labelMensaje.Visible = false;
                        nroArtElegido = int.Parse(tbNroHab.Text);

                        this.artElegido = DictArticulos[nroArtElegido];
                        pasoAsignacion = "fecha";
                        tbNroHab.Text = DateTime.Now.ToString("yyyyMMdd");
                        labelNroHab.Text = "Ingresar Fecha(AAAAMMDD)";

                        break;

                    case "fecha":

                        if (!DateTime.TryParseExact(tbNroHab.Text, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out fecha))
                        {
                            labelMensaje.Visible = true;
                            labelMensaje.Text = "* La fecha es incorrecta *";
                            return;
                        }
                        labelMensaje.Visible = false;
                        /* if (DictArticulosPedidos.ContainsKey(nroArtElegido))
                             DictArticulosPedidos[nroArtElegido] += cantidad;
                         else
                             DictArticulosPedidos.Add(nroArtElegido, cantidad);
                         */
                        labelNroHab.Text = "Ingresar Compra ";
                        tbNroHab.Text = "0";
                        pasoAsignacion = "compra";

                        break;

                    case "compra":

                        cantCompras = int.Parse(tbNroHab.Text);
                        /* if (tbNroHab.Text == "" || (cantCompra = int.Parse(tbNroHab.Text)) == 0)
                         {
                             labelMensaje.Visible = true;
                             labelMensaje.Text = "* La cantidad debe ser un numero mayor a 0 *";
                             return;
                         }*/
                        labelMensaje.Visible = false;

                        labelNroHab.Text = "Ingresar Reposición ";
                        tbNroHab.Text = "0";
                        pasoAsignacion = "reposicion";

                        break;

                    case "reposicion":

                        cantReposicion = int.Parse(tbNroHab.Text);
                        /* if (tbNroHab.Text == "" || (cantReposicion = int.Parse(tbNroHab.Text)) == 0)
                         {
                             labelMensaje.Visible = true;
                             labelMensaje.Text = "* La cantidad debe ser un numero mayor a 0 *";
                             return;
                         }*/
                        labelMensaje.Visible = false;

                        labelNroHab.Text = "Ingresar P.Unitario ";
                        tbNroHab.Text = "0";
                        pasoAsignacion = "punitario";

                        break;

                    case "punitario":

                        punitario = decimal.Parse(tbNroHab.Text.Replace('.', ','));
                        /* if (tbNroHab.Text == "" || (punitario = decimal.Parse(tbNroHab.Text.Replace('.',','))) == 0)
                         {
                             labelMensaje.Visible = true;
                             labelMensaje.Text = "* La cantidad debe ser un numero mayor a 0 *";
                             return;
                         }*/
                        labelMensaje.Visible = false;

                        labelNroHab.Text = "Confirma Compra? ";
                        tbNroHab.Text = "0";
                        pasoAsignacion = "confirmar";

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

                    case "confirmar":

                        labelMensaje.Visible = false;

                        try
                        {
                            insertarCompras();
                            LoggerProxy.Info(string.Format("Ejecuto Compras"));
                            volverFormPrincipal();

                        }
                        catch (Exception ex)
                        {
                            labelMensaje.Text = "Ha ocurrido un error.Revisar los Logs.";
                            labelMensaje.Visible = true;
                            LoggerProxy.Error("Error al generar pedido de Bar - " + ex.Message + " " + ex.StackTrace);
                        }
                        return;                        

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

        private void insertarCompras()
        {
            SqlCommand comm = new SqlCommand("compras_insertar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@articuloId", artElegido.id);
            comm.Parameters.AddWithValue("@descripcion", artElegido.nombre);
            comm.Parameters.AddWithValue("@fecha", fecha);
            comm.Parameters.AddWithValue("compra", cantCompras);
            comm.Parameters.AddWithValue("reposicion", cantReposicion);
            if (punitario > 0)
                comm.Parameters.AddWithValue("precioU", punitario);
            comm.ExecuteNonQuery();

        }

        private void imprimirPedido(object ob)
        {
            pedidoAux p = (pedidoAux)ob;
            new Impresora().ImprimirSolicitudBar(p.mensajeError, p.dict, p.nroHab);
        }

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
            if (tbNroHab.Text == "0")
                return string.Empty;

            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal2.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["estado"].ToString() != "O" &&
                    ds.Tables[0].Rows[0]["estado"].ToString() != "A")
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
            // TODO: esta línea de código carga datos en la tabla 'dsCompras.compras' Puede moverla o quitarla según sea necesario.
            this.comprasTableAdapter.Fill(this.dsCompras.compras);
            DataRowCollection articulos = Articulo.obtenerListaArticulos().Rows;

            dgvPromos.RowTemplate.Height = 25;// tools.altoFilaBar;// con un heigt de 60 entran 6


            foreach (DataRow dr in articulos)
            {
                dgvPromos.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
                DictArticulos.Add(Convert.ToInt32(dr[0]), new Articulo(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToDecimal(dr[2]), 0));
            }
            dgvPromos.ClearSelection();
            dgvCompras.ClearSelection();

            labelNroHab.Text = "Ingresar Nro.Art ";
            tbNroHab.Text = "0";
            pasoAsignacion = "articulo";
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }
    }

}
