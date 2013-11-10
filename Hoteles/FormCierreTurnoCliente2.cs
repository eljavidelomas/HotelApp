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
using System.IO;
using Hoteles.Properties;

namespace Hoteles
{


    public partial class FormCierreTurnoCliente2 : Form
    {
        FormCierreTurno form;
        string pasoAsignacion = "confirmar";
        DetallesHabitacion detallesHab = new DetallesHabitacion();
        public FileStream stream;
        public BinaryWriter writer;
        public byte[] fila1;
        public byte[] filaFinal;


        public FormCierreTurnoCliente2()
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
                    if (fPrincipal2.dictSonidoDesocupado.ContainsKey(form.nroHab))
                        fPrincipal2.dictSonidoDesocupado[form.nroHab] = false;

                    Habitacion.Cierre((fPrincipal2)form.Owner, form.nroHab, form.impDescArt, form.descuento, form.medioPago, form.detallesHab.impHabitacion);

                    try
                    {
                        if (detallesHab.nroSocio != "")
                            Socio.asignarPuntos(detallesHab.impAdelantado + form.detallesHab.impHabitacion, detallesHab.nroSocio);

                        Aviso av = ((fPrincipal2)form.Owner).alarmas.Find(x => x.nroHab == form.nroHab);
                        if (av != null)
                        {
                            ((fPrincipal2)form.Owner).alarmas.Remove(av);
                            Alarma.desactivar();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        LoggerProxy.Error("CierreTurnoCliente - asignarPuntos - " + ex.Message);
                    }

                    LoggerProxy.Info(string.Format("Ejecuto Cierre de Turno - Hab:{0}", form.nroHab));
                    volverFormPrincipal();

                    return true;
                }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void volverFormPrincipal()
        {
            LoggerProxy.Info("Salir Cierre Turno Cliente");

            string fileName = "CERRAR.HAB";
            stream = new FileStream(Settings.Default.pathHoteleria + fileName, FileMode.Create, FileAccess.Write);
            writer = new BinaryWriter(stream);
            writer.Close();
            stream.Close();

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
            form = (FormCierreTurno)this.Owner;
            lblMonto.Text = form.detallesHab.impHabitacion.ToString("C");
            lblNroHab.Text = form.nroHab.ToString();
            cargarDetallesTurno(form.nroHab);

        }

        private void CargarFila1()
        {
            string fileName = "CERRAR.HAB";
            stream = new FileStream(Settings.Default.pathHoteleria + fileName, FileMode.Create, FileAccess.Write);
            writer = new BinaryWriter(stream);

            Int16 hab = Int16.Parse(form.nroHab.ToString());
            Double dsc = Double.Parse((detallesHab.descuentoDinero + int.Parse(detallesHab.ptosCambiados) + detallesHab.descArticulos + form.descuento).ToString());
            Double reg = 0;//recargo
            Single can = 0;
            Double pre = Double.Parse((detallesHab.impHabitacion + detallesHab.impAdelantado + detallesHab.descuentoDinero - detallesHab.impArticulos + detallesHab.descArticulos + int.Parse(detallesHab.ptosCambiados)).ToString());

            byte[] r1 = obtenerBytes(hab);//nro hab
            byte[] r2 = obtenerBytes(dsc);//descuento
            byte[] r3 = obtenerBytes(reg);//Recargo            
            byte[] r4 = Encoding.UTF8.GetBytes(detallesHab.desde.ToString("HH:mm"));//desde
            byte[] r5 = Encoding.UTF8.GetBytes(detallesHab.hasta.ToString("HH:mm"));//hasta            
            byte[] r6 = Encoding.UTF8.GetBytes("".PadRight(4));//cantidad del articulo            
            byte[] r7 = Encoding.UTF8.GetBytes(" Habitacion".PadRight(20));//descr artiiculo
            byte[] r8 = obtenerBytes(can);// 4 bytes cantidad de art
            byte[] r9 = obtenerBytes(pre);//precio total por articulo
            byte[] r10 = new byte[32];// relleno

            byte[] salida = Combine(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            //byte[] s = Combine(salida, new byte[96]);
            for (int i = 0; i < salida.Length; i++)
            {
                writer.Write(salida[i]);
            }
        }

        private void CargarFilaDetalle(string precio, string descripcion, int cantidad)
        {
            Int16 hab = Int16.Parse(form.nroHab.ToString());
            Double dsc = Double.Parse((detallesHab.descuentoDinero + int.Parse(detallesHab.ptosCambiados) + detallesHab.descArticulos + form.descuento).ToString());
            Double reg = 0;//recargo
            Single can = cantidad;
            Double pre = Double.Parse(precio);

            byte[] r1 = obtenerBytes(hab);//nro hab
            byte[] r2 = obtenerBytes(dsc);//descuento
            byte[] r3 = obtenerBytes(reg);//Recargo            
            byte[] r4 = Encoding.UTF8.GetBytes(detallesHab.desde.ToString("".PadRight(5)));//desde
            byte[] r5 = Encoding.UTF8.GetBytes(detallesHab.hasta.ToString("".PadRight(5)));//hasta           
            byte[] r6 = Encoding.UTF8.GetBytes((" " + cantidad.ToString()).PadRight(4));//cantidad del articulo            
            byte[] r7 = Encoding.UTF8.GetBytes(descripcion.PadRight(20));//descr artiiculo
            byte[] r8 = obtenerBytes(can);// 4 bytes cantidad de art
            byte[] r9 = obtenerBytes(pre);//precio total por articulo
            byte[] r10 = new byte[32];// relleno

            byte[] salida = Combine(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);
            for (int i = 0; i < salida.Length; i++)
            {
                writer.Write(salida[i]);
            }
        }

        private void cargarDetallesTurno(int nroHab)
        {
            detallesHab = Habitacion.obtenerDetalles(nroHab);

            if (detallesHab.impHabitacion < 0)
                detallesHab.impHabitacion = 0;
            string detHabitacion = "HABITACIÓN  Desde: " + detallesHab.desde.ToString("HH:mm") +
                " Hasta: " + detallesHab.hasta.ToString("HH:mm");
            dgvDetallesTurno.Rows.Add("", detHabitacion, string.Format("{0:C}", (detallesHab.impHabitacion + detallesHab.impAdelantado + detallesHab.descuentoDinero - detallesHab.impArticulos + detallesHab.descArticulos + int.Parse(detallesHab.ptosCambiados))));
            
            if ((decimal)form.drDetalles[4] > 0)
                dgvDetallesTurno.Rows.Add("", "Adelanto Efectivo", "- " + (decimal.Parse(form.drDetalles[4].ToString()).ToString("C")));
            if ((decimal)form.drDetalles[5] > 0)
                dgvDetallesTurno.Rows.Add("", "Adelanto Tarjeta", "- " + (decimal.Parse(form.drDetalles[5].ToString()).ToString("C")));
            if (detallesHab.descuentoDinero + int.Parse(detallesHab.ptosCambiados) > 0)
                dgvDetallesTurno.Rows.Add("", "Descuento Habitación", "- " + (detallesHab.descuentoDinero + int.Parse(detallesHab.ptosCambiados)).ToString("C"));

            GenerarArchivoPantalla2();

            foreach (DataRow dr in Articulo.obtenerConsumos(nroHab).Rows)
            {
                dgvDetallesTurno.Rows.Add(dr[1].ToString(), dr[2].ToString(), String.Format("{0:C}", decimal.Parse(dr[3].ToString())));
                if (tools.obtenerParametroInt("mostrarVisualEXE") == 1)
                    CargarFilaDetalle(decimal.Parse(dr[3].ToString()).ToString(), dr[2].ToString(), int.Parse(dr[1].ToString()));
            }

            if (tools.obtenerParametroInt("mostrarVisualEXE") == 1)
                CerrarArchivoPantalla2();
            //            dgvDetallesTurno.Rows.Add("", "Total Articulos", detallesHab.impArticulos.ToString("C"));

            if(detallesHab.descArticulos>0)
                dgvDetallesTurno.Rows.Add("", "Descuento por Artículos", "- " + detallesHab.descArticulos.ToString("C"));
            if(form.descuento>0)
                dgvDetallesTurno.Rows.Add("", "Descuento Al Cierre", "- " + form.descuento.ToString("C"));

            lHoraEnt.Text = detallesHab.desde.ToString("HH:mm");
            lHoraSal.Text = DateTime.Now.ToString("HH:mm");
            if (dgvDetallesTurno.Rows.Count < 15)
                dgvDetallesTurno.ClearSelection();

        }

        private void CerrarArchivoPantalla2()
        {
            CargarFilaUltima();
            writer.Close();
            stream.Close();
        }

        private void CargarFilaUltima()
        {

            Int16 hab = 0;
            Double dsc = Double.Parse(form.detallesHab.impHabitacion.ToString());
            Double reg = 0;//recargo
            Single can = 0;
            Double pre = 0;

            byte[] r1 = obtenerBytes(hab);//nro hab
            byte[] r2 = obtenerBytes(dsc);//descuento
            byte[] r3 = obtenerBytes(reg);//Recargo            
            byte[] r4 = Encoding.UTF8.GetBytes(detallesHab.desde.ToString("".PadRight(5)));//desde
            byte[] r5 = Encoding.UTF8.GetBytes(detallesHab.hasta.ToString("".PadRight(5)));//hasta            
            byte[] r6 = Encoding.UTF8.GetBytes("".PadRight(4));//cantidad del articulo            
            byte[] r7 = Encoding.UTF8.GetBytes("".PadRight(20));//descr artiiculo
            byte[] r8 = obtenerBytes(can);// 4 bytes cantidad de art
            byte[] r9 = obtenerBytes(pre);//precio total por articulo
            byte[] r10 = new byte[32];// relleno

            byte[] salida = Combine(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10);

            //byte[] s = Combine(salida, new byte[96]);
            for (int i = 0; i < salida.Length; i++)
            {
                writer.Write(salida[i]);
            }
        }

        private void GenerarArchivoPantalla2()
        {
            if (tools.obtenerParametroInt("mostrarVisualEXE") == 1)
                CargarFila1();
        }

        byte[] obtenerBytes(Object obj)
        {
            byte[] intBytes;
            switch (obj.GetType().Name)
            {

                case "Single":
                    intBytes = BitConverter.GetBytes((Single)obj);
                    break;
                case "Int16":
                    intBytes = BitConverter.GetBytes((Int16)obj);
                    break;
                case "Double":
                    intBytes = BitConverter.GetBytes((Double)obj);
                    break;
                default:
                    intBytes = BitConverter.GetBytes(true);
                    break;
            }
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);

            return intBytes;
        }

        public static byte[] Combine(params byte[][] arrays)
        {
            byte[] ret = new byte[arrays.Sum(x => x.Length)];
            int offset = 0;
            foreach (byte[] data in arrays)
            {
                Buffer.BlockCopy(data, 0, ret, offset, data.Length);
                offset += data.Length;
            }
            return ret;
        }
        private void labelMensaje_Layout(object sender, LayoutEventArgs e)
        {
           
        }
    }
}
