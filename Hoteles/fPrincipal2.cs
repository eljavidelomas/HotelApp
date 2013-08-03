using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hoteles.Entities;
using System.Threading;
using System.Data.SqlClient;
using Hoteles.Properties;
using System.Collections;

namespace Hoteles
{
    public partial class fPrincipal2 : Form
    {
        static int contador = 0;
        public static object locker = new object();
        public static Mutex mut = new Mutex();
        public static int maxFilas;
        public static int cantHab;
        public float tamFuente;
        public static SqlConnection conn = new SqlConnection(Settings.Default.hotelConnectionString);
        public Conserje conserjeActual;
        public List<Aviso> alarmas = new List<Aviso>();
        static public Dictionary<int, PictureBox> dicAlarmasSonando = new Dictionary<int, PictureBox>();
        static public Dictionary<int, itemDicParpadeo> dictHabParpadeando = new Dictionary<int, itemDicParpadeo>();
        private Thread thActualizarHora;
        private Thread thControlarTarifa;
        private Thread thControlarParpadeo;

        public Dictionary<int, int> estadoHabitaciones = new Dictionary<int, int>();


        public fPrincipal2()
        {
            initConnection();

            DataTable dt = tools.listadoTurnos();
            maxFilas = (int)Math.Ceiling(dt.Rows.Count * 0.5);
            cantHab = dt.Rows.Count;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            InitializeComponent();
            GoFullscreen(true);

            for (int i = 1; i < 199; i++)
            {
                estadoHabitaciones.Add(i, 0);
            }
            estadoHabitaciones[101] = 1;
            estadoHabitaciones[104] = 1;
            estadoHabitaciones[105] = 1;
            estadoHabitaciones[106] = 1;

            thActualizarHora = new Thread(ActualizarLaHora);
            thActualizarHora.Start();
        }



        public void initConnection()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Error de conexión con la base de datos - " + ex.Message + "-" + ex.StackTrace);
                throw ex;
            }
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
            try
            {
                if (conserjeActual == null)
                    return base.ProcessCmdKey(ref msg, keyData);

                if (GestorTeclado.ProcesarTecla(keyData, this))
                    return true;
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                LoggerProxy.Error("fPrincipal - ProcessCmdKey  = " + ex.Message);
                return base.ProcessCmdKey(ref msg, keyData);
            }          
        }

        private void fPrincipal2_Load(object sender, EventArgs e)
        {

            #region cargarListaTurnos

            int altoFila;
            int altoFilaExtra;
            tools.calcularAlturas(dataGridView1.Height - dataGridView1.ColumnHeadersHeight, maxFilas, out altoFila, out altoFilaExtra);
            dataGridView1.RowTemplate.Height = altoFila;
            dataGridView2.RowTemplate.Height = altoFila;
            dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight + altoFilaExtra;
            dataGridView2.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight;
            tamFuente = 12f + (3.6f - (0.1f * cantHab));
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", tamFuente, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView2.DefaultCellStyle.Font = dataGridView1.DefaultCellStyle.Font;
            tools.actualizarListadoTurnos(dataGridView1, dataGridView2);

            #endregion

            #region Recuperar Estado Habitaciones

            recuperarEstadosHabitaciones();

            #endregion
            
            #region CargarConserje

            conserjeActual = Conserje.obtenerConserjeActual();
            if (conserjeActual == null)
            {
                textUsuario.Visible = true;
                labelClave.Visible = true;
                textClave.Visible = true;
                textUsuario.Focus();
            }
            else
                labelConserje.Text = "Conserje:" + conserjeActual.nombre;

            #endregion

            #region ActualizadorTarifaHabitacion

            thControlarTarifa = new Thread(ControlarTarifaHabitacion);
            thControlarTarifa.Start();

            #endregion

            thControlarParpadeo = new Thread(timerParpadeo2);
            thControlarParpadeo.Start();            
        }

        delegate void actualizarRelojCallback();

        delegate void timerParpadeo2Callback();

        private void actualizarReloj()
        {
            try
            {
                if (dataGridView1.InvokeRequired)
                {
                    actualizarRelojCallback d = new actualizarRelojCallback(actualizarReloj);
                    this.Invoke(d);
                }
                else
                {
                    labelHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
                    labelFecha.Text = String.Format("{0:ddd}", DateTime.Now).ToUpper() + " " + DateTime.Now.ToString("dd / MM / yyyy");
                }
            }
            catch
            {
                Thread.CurrentThread.Interrupt();
            }
        }

        private void recuperarEstadosHabitaciones()
        {
            List<DataGridView> datagrids = new List<DataGridView>();
            datagrids.Add(dataGridView1);
            datagrids.Add(dataGridView2);
            foreach (DataGridView dg in datagrids)
                foreach (DataGridViewRow dr in dg.Rows)
                {
                    if (dr.Cells[8].Value.ToString() == "A" || dr.Cells[8].Value.ToString() == "O")
                    {
                        int nroHabitacion = Convert.ToInt32(dr.Cells[0].Value);
                        DetallesHabitacion tur = null;
                        Tarifa tar = null;

                    inicio:

                        if (Convert.ToDateTime(dr.Cells[9].Value) <= DateTime.Now) // Columna Hasta en formato DateTime
                        {
                            if (tur == null)
                            {
                                tur = Habitacion.obtenerDetalles(nroHabitacion);
                                tar = Tarifa.obtenerTarifaInicial(nroHabitacion, tur.desde);
                                RestauradorTarifa.contPernocte[nroHabitacion] = tur.contPernocte;
                            }

                            if (dr.Cells[10].Value != null && dr.Cells[10].Value.ToString() == "1")
                            {
                                RestauradorTarifa.actualizarTarifa(tur, tar, dr);
                            }
                            else
                            {
                                dr.Cells[10].Value = "1";
                                tur.hasta = tur.hasta.AddMinutes(tar.tolerancia);
                                updateDetallesTurno(nroHabitacion, 0, tur.hasta, 0, dr);
                                goto inicio;
                            }
                        }
                    }
                }
        }

        static public void borrarPicturesBoxesParpadeo(DataGridView dgv1, DataGridView dgv2)
        {
            
            List<int> list = new List<int>();
            foreach (int nroHab in dictHabParpadeando.Keys)
            {
                list.Add(nroHab);
            }
            foreach (int nroHab in list)
            {
                dgv1.Controls.Remove(dictHabParpadeando[nroHab].picBox);
                dgv2.Controls.Remove(dictHabParpadeando[nroHab].picBox);
                dictHabParpadeando.Remove(nroHab);
            }
            

        }

        public void borrarPB_parpadeo(int nroHab)
        {
            lock (fPrincipal2.locker)
            {
                if (dictHabParpadeando.ContainsKey(nroHab))
                {
                    dataGridView1.Controls.Remove(dictHabParpadeando[nroHab].picBox);
                    dataGridView2.Controls.Remove(dictHabParpadeando[nroHab].picBox);
                    dictHabParpadeando.Remove(nroHab);
                }
            }
        }
        
        private void timerParpadeo2_tick()
        {
            try
            {
                if (dataGridView1.InvokeRequired)
                {
                    timerParpadeo2Callback d = new timerParpadeo2Callback(timerParpadeo2_tick);
                    this.Invoke(d);
                }
                else
                {
                    mut.WaitOne();
                    try
                    {
                        List<DataGridView> grids = new List<DataGridView>();
                        grids.Add(dataGridView1);
                        grids.Add(dataGridView2);
                        foreach (DataGridView dg in grids)
                        {
                            if (dg != null && dg.Rows != null)
                            {
                                foreach (DataGridViewRow fila in dg.Rows)
                                {
                                    if (fila.Cells[8].Value.ToString() == "A")
                                    {
                                        if (estadoHabitaciones[int.Parse(fila.Cells[0].Value.ToString())] == 0) // 0 es destrabada
                                        {
                                            if (fila.Cells[0].Style.BackColor == Color.FromArgb(51, 255, 51))
                                                fila.Cells[0].Style.BackColor = Color.Green;//dataGridView1.DefaultCellStyle.BackColor;
                                            else
                                                fila.Cells[0].Style.BackColor = Color.FromArgb(51, 255, 51);// Colorar.GreenYellow;
                                        }
                                        else
                                            fila.Cells[0].Style.BackColor = Color.Green;
                                    }
                                    else if (fila.Cells[8].Value.ToString() == "D")
                                    {
                                        if (estadoHabitaciones[int.Parse(fila.Cells[0].Value.ToString())] == 1) // 1 es trabada
                                        {
                                            if (fila.Cells[0].Style.BackColor == Color.Tomato)
                                                fila.Cells[0].Style.BackColor = Color.Green;// dataGridView1.DefaultCellStyle.BackColor;
                                            else
                                                fila.Cells[0].Style.BackColor = Color.Tomato;
                                        }
                                        else
                                            fila.Cells[0].Style.BackColor = Color.Green;
                                    }
                                }
                            }
                        }                     
                    }
                    catch (Exception ex)
                    {
                        LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
                    }

                    mut.ReleaseMutex();
                }
            }
            catch
            {
                Thread.CurrentThread.Interrupt();
            }
        }

        private void timerParpadeo2()
        {            
            while (true)
            {                
                timerParpadeo2_tick();                
                Thread.Sleep(300);
            }
        }

        //public void timerParpadeo_Tick(object sender, EventArgs e)
        //{
        //    mut.WaitOne();
        //    string estado;
        //    int nroHab;
        //    DataGridViewRowCollection filas;
        //    try
        //    {
        //        if (dataGridView1.IsDisposed)
        //            return;

        //        if (dataGridView1.Rows != null)// para esperar que se haya llenado de datos las grillas( debido al mutex, o las dos o ninguna)
        //        {
        //            for (int contador = 1; contador <= 2; contador++)
        //            {
        //                if (contador == 1)
        //                    filas = dataGridView1.Rows;
        //                else
        //                    filas = dataGridView2.Rows;

        //                foreach (DataGridViewRow fila in filas)
        //                {
        //                    estado = fila.Cells[8].Value.ToString();
        //                    nroHab = int.Parse(fila.Cells[0].Value.ToString());

        //                    if (estado == "A")
        //                    {
        //                        if (estadoHabitaciones[nroHab] == 0)// Puerta Sin trabar => ParpadeoVerde
        //                        {
        //                            if (!dictHabParpadeando.ContainsKey(nroHab))
        //                            {
        //                                DataGridViewCellStyle style = fila.Cells[0].Style.Clone();
        //                                PictureBox pb = crearPB_Parpadeo(Resources.parpadeoVerde, fila);
        //                                itemDicParpadeo item = new itemDicParpadeo(style, pb);
        //                                dictHabParpadeando.Add(nroHab, item);
        //                                fila.DataGridView.Controls.Add(pb);

        //                            }
        //                        }
        //                        else if (estadoHabitaciones[nroHab] == 1)
        //                        {
        //                            if (dictHabParpadeando.ContainsKey(nroHab))
        //                            {
        //                                fila.Cells[0].Style.ForeColor = Color.Black;
        //                                fila.DataGridView.Controls.Remove(dictHabParpadeando[nroHab].picBox);
        //                                lock (fPrincipal2.locker)
        //                                {
        //                                    dictHabParpadeando.Remove(nroHab);
        //                                }
        //                            }
        //                        }
        //                    }

        //                    else if (estado == "D")
        //                    {
        //                        if (estadoHabitaciones[nroHab] == 1)
        //                        {
        //                            if (!dictHabParpadeando.ContainsKey(nroHab))
        //                            {
        //                                DataGridViewCellStyle style = fila.Cells[0].Style.Clone();
        //                                PictureBox pb = crearPB_Parpadeo(Resources.parpadeoRojo, fila);
        //                                itemDicParpadeo item = new itemDicParpadeo(style, pb);
        //                                dictHabParpadeando.Add(nroHab, item);
        //                                fila.DataGridView.Controls.Add(pb);
        //                            }
        //                        }
        //                        if (estadoHabitaciones[nroHab] == 0)
        //                        {
        //                            if (dictHabParpadeando.ContainsKey(nroHab))
        //                            {
        //                                fila.Cells[0].Style.BackColor = Color.Green;
        //                                fila.Cells[0].Style.ForeColor = Color.Black;
        //                                fila.DataGridView.Controls.Remove(dictHabParpadeando[nroHab].picBox);
        //                                lock (fPrincipal2.locker)
        //                                {
        //                                    dictHabParpadeando.Remove(nroHab);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
        //    }

        //    mut.ReleaseMutex();
        //}

        private PictureBox crearPB_Parpadeo(Bitmap bitmap, DataGridViewRow fila)
        {
            PictureBox pb = new PictureBox();
            pb.Paint += new PaintEventHandler(pb_Paint);
            System.Drawing.Size tam = new Size(fila.DataGridView.GetCellDisplayRectangle(0, 0, false).Size.Width, fila.DataGridView.GetCellDisplayRectangle(0, 0, false).Size.Height - 1);
            pb.Size = tam;
            pb.Image = bitmap;
            pb.Name = "parpadeando";
            pb.Tag = fila.Cells[0].Value.ToString();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackColor = Color.Transparent;
            pb.Location = fila.DataGridView.GetCellDisplayRectangle(0, fila.Index, true).Location;
            fila.Cells[0].Style.ForeColor = Color.Transparent;

            return pb;
        }

        private void pb_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Font fuente = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, this.tamFuente, FontStyle.Bold);

            e.Graphics.DrawString(pb.Tag.ToString(), fuente, Brushes.Black, (e.ClipRectangle.Width - e.Graphics.MeasureString(pb.Tag.ToString(), fuente).Width) / 2, (e.ClipRectangle.Height / 2 - fuente.GetHeight() / 2));
        }

        private void textUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char)Keys.Enter == e.KeyChar)
            {
                textClave.Focus();
                e.Handled = true;
                return;
            }

        }

        private void textClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            int clave = 0;
            int usuario = 0;

            if ((char)Keys.Enter == e.KeyChar)
            {
                if (textUsuario.Text == "" || int.TryParse(textUsuario.Text, out usuario) == false)
                    textUsuario.Text = "0";
                if (textClave.Text == "" || int.TryParse(textClave.Text, out clave) == false)
                    textClave.Text = "0";
                conserjeActual = Conserje.Login(usuario, clave);
                if (conserjeActual == null)
                {
                    textClave.Text = "";
                    textUsuario.Text = "";
                    textUsuario.Focus();
                }
                else
                {
                    textUsuario.Visible = false;
                    labelClave.Visible = false;
                    textClave.Visible = false;
                    labelConserje.Text = "Conserje:" + conserjeActual.nombre;
                    panelDatosHotel_Paint(panelDatosHotel, new PaintEventArgs(panelDatosHotel.CreateGraphics(), panelDatosHotel.ClientRectangle));
                }
                e.Handled = true;
            }
        }

        private void timerValidarAlarmas_Tick(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("habitacion_obtenerAlarmas", conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        Aviso av = new Aviso(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), row[2].ToString());
                        if (!alarmas.Exists(x => x.id == av.id && x.hora == av.hora && x.nroHab == av.nroHab))
                            alarmas.Add(av);
                    }
                }
                if (alarmas.Count > 0)
                {
                    if (!Alarma.prendida)
                        Alarma.activar(this, "¡ ALARMA !  " + alarmas[0].mensaje + " - Habitación Nro: " + alarmas[0].nroHab);
                    actualizarDicAlarmasSonando(alarmas);
                }
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
                return;
            }
        }

        private void actualizarDicAlarmasSonando(List<Aviso> alarmas)
        {
            bool redibujar = false;

            if (dataGridView1.Rows.Count > 0 && dataGridView1.GetCellDisplayRectangle(4, 0, true).Size.Width > 0)
            {
                PictureBox pb;
                bool exit = false;

                foreach (Aviso item in alarmas)
                {
                    if (dicAlarmasSonando.ContainsKey(item.nroHab))
                        continue;

                    redibujar = true;
                    pb = new PictureBox();
                    pb.Size = dataGridView1.GetCellDisplayRectangle(4, 0, true).Size;
                    pb.Image = Resources.relojSonando_2;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.BackColor = Color.Transparent;

                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (((DataGridViewTextBoxCell)row.Cells[0]).Value.ToString() == item.nroHab.ToString())
                        {
                            if (!dicAlarmasSonando.ContainsKey(item.nroHab))
                            {
                                ((DataGridViewImageCell)row.Cells[4]).Value = Resources.vacio;
                                dicAlarmasSonando.Add(item.nroHab, null);
                            }
                            exit = true;
                            break;
                        }
                    }

                    if (exit)
                        continue;

                    foreach (DataGridViewRow row in this.dataGridView2.Rows)
                    {
                        if (((DataGridViewTextBoxCell)row.Cells[0]).Value.ToString() == item.nroHab.ToString())
                        {
                            if (!dicAlarmasSonando.ContainsKey(item.nroHab))
                            {
                                ((DataGridViewImageCell)row.Cells[4]).Value = Resources.vacio;
                                dicAlarmasSonando.Add(item.nroHab, null);
                            }
                            break;
                        }
                    }
                }
            }


            if (redibujar)
            {
                tools.actualizarListadoTurnos(dataGridView1, dataGridView2);
            }
        }

        private void panelDatosHotel_Paint(object sender, PaintEventArgs e)
        {
            //Esta funcion es para el login del conserje la primera vez q entra
            if (textClave.Visible)
            {
                textUsuario.Focus();
                int ancho = 1;
                e.Graphics.DrawRectangle(new Pen(Color.Chocolate, ancho + 2), textUsuario.Bounds.X - ancho, textUsuario.Bounds.Y - ancho, textUsuario.Bounds.Width + ancho, textUsuario.Bounds.Height + ancho);
                e.Graphics.DrawRectangle(new Pen(Color.Chocolate, ancho + 2), textClave.Bounds.X - ancho, textClave.Bounds.Y - ancho, textClave.Bounds.Width + ancho, textClave.Bounds.Height + ancho);
                e.Graphics.DrawRectangle(new Pen(Color.Chocolate, ancho + 2), textClave.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(panelDatosHotel.BackColor), e.ClipRectangle);
            }

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int nHab = 0;
            if (e.IsLastVisibleRow && fPrincipal2.dicAlarmasSonando.Count > 0)
            {
                contador++;

                DataGridView dgv = (DataGridView)sender;
                dgv.Controls.Find("as", true);

                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    if (dr.Cells[8].Value.ToString() == "A" || dr.Cells[8].Value.ToString() == "O")
                    {
                        nHab = int.Parse(dr.Cells[0].Value.ToString());
                        if (fPrincipal2.dicAlarmasSonando.ContainsKey(nHab))// Si hay alarmas Sonando, creo el picture box
                        {
                            if (!dgv.Controls.Contains(dicAlarmasSonando[nHab]))
                            {
                                PictureBox pb = tools.crearPB_AlarmaSonando(dr);
                                dicAlarmasSonando[int.Parse(dr.Cells[0].Value.ToString())] = pb;
                                dgv.Controls.Add(pb);
                            }
                        }
                    }
                }

            }
        }

        private void ActualizarLaHora()
        {
            while (true)
            {
                try
                {
                    actualizarReloj();
                    Thread.Sleep(10000);
                }
                catch
                {
                    break;
                }
            }
        }

        private void ControlarTarifaHabitacion()
        {
            while (true)
            {
                try
                {
                    if (dataGridView1.Rows.Count + dataGridView2.Rows.Count == cantHab)
                        actualizarTarifas();
                    Thread.Sleep(10000);//Cada 10 seg
                }
                catch { }
            }
        }

        delegate void actualizarTarifasCallback();

        private void actualizarTarifas()
        {
            try
            {
                if (dataGridView1.InvokeRequired)
                {
                    actualizarTarifasCallback d = new actualizarTarifasCallback(actualizarTarifas);
                    this.Invoke(d);
                }
                else
                {
                    List<DataGridView> datagrids = new List<DataGridView>();
                    datagrids.Add(dataGridView1);
                    datagrids.Add(dataGridView2);
                    foreach (DataGridView dg in datagrids)
                        foreach (DataGridViewRow dr in dg.Rows)
                        {
                            if (dr.Cells[8].Value.ToString() == "A" || dr.Cells[8].Value.ToString() == "O")
                            {
                                int nroHabitacion = Convert.ToInt32(dr.Cells[0].Value);
                                DetallesHabitacion tur = null;
                                Tarifa tar = null;

                            inicio:

                                if (Convert.ToDateTime(dr.Cells[9].Value) <= DateTime.Now) // Columna Hasta en formato DateTime
                                {
                                    if (tur == null)
                                    {
                                        tur = Habitacion.obtenerDetalles(nroHabitacion);
                                        tar = Tarifa.obtenerTarifaInicial(nroHabitacion, tur.desde);
                                        ActualizadorTarifa.contPernocte[nroHabitacion] = tur.contPernocte;
                                    }

                                    if (dr.Cells[10].Value != null && dr.Cells[10].Value.ToString() == "1")
                                    {
                                        ActualizadorTarifa.actualizarTarifa(tur, tar, dr);
                                    }
                                    else
                                    {
                                        dr.Cells[10].Value = "1";// tolerancia en 1
                                        tur.hasta = tur.hasta.AddMinutes(tar.tolerancia);
                                        updateDetallesTurno(nroHabitacion, 0, tur.hasta, 0, dr);
                                        goto inicio;
                                    }
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                int test = 0;
            }
        }

        public void updateDetallesTurno(int nroHab, decimal montoAsumar, DateTime hasta, decimal contPernocte, DataGridViewRow dr)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("turnos_actualizar", fPrincipal2.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@monto", montoAsumar);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@hasta", hasta);
            if (contPernocte == 0)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@contPern", contPernocte);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.ExecuteNonQuery();

            dr.Cells[9].Value = hasta;// h.salida datetime


            dr.Cells[6].Value = hasta.ToString("HH:mm");//h.salida datetime
            dr.Cells[7].Value = (decimal.Parse(dr.Cells[7].Value.ToString().Replace("$ ", "")) + montoAsumar).ToString("C");// importe

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
        }

        private void fPrincipal2_FormClosed(object sender, FormClosedEventArgs e)
        {
            thActualizarHora.Abort();
            thControlarParpadeo.Abort();
            thControlarTarifa.Abort();
        }       
    }
}




//protected override CreateParams CreateParams
//{
//    get
//    {
//        CreateParams cp = base.CreateParams;
//        cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
//        return cp;
//    }
//}