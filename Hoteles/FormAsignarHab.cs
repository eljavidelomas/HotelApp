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
        int socioId = 0;
        Socio socio = new Socio();
        int puntosACambiar = 0;
        Dictionary<int, Descuento> DictDescuentos;
        Descuento desc;


        public FormAsignarHab()
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
                string msj = validarNroHabitacionExistente(tbNroHab);
                if ( msj == string.Empty && nroHab == 0)
                {
                    Tarifa tarifa;
                    
                    decimal precioPernocte = Habitacion.calcularPrecioConPernocte(int.Parse(tbNroHab.Text), out tarifa);
                    if (precioPernocte == 0)
                    {
                        labelMensaje.Text = "No se puede calcular el Precio Pernocte, posiblemente falten asignar tarifas para algun horario.";
                        labelMensaje.Visible = true;
                        return true;
                    }
                    else
                    {
                        labelMensaje.Text = "Precio Con Pernocte = " + precioPernocte.ToString("C2",CultureInfo.CreateSpecificCulture("es-AR"));
                        labelMensaje.Visible = true;
                        return true;
                    }
                }
                labelMensaje.Text = msj;
                labelMensaje.Visible = true;
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
                        int nroPromo = 0;
                        int altoFila;
                        int altoFilaExtra;
                        labelMensaje.Visible = false;

                        nroHab = int.Parse(tbNroHab.Text);                        
                        DictDescuentos = new Dictionary<int, Descuento>();
                        dgvOpcionesElegidas.Rows[0].Cells[1].Value = dgvOpcionesElegidas.Rows[0].Cells[1].Value.ToString() + " " + nroHab;
                        List<Descuento> lDescuentos = Descuento.obtenerDescuentos(int.Parse(tbNroHab.Text));

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
                        dgvOpcionesElegidas.Rows[1].Cells[1].Value = dgvOpcionesElegidas.Rows[1].Cells[1].Value.ToString() + " " + DictDescuentos[nroPromoElegida].nombre;
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
                            if (this.desc.tarifaId != 0) // turno express
                            {
                                pasoAsignacion = "pernocte";
                                tbNroHab.Text = "0";
                                labelNroHab.Text = "Pernocte";
                                tbNroHab_KeyPress(sender, e);
                                return;
                            }
                            else if (desc.nombre.ToLower().Contains("socio"))// promo socios, pedir tarjeta
                            {
                                labelNroHab.Text = "Inserte Tarjeta";
                                dgvPromos.Visible = false;
                                tbNroHab.Text = "";
                                tbNroHab.Width += 50;
                                tbNroHab.MaxLength = 6;
                                pasoAsignacion = "leerTarjeta";

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

                        break;

                    case "leerTarjeta":

                        socio = Socio.registrarYobtener(int.Parse(tbNroHab.Text));
                        if (socio == null)
                        {
                            labelMensaje.Text = "Error al registrar el Socio.";
                            labelMensaje.Visible = true;
                            return;
                        }
                        dgvOpcionesElegidas.Rows[3].Cells[1].Value = dgvOpcionesElegidas.Rows[3].Cells[1].Value.ToString() + " " + socio.puntaje;
                        dgvOpcionesElegidas.Rows[2].Cells[1].Value = dgvOpcionesElegidas.Rows[2].Cells[1].Value.ToString() + " " + socio.nroSocio;
                        tbNroHab.Text = "0";
                        labelNroHab.Text = "¿Cambiar puntos?";
                        pasoAsignacion = "puntos";

                        break;

                    case "puntos":
                        tbNroHab.Text = String.IsNullOrEmpty(tbNroHab.Text) ? "0" : tbNroHab.Text;
                        if (int.Parse(tbNroHab.Text) > socio.puntaje)
                        {
                            labelMensaje.Text = "El cliente no tiene esa cantidad de puntos.";
                            labelMensaje.Visible = true;
                            return;
                        }
                        puntosACambiar = int.Parse(tbNroHab.Text);
                        dgvOpcionesElegidas.Rows[3].Cells[1].Value = "Puntos Act.: " + (socio.puntaje - puntosACambiar);
                        tbNroHab.Text = "0";
                        labelNroHab.Text = "Pernocte";
                        pasoAsignacion = "pernocte";
                        break;

                    case "pernocte":

                        if (tbNroHab.Text != "1" && tbNroHab.Text != "0")
                        {
                            labelMensaje.Visible = true;
                            labelMensaje.Text = " 0 - No es pernocte\r\n 1 - Es pernocte";
                            return;
                        }
                        labelMensaje.Visible = false;
                        pernocte = int.Parse(tbNroHab.Text);
                        dgvOpcionesElegidas.Rows[4].Cells[1].Value = dgvOpcionesElegidas.Rows[4].Cells[1].Value + (tbNroHab.Text=="1"?" Si":" No");

                        labelConf.Visible = true;
                        tbNroHab.Visible = false;
                        labelNroHab.Text = "¿ Confirma ?";
                        pasoAsignacion = "confirmar";
                       
                        break;

                    case "confirmar":
                        if (Habitacion.Asignar((fPrincipal)this.Owner, this.desc.id, nroHab, pernocte, ((fPrincipal)this.Owner).conserjeActual.usuario, socio.id, puntosACambiar))
                        {
                            if (socio.id != 0)
                                socio.descontarPuntos(puntosACambiar);
                            volverFormPrincipal();
                        }
                        else
                        {
                            labelMensaje.Text = "No se puede Asignar Pernocte, posiblemente falten asignar tarifas para algun horario.";
                            labelMensaje.Visible = true;                         
                        }                        
                        return;

                    default:
                        break;
                    
                }

                tbNroHab.Select(0, tbNroHab.TextLength);
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

        private string validarNroHabitacion(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal.conn);
            dataAdapter.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["estado"].ToString() != "D")
                    return "* La habitación no esta disponible *";
            }
            else
                return "* El número de habitación no existe *";

            return String.Empty;
        }

        private string validarNroHabitacionExistente(TextBox tbNroHab)
        {
            if (tbNroHab.Text == String.Empty)
                return "* Debe ingresar el número de habitación *";
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + tbNroHab.Text, fPrincipal.conn);
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
            this.opcionesAsignarHabitacionTableAdapter.Fill(this.hotelDataSet2.OpcionesAsignarHabitacion);
            dgvOpcionesElegidas.ClearSelection();
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
                Graphics g = e.Graphics;
                g.DrawLine(new Pen(Color.Gainsboro, 2f), nro.Width + 1, g.ClipBounds.Y, nro.Width + 1, g.ClipBounds.Height);
            }
        }

        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
            if (labelMensaje.Visible == false)
                labelMensaje.Size = new Size(1, 1);
        }


        //Label detallePromo = new Label();
        //detallePromo.AutoSize = true;
        //detallePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //detallePromo.Size = new System.Drawing.Size(336, 29);
        //detallePromo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //detallePromo.Text = "Opc.0 - Sin Promoción";
        //flpPromos.Controls.Add(detallePromo);
        //tiposDescuentosId = new List<int>();
        //tiposDescuentosId.Add(0);
        //foreach (TipoDescuento tipodesc in TipoDescuento.obtenerTiposDescuento(nroHab))
        //{
        //    detallePromo = new Label();
        //    detallePromo.AutoSize = true;
        //    detallePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    detallePromo.Size = new System.Drawing.Size(336, 29);
        //    detallePromo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //    detallePromo.Text = "Opc." + tipodesc.tipoDescuentoId + " - " + tipodesc.nombre;
        //    tiposDescuentosId.Add(tipodesc.tipoDescuentoId);
        //    //flpPromos.Controls.Add(detallePromo);

        //}                    
        //tbIngTipoPromo.Focus();

        //private void tbIngTipoPromo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((char)Keys.Enter == e.KeyChar)
        //    {
        //        e.Handled = true;

        //        string msj = validarTipoPromocion(tbIngTipoPromo);
        //        if (msj != string.Empty)
        //        {
        //            labelMensaje.Visible = true;
        //            labelMensaje.Text = msj;
        //            return;
        //        }
        //        if (int.Parse(tbIngTipoPromo.Text) != 0)
        //        {
        //            if (tbIngTipoPromo.Text == "3")
        //            {
        //                //Aca viene la logica para los socios
        //                socioId = 12345678;
        //                pasoAsignacion = "pernocte";
        //                tbNroHab.Text = "0";
        //                tbNroHab_KeyPress(sender, e);
        //                return;
        //            }
        //            labelMensaje.Visible = false;
        //            labelIngPromo.Visible = false;
        //            tbIngTipoPromo.Visible = false;
        //            panelPromos.Controls.Clear();
        //            Label lPromo = labelPromo;
        //            lPromo.Text = "Promociones Vigentes";
        //            panelPromos.Controls.Add(lPromo);
        //            foreach (Descuento desc in Descuento.obtenerDescuentoPorTipo(int.Parse(tbIngTipoPromo.Text)))
        //            {
        //                Label detallePromo = new Label();
        //                detallePromo.AutoSize = true;
        //                detallePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //                detallePromo.Size = new System.Drawing.Size(336, 29);
        //                detallePromo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //                detallePromo.Text = "Opc." + desc.id + " - " + desc.nombre + "-" + desc.descripcion;
        //                panelPromos.Controls.Add(detallePromo);

        //            }

        //            labelIngPromo.Text = "Ingresar Promo vigente";
        //            labelIngPromo.Visible = true;
        //            tbIngPromo.Location = tbIngTipoPromo.Location;
        //            tbIngPromo.Visible = true;
        //            tbIngPromo.Focus();
        //        }
        //        else
        //        {
        //            pasoAsignacion = "pernocte";
        //            labelMensaje.Visible = false;
        //            labelIngPromo.Visible = false;
        //            tbIngTipoPromo.Visible = false;
        //            panelPromos.Visible = false;


        //            // agregar logica acá para ver si le muestro o no pernocte.
        //            labelNroHab.Text = "Es Pernocte ";
        //            labelNroHab.Visible = true;
        //            tbNroHab.Visible = true;

        //            tbNroHab.Text = "0";
        //            tbNroHab.Focus();
        //            tbNroHab.SelectionStart = tbNroHab.TextLength;

        //        }
        //    }
        //    if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //    }

        //}

        //private string validarTipoPromocion(TextBox tbIngTipoPromo)
        //{
        //    if (tbIngTipoPromo.Text == String.Empty)
        //        return "* Debe ingresar el número de promoción *";

        //    if (!tiposDescuentosId.Contains(int.Parse(tbIngTipoPromo.Text)))            
        //        return "* El tipo de Promoción elegido es incorrecto *";

        //    return String.Empty;
        //}

        //private void labelTitulo_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    //g.DrawLine(new Pen(Color.BlueViolet, 1.5f), 0, g.ClipBounds.Height - 5, g.ClipBounds.Width, g.ClipBounds.Height - 5);
        //}

        //private void tbIngPromo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if ((char)Keys.Enter == e.KeyChar)
        //    {
        //        e.Handled = true;

        //        string msj = validarPromocion(tbIngTipoPromo, tbIngPromo);
        //        if (msj != string.Empty)
        //        {
        //            labelMensaje.Visible = true;
        //            labelMensaje.Text = msj;
        //            return;
        //        }
        //        if (int.Parse(tbIngTipoPromo.Text) != 0)
        //        {
        //            descuentoId = int.Parse(tbIngPromo.Text);
        //            pasoAsignacion = "pernocte";

        //            if (tbIngTipoPromo.Text == "4") // Si es turno Express no pregunto pro pernocte.
        //            {
        //                tbNroHab.Text = "0";// pernocte no
        //                tbNroHab_KeyPress(sender, e);
        //                return;

        //            }


        //            labelMensaje.Visible = false;
        //            labelIngPromo.Visible = false;
        //            tbIngTipoPromo.Visible = false;
        //            panelPromos.Visible = false;


        //            labelNroHab.Text = "Es Pernocte ";
        //            labelNroHab.Visible = true;
        //            tbNroHab.Visible = true;

        //            tbNroHab.Text = "0";
        //            tbNroHab.Focus();
        //            tbNroHab.SelectionStart = tbNroHab.TextLength;

        //        }
        //    }
        //    if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
        //    {
        //        e.Handled = true;
        //    }

        //}




    }
}
