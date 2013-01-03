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
                this.Owner.Show();
                this.Owner.Focus();
                this.Hide();
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void tbNroHab_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                e.Handled = true;

                string msj = validarNroHabitacion(tbNroHab);
                if (msj != string.Empty)
                {
                    labelMensaje.Visible = true;
                    labelMensaje.Width = labelMensaje.Parent.Width;
                    labelMensaje.Text = msj;
                    return;
                }
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
                foreach (TipoDescuento tipodesc in TipoDescuento.obtenerTiposDescuento())
                {
                    detallePromo = new Label();
                    detallePromo.AutoSize = true;
                    detallePromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    detallePromo.Size = new System.Drawing.Size(336, 29);
                    detallePromo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    detallePromo.Text = "Opc."+tipodesc.tipoDescuentoId+" - " + tipodesc.nombre;
                    flpPromos.Controls.Add(detallePromo);

                }
                flpPromos.Visible = true;
                panelOpElegidas.Visible = true;
                tbIngPromo.Focus();

                return;
            }
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar!= (char) Keys.Back)
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

        private void tbIngPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                e.Handled = true;

                string msj = validarTipoPromocion(tbIngPromo);
                if (msj != string.Empty)
                {
                    labelMensaje.Visible = true;
                    labelMensaje.Text = msj;
                    return;
                }
                labelMensaje.Visible = false;
                labelIngPromo.Visible = false;
                tbIngPromo.Visible = false;
                flpPromos.Controls.Clear();
                Label lPromo = labelPromo;
                lPromo.Text = "Promociones Vigentes";
                flpPromos.Controls.Add(lPromo);
                //flpPromos.Visible = false;

            }

        }

        private string validarTipoPromocion(TextBox tbIngPromo)
        {
            if (tbIngPromo.Text != string.Empty && int.Parse(tbIngPromo.Text) != 0)
            {
                DataSet ds = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from tipoDescuentos where tipoDescuentoId = " + tbIngPromo.Text, fPrincipal.conn);
                dataAdapter.Fill(ds);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return "* El tipo de Promoción elegido es incorrecto *";
                }
            }
            if(tbIngPromo.Text == String.Empty)
                return "* Debe ingresar el número de promoción *";

            return String.Empty;
        }

        private void labelTitulo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(new Pen(Color.BlueViolet, 1.5f), 0, g.ClipBounds.Height - 5, g.ClipBounds.Width, g.ClipBounds.Height - 5);
        }

    }
}
