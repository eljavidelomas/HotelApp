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


    public partial class FormCierreTurnoCliente : Form
    {        
        FormCierreTurno form;
        string pasoAsignacion = "confirmar";
        DetallesHabitacion detallesHab = new DetallesHabitacion();

        Dictionary<int, string> dictMediosDePago = new Dictionary<int, string>();       

        public FormCierreTurnoCliente()
        {
            InitializeComponent();
            GoFullscreen(true);
            LoggerProxy.Info("Ingreso Cierre Turno al Cliente");            
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
                {                    
                    Habitacion.Cierre((fPrincipal2)form.Owner, form.nroHab, form.impDescArt, form.descuento, form.medioPago,form.detallesHab.impHabitacion);
                    //((fPrincipal2)form.Owner).borrarPB_parpadeo(form.nroHab);

                    try
                    {
                        if (detallesHab.nroSocio != "")
                            Socio.asignarPuntos(detallesHab.impAdelantado + form.detallesHab.impHabitacion, detallesHab.nroSocio);
                    }
                    catch(Exception ex)
                    {
                        LoggerProxy.Error("CierreTurnoCliente - asignarPuntos - " + ex.Message);
                    }

                    LoggerProxy.Info(string.Format("Ejecuto Cierre de Turno - Hab:{0}",form.nroHab));
                    volverFormPrincipal();
                                                
                    return true;
                }
                    

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void volverFormPrincipal()
        {
            LoggerProxy.Info("Salir Cierre Turno Cliente");
            this.Owner.Owner.Show();
            this.Owner.Owner.Focus();
            this.Owner.Close();
            this.Hide();
            this.Close();
        }

        private void tbNroHab_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
        
        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            form = (FormCierreTurno) this.Owner;
            lblMonto.Text = form.detallesHab.impHabitacion.ToString("C");
            lblNroHab.Text = form.nroHab.ToString();
            cargarDetallesTurno(form.nroHab);            
        }

        private void cargarDetallesTurno(int nroHab)
        {
            detallesHab = Habitacion.obtenerDetalles(nroHab);
            string detHabitacion = "HABITACIÓN  Desde: " + detallesHab.desde.ToString("HH:mm") +
                " Hasta: " + detallesHab.hasta.ToString("HH:mm");
            dgvDetallesTurno.Rows.Add("", detHabitacion, string.Format("{0:C}",(detallesHab.impHabitacion + detallesHab.impAdelantado + detallesHab.descuentoDinero - detallesHab.impArticulos + detallesHab.descArticulos) ));
            dgvDetallesTurno.Rows.Add("", "Descuento Habitación", "- " + (detallesHab.descuentoDinero + int.Parse(detallesHab.ptosCambiados)).ToString("C"));


            foreach (DataRow dr in Articulo.obtenerConsumos(nroHab).Rows)
            {
                dgvDetallesTurno.Rows.Add(dr[1].ToString(), dr[2].ToString(), String.Format("{0:C}", decimal.Parse(dr[3].ToString())));
            }

//            dgvDetallesTurno.Rows.Add("", "Total Articulos", detallesHab.impArticulos.ToString("C"));
            dgvDetallesTurno.Rows.Add("", "Descuento por Artículos", "- " + detallesHab.descArticulos.ToString("C"));
            dgvDetallesTurno.Rows.Add("", "Descuento Al Cierre", "- " + form.descuento.ToString("C"));
            lHora.Text = DateTime.Now.ToString("HH:mm");
            if (dgvDetallesTurno.Rows.Count < 15)
                dgvDetallesTurno.ClearSelection();

        }

        private void labelTitulo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;            
        }     
    }
}
