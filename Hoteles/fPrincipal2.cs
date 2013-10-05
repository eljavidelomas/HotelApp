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
using WindowsFormsApplication1;
using System.IO.Ports;

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
        static public Dictionary<int, bool> dictSonidoDesocupado = new Dictionary<int, bool>();
        static public Dictionary<int, bool> dictSonidoOcupado = new Dictionary<int, bool>();
        private Thread thActualizarHora;
        private Thread thControlarTarifa;
        private Thread thControlarParpadeo;
        private bool thControlarTarifaSalir=false;

        /*Variables para el port Serie */
        public Dictionary<int, int> estadoHabitaciones = new Dictionary<int, int>();
        public Dictionary<int, int> dictNroordenNroHab = new Dictionary<int, int>();
        public string senialOcupado;

        public fPrincipal2()
        {
            initConnection();

            try
            {
                DataTable dt = tools.listadoTurnos();
                maxFilas = (int)Math.Ceiling(dt.Rows.Count * 0.5);
                cantHab = dt.Rows.Count;
                //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                //this.SetStyle(ControlStyles.UserPaint, true);

                InitializeComponent();
                configPortSerial();
                GoFullscreen(true);
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Error al Iniciar.\r\n" + ex.Message + "-" + ex.StackTrace);
            }

            //for (int i = 1; i < 199; i++)
            //{
            //    estadoHabitaciones.Add(i, 0);
            //}
            //estadoHabitaciones[101] = 1;
            //estadoHabitaciones[104] = 1;
            //estadoHabitaciones[105] = 1;
            //estadoHabitaciones[106] = 1;

        }

        private void configPortSerial()
        {
            if (tools.obtenerParametroInt("haySenializacion") == 1)
            {
                try
                {
                    serialPort1.PortName = tools.obtenerParametroString("portSenialIn");
                    serialPort1.BaudRate = tools.obtenerParametroInt("baudrate");
                    serialPort1.Open();
                    cargarDiccionarioNroOrdenNroHabitacion();
                    senialOcupado = tools.obtenerParametroString("senialOcupado");
                }
                catch (Exception ex)
                {
                    LoggerProxy.ErrorSinBD("Error en la configuracion de señalizacion \r\n" + ex.Message + "-" + ex.StackTrace);
                }
            }
        }

        private void cargarDiccionarioNroOrdenNroHabitacion()
        {
            DataSet ds = new DataSet();
            Dictionary<int, string> categorias = new Dictionary<int, string>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select posSenializacion,nroHabitacion from habitaciones H WHERE habilitada = 1", fPrincipal2.conn);
            try
            {
                dataAdapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dictNroordenNroHab.Add(int.Parse(row[0].ToString()) - 1, int.Parse(row[1].ToString()));
                }

            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Error al cargar diccionario Nro de Orden - Nro de Habitacion.\r\n" + ex.Message + "-" + ex.StackTrace);
            }
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
            tools.calcularAlturas(dataGridView1.Height - dataGridView1.ColumnHeadersHeight, maxFilas < tools.minCantFilas?tools.minCantFilas:maxFilas, out altoFila, out altoFilaExtra);
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


            thActualizarHora = new Thread(ActualizarLaHora);
            thActualizarHora.Start();

            #region ActualizadorTarifaHabitacion

            thControlarTarifa = new Thread(ControlarTarifaHabitacion);
            thControlarTarifa.Start();

            #endregion

            thControlarParpadeo = new Thread(timerParpadeo2);
            thControlarParpadeo.Start();

            if (textUsuario.Visible)
                textUsuario.Focus();
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
                    labelFecha.Text = String.Format("{0:ddd}", DateTime.Now).ToUpper() + " " + DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Fallo Actualizar Hora");
                LoggerProxy.ErrorSinBD(ex.Message+"-"+ex.StackTrace);
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
                                if (RestauradorTarifa.actualizarTarifa(tur, tar, dr) == false)//Si hubo muchas vuetas
                                {
                                    LoggerProxy.Error("No se pudo recuperar la habitacion " + nroHabitacion + ". Error en la definicion de tarifas.");
                                }
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

        /*static public void borrarPicturesBoxesParpadeo(DataGridView dgv1, DataGridView dgv2)
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
        }*/

        /*public void borrarPB_parpadeo(int nroHab)
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
        }*/

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

                    Color cAsig = Color.Green;
                    Color cAsigAlt = Color.GreenYellow;
                    Color cOcup = Color.Red;
                    Color cOcupAlt = Color.Orange;
                    Color cDisp = Color.Green;
                    Color cDispAlt = Color.Red;

                    try
                    {
                        List<DataGridView> grids = new List<DataGridView>();
                        grids.Add(dataGridView1);
                        grids.Add(dataGridView2);
                        foreach (DataGridView dg in grids)
                        {
                            if (dg != null && dg.Rows != null && estadoHabitaciones.Count > 0)
                            {
                                foreach (DataGridViewRow fila in dg.Rows)
                                {
                                    int nroHabitacion = int.Parse(fila.Cells[0].Value.ToString());

                                    //-----   Estado Asignado   -----//
                                    if (fila.Cells[8].Value.ToString() == "A")
                                    {
                                        if (estadoHabitaciones.ContainsKey(nroHabitacion) && estadoHabitaciones[nroHabitacion] == 0) // 0 es destrabada
                                        {
                                            if (fila.Cells[0].Style.BackColor == cAsig)
                                                fila.Cells[0].Style.BackColor = cAsigAlt;
                                            else
                                                fila.Cells[0].Style.BackColor = cAsig;
                                        }
                                        else
                                        {
                                            Habitacion.CambiarEstado(null, Convert.ToInt32(fila.Cells[0].Value), "O");
                                            fila.Cells[8].Value = "O"; // Cambio estado en la grilla
                                            fila.Cells[0].Style.BackColor = cOcup;

                                            /*** Sonido Se ocupo habitacion ***/
                                            List<string> sonido = new List<string>();
                                            sonido.Add("Se ocupo.wav");
                                            sonido.Add("habitacion numero.wav");
                                            sonido.Add(nroHabitacion.ToString() + ".wav");
                                            Audio.PlayList(sonido);
                                            
                                            /*** Grabar Bitacora ***/
                                            EventoAlCierre.grabarCierre(nroHabitacion);
                                            //LoggerProxy.Bitacora("Habitación " + nroHabitacion + " ocupada.");

                                        }
                                    }

                                        //-----   Estado Ocupado   -----//
                                    else if (fila.Cells[8].Value.ToString() == "O")
                                    {
                                        if (tools.obtenerParametroInt("haySenializacion") == 1)
                                        {
                                            if (!dictSonidoDesocupado.ContainsKey(nroHabitacion))
                                                dictSonidoDesocupado.Add(nroHabitacion, false);

                                            if (estadoHabitaciones.ContainsKey(nroHabitacion) && estadoHabitaciones[nroHabitacion] == 0) // 0 es destrabada
                                            {
                                                if (fila.Cells[0].Style.BackColor == cOcup)
                                                    fila.Cells[0].Style.BackColor = cOcupAlt;
                                                else
                                                    fila.Cells[0].Style.BackColor = cOcup;

                                                if (!dictSonidoDesocupado[nroHabitacion])
                                                {
                                                    /*** Sonido Se desocupo habitacion ***/
                                                    List<string> sonido = new List<string>();
                                                    sonido.Add("Se desocupo.wav");
                                                    sonido.Add("habitacion numero.wav");
                                                    sonido.Add(nroHabitacion.ToString() + ".wav");
                                                    Audio.PlayList(sonido);
                                                    dictSonidoDesocupado[nroHabitacion] = true;

                                                    /*** Grabar Bitacora ***/
                                                    LoggerProxy.Bitacora("Habitación " + nroHabitacion + " desocupada.");
                                                }
                                            }
                                            else
                                            {
                                                dictSonidoDesocupado[nroHabitacion] = false;
                                                fila.Cells[0].Style.BackColor = cOcup;                                                
                                            }                                           
                                        }
                                        else                                                                                    
                                            fila.Cells[0].Style.BackColor = cOcup;                                        

                                    }

                                        //-----   Estado Disponible   -----//
                                    else if (fila.Cells[8].Value.ToString() == "D")
                                    {
                                        if (tools.obtenerParametroInt("haySenializacion") == 1)
                                        {
                                            if (!dictSonidoOcupado.ContainsKey(nroHabitacion))
                                                dictSonidoOcupado.Add(nroHabitacion, false);
                                            
                                            /*** Si esta disponible y esta trabada ***/
                                            if (estadoHabitaciones.ContainsKey(nroHabitacion) && estadoHabitaciones[nroHabitacion] == 1)// 1 es trabada
                                            {
                                                if (fila.Cells[0].Style.BackColor == cDisp)
                                                    fila.Cells[0].Style.BackColor = cDispAlt;
                                                else
                                                    fila.Cells[0].Style.BackColor = cDisp;

                                                if (!dictSonidoOcupado[nroHabitacion])
                                                {
                                                    /*** Sonido Se ocupo habitacion ***/
                                                    List<string> sonido = new List<string>();
                                                    sonido.Add("Se ocupo.wav");
                                                    sonido.Add("habitacion numero.wav");
                                                    sonido.Add(nroHabitacion.ToString() + ".wav");
                                                    Audio.PlayList(sonido);
                                                    dictSonidoOcupado[nroHabitacion] = true;

                                                    /*** Grabar Bitacora ***/
                                                    LoggerProxy.Bitacora("Habitación " + nroHabitacion + " ocupada. * Sin asignar *");
                                                }
                                            }

                                            /*** Estado Normal ***/
                                            else 
                                            {
                                                fila.Cells[0].Style.BackColor = cDisp;
                                                if (dictSonidoOcupado[nroHabitacion])
                                                {
                                                    /*** Grabar Bitacora ***/
                                                    LoggerProxy.Bitacora("Habitación " + nroHabitacion + " desocupada. * Sin asignar *");
                                                    dictSonidoOcupado[nroHabitacion] = false;
                                                }
                                            }
                                        }
                                        else                                        
                                            fila.Cells[0].Style.BackColor = cDisp;                                            
                                        
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
                    }
                    finally
                    {
                        mut.ReleaseMutex();
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
                Thread.CurrentThread.Interrupt();
            }
        }

        private void timerParpadeo2()
        {
            if (tools.obtenerParametroInt("haySenializacion") == 1)
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

        /*private PictureBox crearPB_Parpadeo(Bitmap bitmap, DataGridViewRow fila)
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
        }*/

        /*private void pb_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            Font fuente = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, this.tamFuente, FontStyle.Bold);

            e.Graphics.DrawString(pb.Tag.ToString(), fuente, Brushes.Black, (e.ClipRectangle.Width - e.Graphics.MeasureString(pb.Tag.ToString(), fuente).Width) / 2, (e.ClipRectangle.Height / 2 - fuente.GetHeight() / 2));
        }*/

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
                    {
                        Alarma.activar(this, "¡ ALARMA !  " + alarmas[0].mensaje + " - Habitación Nro: " + alarmas[0].nroHab);
                        if (alarmas[0].mensaje.ToLower().Contains("fin de turno"))
                        {
                            List<string> sonido = new List<string>();
                            int i = 0;
                            while (i < 2)
                            {
                                sonido.Add("Aviso fin de turno.wav");
                                sonido.Add("habitacion numero.wav");
                                sonido.Add(alarmas[0].nroHab.ToString() + ".wav");
                                i++;
                            }
                            Audio.PlayList(sonido);
                        }
                    }
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
                actualizarReloj();
                Thread.Sleep(1000);
            }
        }

        private void ControlarTarifaHabitacion()
        {
            while (!thControlarTarifaSalir)
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
                                        if (tools.obtenerParametroInt("haySenializacion") == 1)
                                        {
                                            if (estadoHabitaciones[nroHabitacion] == 1)//si esta cerrado, hago la actualizacìón
                                            {
                                                if (ActualizadorTarifa.actualizarTarifa(tur, tar, dr) == false)
                                                {
                                                    LoggerProxy.Error("No se pudo actualizar la habitacion " + nroHabitacion + ". Error en la definicion de tarifas.");
                                                }
                                            }
                                        }
                                        else
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
                LoggerProxy.ErrorSinBD(ex.Message + " - " + ex.StackTrace);
            }
        }

        public void updateDetallesTurno(int nroHab, decimal montoAsumar, DateTime hasta, decimal contPernocte, DataGridViewRow dr)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("turnos_actualizar", fPrincipal2.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@monto", montoAsumar);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@hasta", hasta);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@contPern", contPernocte);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.ExecuteNonQuery();

            dr.Cells[9].Value = hasta;// datetime salida 
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
            thControlarTarifaSalir = true;
            thControlarTarifa.Abort();
            thControlarTarifa.Join();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string aux = "";
            byte[] array = new byte[64];
            int bAleer = 0;
            bAleer = serialPort1.BytesToRead;
            Dictionary<int, int> d = estadoHabitaciones;
            int nHab;

            try
            {
                if (bAleer == 32 || bAleer == 64)
                {
                    serialPort1.Read(array, 0, bAleer);
                    mut.WaitOne();
                    
                    int est;
                    for (int i = 0; i < bAleer; i++)
                    {
                        nHab = array[i] & 63;
                        if (dictNroordenNroHab.ContainsKey(nHab))
                        {
                            nHab = dictNroordenNroHab[nHab];
                            if (senialOcupado == "1")
                                est = array[i] >> 6 == 1 ? 0 : 1;
                            else
                                est = array[i] >> 6;
                            if (d.ContainsKey(nHab))
                                d[nHab] = est;
                            else
                                d.Add(nHab, est);
                        }

                    }
                    mut.ReleaseMutex();
                }
                else
                    serialPort1.DiscardInBuffer();
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
                mut.ReleaseMutex();
            }
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