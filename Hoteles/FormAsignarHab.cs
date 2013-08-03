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
    public partial class FormAsignarHab : Form
    {
        string pasoAsignacion = "nroHabitacion";
        int nroPromoElegida;
        int nroHab;
        int pernocte;
        int nroCategoria;
        decimal montoAdelantar;
        decimal montoAPagar;
        int medioPago;        
        int puntosACambiar = 0;
        string puntosStr;
        Socio socio = new Socio();
        Tarifa tarifaNoche;
        Dictionary<int, Descuento> DictDescuentos;
        Dictionary<int, string> dictMediosDePago= new Dictionary<int,string>();
        Dictionary<int, string> dictCategorias;
        Descuento desc;
        decimal descTotalHabitacion;
        decimal totExtra;
        string pernocteString;

        public FormAsignarHab()
        {
            
            InitializeComponent();
            GoFullscreen(true);
            tbNroHab.Focus();
            LoggerProxy.Info("Ingreso Asignar Habitación.");
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
                if (pasoAsignacion == "categoria")
                {
                    string msj = validarNroCategoria(tbNroHab);
                    if (msj == string.Empty)
                    {
                        Tarifa tarifa;

                        decimal precioPernocte = Tarifa.calcularPrecioConPernocte(int.Parse(tbNroHab.Text), out tarifa);//Habitacion.calcularPrecioConPernocte(int.Parse(tbNroHab.Text), out tarifa);
                        if (precioPernocte == 0)
                        {
                            labelMensaje.Text = "No se puede calcular el Precio Pernocte, posiblemente falten asignar tarifas para algun horario.";
                            labelMensaje.Visible = true;
                            return true;
                        }
                        else
                        {
                            labelMensaje.Text = "Precio Con Pernocte = " + precioPernocte.ToString("C2", CultureInfo.CreateSpecificCulture("es-AR"));
                            labelMensaje.Visible = true;
                            return true;
                        }
                    }
                    labelMensaje.Text = msj;
                    labelMensaje.Visible = true;
                    return true;
                }
            }
            if (pasoAsignacion == "confirmar")
                if (keyData == Keys.Enter)
                {
                    tbNroHab_KeyPress(this.tbNroHab, new KeyPressEventArgs((char)keyData));
                    return true;
                }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void volverFormPrincipal()
        {            
            LoggerProxy.Info("Salio Asignar Habitación.");
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

                            dgvPromos.Columns[1].HeaderText = "Categorias";
                            dgvOpcionesElegidas.Rows[0].Cells[1].Value = dgvOpcionesElegidas.Rows[0].Cells[1].Value.ToString() + " " + nroHab;

                            dictCategorias = Habitacion.obtenerCategorias(tbNroHab.Text);

                            foreach (int categoria in dictCategorias.Keys)
                            {
                                dgvPromos.Rows.Add(categoria, dictCategorias[categoria]);
                            }

                            panelPromos.Visible = true;
                            labelNroHab.Text = "Ingresar categoria";
                            tbNroHab.Text = dgvPromos.Rows[0].Cells[0].Value.ToString();
                            pasoAsignacion = "categoria";

                            break;

                        case "categoria":

                            msj = validarNroCategoria(tbNroHab);
                            if (msj != string.Empty)
                            {
                                labelMensaje.Text = msj;
                                labelMensaje.Visible = true;
                                return;
                            }

                            nroCategoria = int.Parse(tbNroHab.Text);
                            dgvPromos.Rows.Clear();
                            dgvPromos.Columns[1].HeaderText = "Promociones";

                            int nroPromo = 0;
                            int altoFila;
                            int altoFilaExtra;
                            labelMensaje.Visible = false;

                            DictDescuentos = new Dictionary<int, Descuento>();
                            dgvOpcionesElegidas.Rows[1].Cells[1].Value = dgvOpcionesElegidas.Rows[1].Cells[1].Value.ToString() + " " + dictCategorias[nroCategoria];
                            List<Descuento> lDescuentos = Descuento.obtenerDescuentos(nroCategoria);

                            tools.calcularAlturas(dgvPromos.Height - dgvPromos.ColumnHeadersHeight, lDescuentos.Count > tools.minCantFilas ? lDescuentos.Count : tools.minCantFilas, out altoFila, out altoFilaExtra);
                            dgvPromos.RowTemplate.Height = altoFila;

                            dgvPromos.Rows.Add(nroPromo, "Sin Promoción");
                            DictDescuentos.Add(nroPromo, new Descuento("Sin Promoción"));
                            foreach (Descuento desc in lDescuentos)
                            {
                                nroPromo++;
                                dgvPromos.Rows.Add(nroPromo, desc.nombre);
                                DictDescuentos.Add(nroPromo, desc);
                            }
                            tools.completarDG(dgvPromos, altoFilaExtra);
                            dgvPromos.ClearSelection();

                            panelPromos.Visible = true;
                            labelNroHab.Text = "Ingresar Promoción";
                            tbNroHab.Text = "0";
                            pasoAsignacion = "promocion";

                            break;

                        case "promocion":

                            msj = validarPromocion(tbNroHab);
                            if (msj != string.Empty)
                            {
                                labelMensaje.Visible = true;
                                labelMensaje.Text = msj;
                                return;
                            }
                            nroPromoElegida = int.Parse(tbNroHab.Text);
                            dgvOpcionesElegidas.Rows[2].Cells[1].Value = dgvOpcionesElegidas.Rows[2].Cells[1].Value.ToString() + " " + DictDescuentos[nroPromoElegida].nombre;
                            this.desc = DictDescuentos[nroPromoElegida];
                            if (nroPromoElegida == 0)// sin promocion
                            {
                                pasoAsignacion = "pernocte";
                                labelNroHab.Text = "Pernocte";
                                tbNroHab.Text = "0";
                                labelMensaje.Visible = false;
                                dgvPromos.Visible = false;
                            }
                            else
                            {
                                if (desc.nombre.ToLower().Contains("socio"))// promo socios, pedir tarjeta
                                {
                                    labelNroHab.Text = "Inserte Tarjeta";
                                    dgvPromos.Visible = false;
                                    tbNroHab.Text = "";
                                    tbNroHab.Width += 50;
                                    tbNroHab.MaxLength = 8;
                                    pasoAsignacion = "leerTarjeta";
                                    puntosStr = dgvOpcionesElegidas.Rows[4].Cells[1].Value.ToString();
                                    break;

                                }
                                else // otra promo
                                {
                                    pasoAsignacion = "pernocte";
                                    labelNroHab.Text = "Pernocte";
                                    tbNroHab.Text = "0";
                                    labelMensaje.Visible = false;
                                    dgvPromos.Visible = false;
                                }
                            }
                            panelPromos.Visible = true;
                            dgvPromos.Visible = true;
                            /*--- Modifico el dgv Promos ---*/
                            dgvPromos.Rows.Clear();                            
                            dgvPromos.Columns[1].HeaderText = " Pernocte ";                            
                            dgvPromos.Rows.Add(0,"No");
                            dgvPromos.Rows.Add(1,"Si");
                            /*-----------------------------------------------*/

                            break;
                                                    

                        case "leerTarjeta":
                            int nroHotel = tools.obtenerParametroInt("nroHotelCodBarras");
                            if (nroHotel.ToString() == tbNroHab.Text.Substring(0, 2))
                            {
                                socio = Socio.registrarYobtener(int.Parse(tbNroHab.Text.Substring(2)));
                                if (socio == null)
                                {
                                    labelMensaje.Text = "Error al registrar el Socio.";
                                    labelMensaje.Visible = true;
                                    return;
                                }
                                labelMensaje.Visible = false;
                                dgvOpcionesElegidas.Rows[3].Cells[1].Value = dgvOpcionesElegidas.Rows[3].Cells[1].Value.ToString() + " " + socio.nroSocio;
                                dgvOpcionesElegidas.Rows[4].Cells[1].Value = dgvOpcionesElegidas.Rows[4].Cells[1].Value.ToString() + socio.puntaje;
                                tbNroHab.Text = "0";
                                labelNroHab.Text = "¿Cambiar puntos?";
                                pasoAsignacion = "puntos";
                            }
                            else
                            {
                                labelMensaje.Text = "El numero ingresado no corresponde a ninguna tarjeta valida.";
                                labelMensaje.Visible = true;
                                return;
                            }

                            break;

                        case "puntos":
                            tbNroHab.Text = String.IsNullOrEmpty(tbNroHab.Text) ? "0" : tbNroHab.Text;
                            if (int.Parse(tbNroHab.Text) > socio.puntaje)
                            {
                                labelMensaje.Text = "El cliente no tiene esa cantidad de puntos.";
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;
                            puntosACambiar = int.Parse(tbNroHab.Text);
                            dgvOpcionesElegidas.Rows[4].Cells[1].Value = puntosStr + (socio.puntaje - puntosACambiar);
                            tbNroHab.Text = "0";
                            labelNroHab.Text = "Pernocte";
                            pasoAsignacion = "pernocte";
                            
                            /*--- Modifico el dgv Promos ---*/
                            dgvPromos.Rows.Clear();
                            dgvPromos.Columns[1].HeaderText = " Pernocte ";
                            dgvPromos.Rows.Add(0, "No");
                            dgvPromos.Rows.Add(1, "Si");
                            /*-----------------------------------------------*/
                            dgvPromos.Visible = true;
                            panelPromos.Visible = true;

                            break;

                        case "pernocte":

                            if (tbNroHab.Text != "1" && tbNroHab.Text != "0")
                            {
                                labelMensaje.Visible = true;
                                labelMensaje.Text = " 0 - No es pernocte\r\n 1 - Es pernocte";
                                return;
                            }
                            labelMensaje.Visible = false;
                            int altoFilaExtraMedioPagos;
                            DataSet ds = new DataSet();
                            pernocte = int.Parse(tbNroHab.Text);
                            dgvOpcionesElegidas.Rows[5].Cells[1].Value = pernocteString + (tbNroHab.Text == "1" ? " Si" : " No");

                            montoAPagar = Habitacion.calcularPrecioTurno(pernocte, this.desc.id, puntosACambiar, nroCategoria,out tarifaNoche,out descTotalHabitacion,out totExtra);

                            //decimal precioExtra = montoAPagar - (tarifaNoche == null ? 0 : tarifaNoche.precio);
                            if (montoAPagar == 0)
                            {
                                labelMensaje.Visible = true;
                                labelMensaje.Text = " No hay Tarifas cargadas para este horario y esta categoria ó el precio asignado es cero ";
                                return;
                            }
                            labelMensaje.Visible = true;
                            labelMensaje.Text = String.Format("{0:C}",montoAPagar) ;
                            labelMensaje.Font = new Font("Cooper Std", 38, FontStyle.Bold);
                            labelMensaje.BorderStyle = BorderStyle.FixedSingle;

                            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from mediosDePago", fPrincipal2.conn);
                            dataAdapter.Fill(ds);
                            dgvPromos.Rows.Clear();

                            tools.calcularAlturas(dgvPromos.Height - dgvPromos.ColumnHeadersHeight, ds.Tables[0].Rows.Count > tools.minCantFilas ? ds.Tables[0].Rows.Count : tools.minCantFilas, out altoFila, out altoFilaExtraMedioPagos);
                            dgvPromos.RowTemplate.Height = altoFila;

                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                dictMediosDePago.Add(int.Parse(dr[0].ToString()), dr[1].ToString());
                                dgvPromos.Rows.Add(dr[0].ToString(), dr[1].ToString());
                            }
                            // ----  Completando la tabla mediosPagos  ----//
                            tools.completarDG(dgvPromos, altoFilaExtraMedioPagos);
                            //---------------------------------------------------------------------------//
                            
                            tbNroHab.Text = "0";
                            dgvPromos.Visible = true;
                            dgvPromos.Columns[1].HeaderText = "Medios de Pago";
                            labelNroHab.Text = "Medio de Pago ";
                            pasoAsignacion = "medioPago";

                            break;

                        case "adelanto":
                                                       
                            decimal.TryParse(tbNroHab.Text.Replace('.', ','),out montoAdelantar);
                            if(montoAdelantar + puntosACambiar > montoAPagar)
                            {
                                labelMensaje.Text = "* El importe debe ser inferior o igual al total a pagar *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            labelMensaje.Visible = false;

                            panelPromos.Visible = true;
                            dgvOpcionesElegidas.Rows[7].Cells[1].Value = dgvOpcionesElegidas.Rows[7].Cells[1].Value + " " + String.Format("{0:C}", montoAdelantar);

                            labelNroHab.Text = "¿Confirmar?";
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
                            /*-----------------------------------------------*/
                            
                            tbNroHab.Visible = false;                            
                            
                            break;

                        case "medioPago":
                            medioPago = string.IsNullOrEmpty(tbNroHab.Text) ? 0 : int.Parse(tbNroHab.Text);
                            if (!dictMediosDePago.ContainsKey(medioPago))
                            {
                                labelMensaje.Text = "* El medio de Pago no existe *";
                                labelMensaje.Visible = true;
                                return;
                            }
                            dgvOpcionesElegidas.Rows[6].Cells[1].Value = dgvOpcionesElegidas.Rows[6].Cells[1].Value + " " + dictMediosDePago[medioPago];
                            
                            pasoAsignacion = "adelanto";
                            labelNroHab.Text = "Importe a Adelantar  $";
                            tbNroHab.Text = "0";

                            break;

                        case "confirmar":
                            if (Habitacion.Asignar((fPrincipal2)this.Owner, this.desc.id, nroHab, pernocte, nroCategoria, ((fPrincipal2)this.Owner).conserjeActual.usuario, socio.id, puntosACambiar,montoAPagar,tarifaNoche,descTotalHabitacion,totExtra))
                            {
                                if(montoAdelantar > 0)
                                    Habitacion.Adelanto((fPrincipal2)this.Owner, nroHab,montoAdelantar, medioPago);
                                if (socio.id != 0)
                                    socio.descontarPuntos(puntosACambiar);
                                
                                DetallesHabitacion detalle = Habitacion.obtenerDetalles(nroHab);
                                int minArestar;

                                if(detalle.duracion>=100)
                                 minArestar = tools.obtenerParametroInt("minFinTurnoMayor100");
                                else
                                 minArestar = tools.obtenerParametroInt("minFinTurnoMenor100");

                                Habitacion.agregarAlarma((fPrincipal2)this.Owner, nroHab,int.Parse(detalle.hasta.AddMinutes(-minArestar).ToString("HHmm")), 2);
                                LoggerProxy.Info(string.Format("Ejecuto Asignar Habitación - Nro.Hab:{0}, Categoria:{1}, Conserje:{2}.", nroHab, dictCategorias[nroCategoria], ((fPrincipal2)this.Owner).conserjeActual.nombre));
                                volverFormPrincipal();
                                
                            }
                            else
                            {
                                labelMensaje.Text = "No se puede Asignar la Habitacion, posiblemente falten definir tarifas para la categoria elegida.";
                                labelMensaje.Visible = true;
                            }
                            return;

                        default:
                            break;

                    }

                    tbNroHab.Select(0, tbNroHab.TextLength);
                    dgvPromos.ClearSelection();
                    //tbNroHab.SelectionStart = tbNroHab.TextLength;
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
                labelMensaje.Text = ex.Message;
                labelMensaje.Visible = true;
            }

        }

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where habilitada = 1 and nroHabitacion = " + tbNroHab.Text, fPrincipal2.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["estado"].ToString() != "D")
                {
                    tbNroHab.Text = "";
                    return "* La habitación no esta disponible *";
                }
            }
            else
            {
                tbNroHab.Text = "";
                return "* El número de habitación no existe *";
            }

            return String.Empty;
        }

        private string validarNroCategoria(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de Categoria *";
            if (!dictCategorias.ContainsKey(int.Parse(tbNroHab.Text)))
                return "* El número de categoria no existe *";

            return String.Empty;
        }

        private string validarNroHabitacionExistente(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal2.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                return "* El número de habitación no existe *";
            }

            return String.Empty;
        }

        private string validarPromocion(TextBox tbNroPromo)
        {
            if (tbNroPromo.Text == String.Empty)
                return "* Debe ingresar el número de promoción *";

            if (!DictDescuentos.ContainsKey(int.Parse(tbNroPromo.Text)))
                return "* La Promoción elegida no existe *";

            return String.Empty;
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'hotelDataSet2.OpcionesAsignarHabitacion' Puede moverla o quitarla según sea necesario.
            int altoFila, altoFilaExtraMedioPagos;            
            
            tools.calcularAlturas(dgvOpcionesElegidas.Height - dgvOpcionesElegidas.ColumnHeadersHeight, 8 , out altoFila, out altoFilaExtraMedioPagos);
            dgvOpcionesElegidas.RowTemplate.Height = altoFila;                        
            
            this.opcionesAsignarHabitacionTableAdapter.Fill(this.hotelDataSet2.OpcionesAsignarHabitacion);
            dgvOpcionesElegidas.ClearSelection();

            pernocteString = dgvOpcionesElegidas.Rows[5].Cells[1].Value.ToString();

        }

        private void labelTitulo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.DrawLine(new Pen(Color.BlueViolet, 1.5f), 0, g.ClipBounds.Height - 5, g.ClipBounds.Width, g.ClipBounds.Height - 5);
        }

        private void dgvPromos_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.IsLastVisibleRow)
            {
                if (pasoAsignacion != "confirmar")
                {
                    Graphics g = e.Graphics;
                    g.DrawLine(new Pen(Color.Gainsboro, 2f), nro.Width + 1, g.ClipBounds.Y, nro.Width + 1, g.ClipBounds.Height);
                }
            }
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }

    }
}
