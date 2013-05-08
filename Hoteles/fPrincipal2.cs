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
        public Dictionary<int, itemDicParpadeo> dictHabParpadeando = new Dictionary<int, itemDicParpadeo>();
        public static Thread th;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
            timerHora_Tick(this, EventArgs.Empty);
            
            GoFullscreen(true);



            for (int i = 107; i < 121; i++)
            {
                estadoHabitaciones.Add(i, 1);
            }
            estadoHabitaciones.Add(101, 0);
            estadoHabitaciones.Add(102, 1);
            estadoHabitaciones.Add(103, 1);
            estadoHabitaciones.Add(104, 1);
            estadoHabitaciones.Add(105, 0);
            estadoHabitaciones.Add(106, 1);
        }

        public void initConnection()
        {
            conn.Open();
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
                log.Error("fPrincipal - ProcessCmdKey  = " + ex.Message);
                return base.ProcessCmdKey(ref msg, keyData);
            }
            //try
            //{
            //    List<Control> lis = new List<Control>();
            //    if (keyData == Keys.Escape)
            //    {
            //        tools.borrarIconosAlarmasSonando(dataGridView1);
            //        for (int nH=101;nH<121;nH++)
            //        {
            //            estadoHabitaciones[nH] = 0;                        
            //        }                  

            //        return true;
            //    }
            //    return base.ProcessCmdKey(ref msg, keyData);
            //}
            //catch (Exception ex)
            //{
            //    return base.ProcessCmdKey(ref msg, keyData);
            //}
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

            timerParpadeo_Tick(this, EventArgs.Empty);

        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm");
            labelFecha.Text = String.Format("{0:ddd}", DateTime.Now).ToUpper() + " " + DateTime.Now.ToString("dd / MM / yyyy");
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {


        }

        //private void timer_parpadeoHabitaciones_Tick(object sender, EventArgs e)
        //{
        //    th = new Thread(new ThreadStart(timerParpadeo_Tick));
        //    th.IsBackground = true;
        //    th.Start();
        //    //this.timerParpadeo_Tick();
        //}

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

        private void timerParpadeo_Tick(object sender, EventArgs e)
        {
            mut.WaitOne();
            string estado;
            int nroHab;
            DataGridViewRowCollection filas;
            try
            {
                if (dataGridView1.IsDisposed)
                    return;

                if (dataGridView1.Rows != null)// para esperar que se haya llenado de datos las grillas( debido al mutex, o las dos o ninguna)
                {
                    for (int contador = 1; contador <= 2; contador++)
                    {
                        if (contador == 1)
                            filas = dataGridView1.Rows;
                        else
                            filas = dataGridView2.Rows;

                        foreach (DataGridViewRow fila in filas)
                        {
                            estado = fila.Cells[8].Value.ToString();
                            nroHab = int.Parse(fila.Cells[0].Value.ToString());

                            if (estado == "A")
                            {
                                if (estadoHabitaciones[nroHab] == 0)// Puerta Sin trabar => ParpadeoVerde
                                {
                                    if (!dictHabParpadeando.ContainsKey(nroHab))
                                    {
                                        DataGridViewCellStyle style = fila.Cells[0].Style.Clone();
                                        PictureBox pb = crearPB_Parpadeo(Resources.parpadeoVerde, fila);
                                        itemDicParpadeo item = new itemDicParpadeo(style, pb);
                                        dictHabParpadeando.Add(nroHab, item);
                                        fila.DataGridView.Controls.Add(pb);
                                      
                                    }
                                }
                                else if (estadoHabitaciones[nroHab] == 1)
                                {
                                    if (dictHabParpadeando.ContainsKey(nroHab))
                                    {
                                        //fila.Cells[0].Style.BackColor = Color.Red;
                                        fila.Cells[0].Style.ForeColor = Color.Black;
                                        fila.DataGridView.Controls.Remove(dictHabParpadeando[nroHab].picBox);
                                        lock (fPrincipal2.locker)
                                        {
                                            dictHabParpadeando.Remove(nroHab);
                                        }
                                    }
                                }
                            }

                            else if (estado == "D")
                            {
                                if (estadoHabitaciones[nroHab] == 1)
                                {
                                    if (!dictHabParpadeando.ContainsKey(nroHab))
                                    {
                                        DataGridViewCellStyle style = fila.Cells[0].Style.Clone();
                                        PictureBox pb = crearPB_Parpadeo(Resources.parpadeoRojo, fila);
                                        itemDicParpadeo item = new itemDicParpadeo(style, pb);
                                        dictHabParpadeando.Add(nroHab, item);
                                        fila.DataGridView.Controls.Add(pb);
                                    }
                                }
                                if (estadoHabitaciones[nroHab] == 0)
                                {
                                    if (dictHabParpadeando.ContainsKey(nroHab))
                                    {
                                        fila.Cells[0].Style.BackColor = Color.Green;
                                        fila.Cells[0].Style.ForeColor = Color.Black;
                                        fila.DataGridView.Controls.Remove(dictHabParpadeando[nroHab].picBox);
                                        lock (fPrincipal2.locker)
                                        {
                                            dictHabParpadeando.Remove(nroHab);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message + " - " + ex.StackTrace);
            }

            mut.ReleaseMutex();
            ///test
            labelConserje.Text = (dataGridView1.Controls.Find("parpadeando", true).Count() + dataGridView2.Controls.Find("parpadeando", true).Count()).ToString();
        }

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
                log.Error(ex.Message + " - " + ex.StackTrace);
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
                labelConserje.Text = contador.ToString();

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
    }
}
