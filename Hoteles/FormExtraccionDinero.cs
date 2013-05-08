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
    public partial class FormExtraccionDinero : Form
    {
        string pasoAsignacion = "cuenta";
        int nroArtElegido;
        int ultFila;
        int nroCuenta;
        decimal monto;
        bool insertar = true;
        Socio socio = new Socio();
        Dictionary<int, string> DictCuentas = new Dictionary<int, string>();
        Dictionary<int, decimal> DictGastos = new Dictionary<int, decimal>();
        Articulo artElegido;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FormExtraccionDinero()
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

            if ((char)Keys.Enter == e.KeyChar)
            {
                e.Handled = true;

                switch (pasoAsignacion)
                {
                    case "cuenta":

                        msj = validarCuenta(tbNroHab);
                        if (msj != string.Empty)
                        {
                            labelMensaje.Text = msj;
                            labelMensaje.Visible = true;
                            return;
                        }
                       
                        labelMensaje.Visible = false;
                        nroCuenta = int.Parse(tbNroHab.Text);
                        dgvOpcionesElegidas.Rows.Add(DictCuentas[nroCuenta]);
                        ultFila = dgvOpcionesElegidas.Rows.GetLastRow(DataGridViewElementStates.None);
                        dgvOpcionesElegidas.Rows[ultFila].DefaultCellStyle.ForeColor = Color.Red;
                        dgvOpcionesElegidas.FirstDisplayedScrollingRowIndex = ultFila;
                        dgvOpcionesElegidas.ClearSelection();
                        pasoAsignacion = "monto";
                        tbNroHab.Text = "0";
                        labelNroHab.Text = "Ingresar Monto ";

                        break;

                    case "monto":

                        if (string.IsNullOrEmpty(tbNroHab.Text) || tbNroHab.Text == "0")
                        {
                            labelMensaje.Text = "* El monto debe ser mayor a cero *";
                            labelMensaje.Visible = true;
                            return;
                        }
                        string montoAux = tbNroHab.Text[0] == '.' ? tbNroHab.Text.Remove(0, 1) : tbNroHab.Text;
                        if (!decimal.TryParse(montoAux.Replace('.', ','), out monto))
                        {
                            labelMensaje.Text = "* El valor ingresado es incorrecto *";
                            labelMensaje.Visible = true;
                            return;
                        }
                        labelMensaje.Visible = false;

                        if (montoAux.Length < tbNroHab.Text.Length) // si es menor, saque el punto de adelante
                        {
                            if (DictGastos[nroCuenta] < monto)
                            {
                                labelMensaje.Text = "* El monto a devolver no puede ser mayor al gastado *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            dgvOpcionesElegidas.Rows[ultFila].Cells[1].Value = String.Format("- {0:C}", monto);
                            insertar = false;
                        }
                        else
                        {
                            dgvOpcionesElegidas.Rows[ultFila].Cells[1].Value = String.Format("{0:C}", monto);
                        }                        
                        
                        pasoAsignacion = "confirmar";
                        tbNroHab.Text = "0";
                        tbNroHab.Visible = false;
                        labelNroHab.Text = "¿ Confirma ?";

                        /*--- Modifico el dgv Promos ---*/
                        dgvPromos.Rows.Clear();
                        dgvPromos.RowTemplate.Height = 80;
                        dgvPromos.RowTemplate.DefaultCellStyle.Font = tools.fuenteConfirma;
                        dgvPromos.Columns[1].HeaderText = " Opciones ";
                        dgvPromos.Columns.RemoveAt(0);
                        dgvPromos.Rows.Add("Esc - Cancelar");
                        dgvPromos.Rows.Add("Enter - Confirmar");
                        dgvPromos.ClearSelection();
                        panelPromos.Visible = true;
                        /*-----------------------------------------------*/

                        break;

                    case "confirmar":
                        
                        try
                        {
                            if (insertar)
                            {
                                if (tools.obtenerParametroInt("emisionGastos") == 1)
                                    new Impresora().ImprimirGasto(labelMensaje, monto, DictCuentas[nroCuenta]);
                                Gasto.insertar(nroCuenta, monto);
                            }
                            else
                                Gasto.devolver(nroCuenta, monto);
                            volverFormPrincipal();                            
                        }
                        catch (Exception ex)
                        {
                            labelMensaje.Text = "Ha ocurrido un error. Revisar los Logs.";
                            labelMensaje.Visible = true;
                            log.Error("Error al generar extracción de dinero -\r\n " + ex.Message + " " + ex.StackTrace);
                        }

                        return;

                    default:
                        break;
                }

                tbNroHab.Select(0, tbNroHab.TextLength);
                return;
            }

            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back && e.KeyChar != '.' || (e.KeyChar == '.' && (pasoAsignacion == "cuenta" )))
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


        private string validarCuenta(TextBox tbNroArt)
        {
            if (tbNroArt.Text == String.Empty)
                return "* Debe ingresar el número de Cuenta *";

            if (int.Parse(tbNroArt.Text) == 0)
            {
                if (artElegido == null)
                    return "* La Cuenta ingresada no existe *";
                else
                {
                    pasoAsignacion = "confirmar";
                    return String.Empty;
                }
            }

            if (!DictCuentas.ContainsKey(int.Parse(tbNroArt.Text)))
                return "* La Cuenta ingresada no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            DataRowCollection cuentas = Gasto.obtenerListaCuentasGastos().Rows;
            dgvPromos.RowTemplate.Height = tools.altoFilaBar;// con un heigt de 60 entran 6
            dgvOpcionesElegidas.RowTemplate.Height = tools.altoFilaBar;

            foreach (DataRow dr in cuentas)
            {
                dgvPromos.Rows.Add(dr[0], dr[1]);
                DictCuentas.Add(Convert.ToInt32(dr[0]), dr[1].ToString());
            }
            foreach (DataRow dr in Gasto.obtenerGastos(((fPrincipal2)this.Owner).conserjeActual.usuario).Rows)
            {
                dgvOpcionesElegidas.Rows.Add(dr[0].ToString(), String.Format("{0:C}", decimal.Parse(dr[1].ToString())));
                DictGastos.Add(int.Parse(dr[2].ToString()), decimal.Parse(dr[1].ToString()));
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
