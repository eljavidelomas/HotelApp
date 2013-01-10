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

namespace Hoteles
{
    public partial class FormAsignarHab : Form
    {
        string pasoAsignacion;
        int descuentoId;
        int nroHab;
        int socioId = 0;
        List<int> tiposDescuentosId;

        public FormAsignarHab()
        {
            InitializeComponent();
            tbNroHab.Focus();
            GoFullscreen(true);
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
            if ((char)Keys.Enter == e.KeyChar)
            {
                e.Handled = true;

                if (pasoAsignacion == "pernocte")
                {
                    if (tbNroHab.Text != "1" && tbNroHab.Text != "0")
                    {
                        labelMensaje.Visible = true;
                        labelMensaje.Width = labelMensaje.Parent.Width;
                        labelMensaje.Text = "* Debe indicar 0 si no es pernocte , o 1 en caso de serlo *";
                        return;
                    }

                    Habitacion.Asignar((fPrincipal)this.Owner, descuentoId, nroHab, int.Parse(tbNroHab.Text), ((fPrincipal)this.Owner).conserjeActual.usuario, socioId);
                    volverFormPrincipal();
                }

                else
                {
                    string msj = validarNroHabitacion(tbNroHab);
                    if (msj != string.Empty)
                    {
                        labelMensaje.Visible = true;
                        labelMensaje.Width = labelMensaje.Parent.Width;
                        labelMensaje.Text = msj;
                        return;
                    }
                    nroHab = int.Parse(tbNroHab.Text);
                    labelMensaje.Visible = false;
                    labelTitulo.Text = labelTitulo.Text + " - " + tbNroHab.Text;
                    tbNroHab.Visible = false;
                    labelNroHab.Visible = false;



                    Label detallePromo = new Label();
                    detallePromo.AutoSize = true;
                    detallePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    detallePromo.Size = new System.Drawing.Size(336, 29);
                    detallePromo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    detallePromo.Text = "Opc.0 - Sin Promoción";
                    flpPromos.Controls.Add(detallePromo);
                    tiposDescuentosId = new List<int>();
                    tiposDescuentosId.Add(0);
                    foreach (TipoDescuento tipodesc in TipoDescuento.obtenerTiposDescuento(nroHab))
                    {
                        detallePromo = new Label();
                        detallePromo.AutoSize = true;
                        detallePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        detallePromo.Size = new System.Drawing.Size(336, 29);
                        detallePromo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        detallePromo.Text = "Opc." + tipodesc.tipoDescuentoId + " - " + tipodesc.nombre;
                        tiposDescuentosId.Add(tipodesc.tipoDescuentoId);
                        flpPromos.Controls.Add(detallePromo);

                    }
                    flpPromos.Visible = true;
                    panelOpElegidas.Visible = true;
                    tbIngTipoPromo.Focus();
                }

                return;
            }
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
            {
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

        private void tbIngTipoPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                e.Handled = true;

                string msj = validarTipoPromocion(tbIngTipoPromo);
                if (msj != string.Empty)
                {
                    labelMensaje.Visible = true;
                    labelMensaje.Text = msj;
                    return;
                }
                if (int.Parse(tbIngTipoPromo.Text) != 0)
                {
                    if (tbIngTipoPromo.Text == "3")
                    {
                        //Aca viene la logica para los socios
                        socioId = 12345678;
                        pasoAsignacion = "pernocte";
                        tbNroHab.Text = "0";
                        tbNroHab_KeyPress(sender, e);
                        return;
                    }
                    labelMensaje.Visible = false;
                    labelIngPromo.Visible = false;
                    tbIngTipoPromo.Visible = false;
                    flpPromos.Controls.Clear();
                    Label lPromo = labelPromo;
                    lPromo.Text = "Promociones Vigentes";
                    flpPromos.Controls.Add(lPromo);
                    foreach (Descuento desc in Descuento.obtenerDescuentoPorTipo(int.Parse(tbIngTipoPromo.Text)))
                    {
                        Label detallePromo = new Label();
                        detallePromo.AutoSize = true;
                        detallePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        detallePromo.Size = new System.Drawing.Size(336, 29);
                        detallePromo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        detallePromo.Text = "Opc." + desc.id + " - " + desc.nombre + "-" + desc.descripcion;
                        flpPromos.Controls.Add(detallePromo);

                    }

                    labelIngPromo.Text = "Ingresar Promo vigente";
                    labelIngPromo.Visible = true;
                    tbIngPromo.Location = tbIngTipoPromo.Location;
                    tbIngPromo.Visible = true;
                    tbIngPromo.Focus();
                }
                else
                {
                    pasoAsignacion = "pernocte";
                    labelMensaje.Visible = false;
                    labelIngPromo.Visible = false;
                    tbIngTipoPromo.Visible = false;
                    flpPromos.Visible = false;
                    panelOpElegidas.Visible = false;

                    labelNroHab.Text = "Es Pernocte ";
                    labelNroHab.Visible = true;
                    tbNroHab.Visible = true;

                    tbNroHab.Text = "0";
                    tbNroHab.Focus();
                    tbNroHab.SelectionStart = tbNroHab.TextLength;

                }
            }
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

        }

        private string validarTipoPromocion(TextBox tbIngTipoPromo)
        {
            if (tbIngTipoPromo.Text == String.Empty)
                return "* Debe ingresar el número de promoción *";

            if (!tiposDescuentosId.Contains(int.Parse(tbIngTipoPromo.Text)))            
                return "* El tipo de Promoción elegido es incorrecto *";
            
            return String.Empty;
        }

        private void labelTitulo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Color.BlueViolet, 1.5f), 0, g.ClipBounds.Height - 5, g.ClipBounds.Width, g.ClipBounds.Height - 5);
        }

        private void tbIngPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                e.Handled = true;

                string msj = validarPromocion(tbIngTipoPromo, tbIngPromo);
                if (msj != string.Empty)
                {
                    labelMensaje.Visible = true;
                    labelMensaje.Text = msj;
                    return;
                }
                if (int.Parse(tbIngTipoPromo.Text) != 0)
                {
                    descuentoId = int.Parse(tbIngPromo.Text);
                    pasoAsignacion = "pernocte";

                    if (tbIngTipoPromo.Text == "4") // Si es turno Express no pregunto pro pernocte.
                    {
                        tbNroHab.Text = "0";// pernocte no
                        tbNroHab_KeyPress(sender, e);
                        return;

                    }


                    labelMensaje.Visible = false;
                    labelIngPromo.Visible = false;
                    tbIngTipoPromo.Visible = false;
                    flpPromos.Visible = false;
                    panelOpElegidas.Visible = false;

                    labelNroHab.Text = "Es Pernocte ";
                    labelNroHab.Visible = true;
                    tbNroHab.Visible = true;

                    tbNroHab.Text = "0";
                    tbNroHab.Focus();
                    tbNroHab.SelectionStart = tbNroHab.TextLength;

                }
            }
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

        }

        private string validarPromocion(TextBox tbIngPromo, TextBox tbIngPromo2)
        {
            if (tbIngPromo2.Text == String.Empty)
                return "* Debe ingresar el número de promoción *";

            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select count(*) from descuentos where tipoDescuento = " + tbIngPromo.Text + " and id = " + tbIngPromo2.Text, fPrincipal.conn);
            dataAdapter.Fill(ds);
            if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) == 0)
            {
                return "* La Promoción elegida no existe *";
            }



            return String.Empty;
        }

    }
}
