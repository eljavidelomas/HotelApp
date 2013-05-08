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


    public partial class FormEstadoCaja : Form
    {        
        List<Aviso> lAvisos = new List<Aviso>();
        Dictionary<int, Aviso> dictAvisosSel = new Dictionary<int, Aviso>();
        Dictionary<int, Aviso> dictAvisos = new Dictionary<int, Aviso>();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public FormEstadoCaja()
        {
            InitializeComponent();
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
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    volverFormPrincipal();
                    return true;

                case Keys.Enter:
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void volverFormPrincipal()
        {
            this.Owner.Show();
            this.Owner.Focus();
            this.Hide();
            this.Close();
        }

        private void FormAsignarHab_Load(object sender, EventArgs e)
        {
            int altoFila,altoFilaExtra;
            decimal totEfectivo,totTarjeta;
            
            tools.calcularAlturas(dgvTurnos.Height - dgvTurnos.ColumnHeadersHeight, 4, out altoFila, out altoFilaExtra);
            dgvTurnos.RowTemplate.Height = altoFila;
            dgvCaja.RowTemplate.Height = altoFila;
            DataRow dr = TablaTurnos.obtenerDatosEstadoCaja();
            FormCierrePlanilla.obtenerMontosTotales(out totEfectivo, out totTarjeta);
            dgvTurnos.Rows.Add("Asignados: "+dr["ta"].ToString());
            dgvTurnos.Rows.Add("Cerrados: " + dr["tc"].ToString());
            dgvTurnos.Rows.Add("Total Cerrados en el dia: " + dr["ttc"].ToString());

            dgvCaja.Rows.Add("Total Efectivo: ".PadRight(18) + string.Format("{0:C}",totEfectivo).PadLeft(9));
            dgvCaja.Rows.Add("Total Tarjeta: ".PadRight(18) + string.Format("{0:C}", totTarjeta).PadLeft(9));
            dgvCaja.Rows.Add("Efectivo Inicial: ".PadRight(18) + string.Format("{0:C}", dr["ei"]).PadLeft(9));
            dgvTurnos.ClearSelection();
            dgvCaja.ClearSelection();
         
        }      
    }
}
