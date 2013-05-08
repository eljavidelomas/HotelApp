using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using Hoteles.Properties;
using Hoteles.Entities;
using System.Threading;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Hoteles
{
    public partial class fPrincipal_bk : Form
    {
        static int testPaint = 0;
        public DataGridView dataGridView1;
        public DataGridView col2;
        private static Mutex mut = new Mutex();
        //static bool cuadricula = false;
        public static SqlConnection conn = new SqlConnection(Settings.Default.hotelConnectionString);
        public Conserje conserjeActual;
        public List<Aviso> alarmas = new List<Aviso>();
        public Dictionary<int, PictureBox> dicAlarmasSonando = new Dictionary<int, PictureBox>();
        public int maxFilas;
        public int cantHab;
        public static Thread th;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Dictionary<int, int> estadoHabitaciones = new Dictionary<int, int>();

        public fPrincipal_bk()
        {
            log.Info("Comienzo - Aplicacion Hotel");
            InitializeComponent();
            th = new Thread(new ThreadStart(timerParpadeo_Tick));
            th.Start();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            GoFullscreen(false);
            initConnection();

            for (int i = 107; i < 121; i++)
            {
                estadoHabitaciones.Add(i, 0);
            }
            estadoHabitaciones.Add(101, 0);
            estadoHabitaciones.Add(102, 1);
            estadoHabitaciones.Add(103, 1);
            estadoHabitaciones.Add(104, 1);
            estadoHabitaciones.Add(105, 0);
            estadoHabitaciones.Add(106, 1);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public void initConnection()
        {
            conn.Open();
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

        private void fPrincipal_Load(object sender, EventArgs e)
        {
            int maxFilas;
            SqlDataReader reader;

            conserjeActual = Conserje.obtenerConserjeActual();

            if (conserjeActual == null)
            {
                textUsuario.Visible = true;
                labelClave.Visible = true;
                textClave.Visible = true;
                textUsuario.Focus();
            }
            else
            {
                labelConserje.Text = "Conserje:" + conserjeActual.nombre;
            }
            labelNombre.Text = tools.obtenerParametroString("nombreHotel");
            labelHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm");
            labelFecha.Text = String.Format("{0:ddd}", DateTime.Now).ToUpper() + " " + DateTime.Now.ToString("dd / MM / yyyy");
            SqlCommand comm = new SqlCommand("listaTurnos_2", conn);
            comm.Parameters.AddWithValue("@orden", tools.obtenerParametroString("ordenListado"));
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter cantHab = new SqlParameter("@ret", SqlDbType.Int);
            cantHab.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(cantHab);
            comm.ExecuteNonQuery();
            this.maxFilas = maxFilas = ((int)cantHab.Value / 2) - 1;
            this.cantHab = (int)cantHab.Value;

            dataGridView1 = TablaTurnos.nuevaTabla();
            dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(dataGridView_Paint);
            dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView_RowPostPaint);
            dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);

            this.tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            this.tableLayoutPanel1.SetRowSpan(dataGridView1, 2);
            dataGridView1.RowTemplate.Height = tools.calcularAltoFila(this.dataGridView1, (int)cantHab.Value, maxFilas);
            float resto = dataGridView1.Height - dataGridView1.ColumnHeadersHeight - (dataGridView1.RowTemplate.Height * (maxFilas + 1));
            if (resto > 5)
                resto = resto - 5;
            dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight + (int)(Math.Floor(resto));
            
            float tamFuente = 12f + (3.6f - (0.1f * (int)cantHab.Value));
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", tamFuente, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            reader = comm.ExecuteReader();
            //reader.Close();
            //dibujar(maxFilas, (int)cantHab.Value, reader);

            //dataGridView1.Sort(new RowComparer(System.Windows.Forms.SortOrder.Descending));
            dataGridView1.Enabled = true;
            dataGridView1.DataSource = null;
            reader.Close();
            //dataGridView1.SuspendLayout();
        }

        public void dibujar_bk(int maxFilas, int cantHab, SqlDataReader reader)
        {
            mut.WaitOne();
            
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Controls.Clear();
            }
            if (col2 != null)
            {
                this.tableLayoutPanel1.Controls.Remove(col2);
                col2.Rows.Clear();
                col2 = null;
            }
            int ultFila = 0;
            while (ultFila < maxFilas && reader.Read())
            {
//                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(reader["nroHabitacion"], reader["categoria2"].ToString() == "" ? reader["categoria"] : reader["categoria2"]);
                ultFila = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None);
               

                dataGridView1.Rows[ultFila].Cells["importe"].Value = String.Format("{0:C}", reader["importe"]);

                //---  Seteo el reloj para las alarmas  ---//
                if (reader["estado"].ToString() == "A" || reader["estado"].ToString() == "O")
                {
                    //---  Si hay alarmas ---//
                    if (dicAlarmasSonando.ContainsKey(int.Parse(reader["nroHabitacion"].ToString())))
                    {
                        PictureBox pb = new PictureBox();
                        pb.Size = dataGridView1.GetCellDisplayRectangle(4, 0, true).Size;
                        pb.Image = Resources.relojSonando_2;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.BackColor = Color.Transparent;
                        pb.Location = dataGridView1.GetCellDisplayRectangle(4, dataGridView1.Rows[ultFila].Index, true).Location;
                        //if (dataGridView1.Controls.Contains(dicAlarmasSonando[int.Parse(reader["nroHabitacion"].ToString())]))
                        //    dataGridView1.Controls.Remove(dicAlarmasSonando[int.Parse(reader["nroHabitacion"].ToString())]);
                        dataGridView1.Controls.Add(pb);
                    }
                    else
                    {
                        if (reader["aviso"].ToString() != "")
                            dataGridView1.Rows[ultFila].Cells["alarma"].Value = Resources.relojSonando_2;
                    }
                }

                if (reader["estado"].ToString() == "D") // Disponible
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "D";
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = "";
                    dataGridView1.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.vacio);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;

                }
                else if (reader["estado"].ToString() == "A") // Asignada
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "A";
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                    dataGridView1.Rows[ultFila].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                }
                else if (reader["estado"].ToString() == "O") // Ocupada
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "O";
                    dataGridView1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                    dataGridView1.Rows[ultFila].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Tomato;
                    //if (reader["aviso"].ToString() != "")
                    //    if (!dicAlarmasSonando.ContainsKey(int.Parse(reader["nroHabitacion"].ToString())))
                    //        dataGridView1.Rows[ultFila].Cells["alarma"].Value = Resources.relojSonando_2;
                }
                else if (reader["estado"].ToString() == "M") // Mucama
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "M"; // Mucama
                    dataGridView1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Yellow;
                }
                else // Otro...
                {
                    //dataGridView1.Rows[ultFila].DefaultCellStyle.BackColor = Color.Gainsboro;
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "X"; // deshabilitado
                    dataGridView1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.vacio);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Gainsboro;
                }
            }
            if (cantHab > maxFilas)
            {
                ultFila = 0;
                col2 = TablaTurnos.nuevaTabla();
                col2.DefaultCellStyle.Font = dataGridView1.DefaultCellStyle.Font;
                col2.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight;
                col2.RowTemplate.Height = dataGridView1.RowTemplate.Height;
                this.tableLayoutPanel1.Controls.Add(col2, 1, 1);
                this.tableLayoutPanel1.SetRowSpan(col2, 2);
                while (reader.Read() && ultFila < 24)
                {
                    //DataGridViewRow row = new DataGridViewRow();
                    col2.Rows.Add(reader["nroHabitacion"], reader["categoria"]);
                    ultFila = col2.Rows.GetLastRow(DataGridViewElementStates.None);

                    col2.Rows[ultFila].Cells["importe"].Value = String.Format("{0:C}", reader["importe"]);

                    //---  Seteo el reloj para las alarmas  ---//
                    if (reader["estado"].ToString() == "A" || reader["estado"].ToString() == "O")
                    {
                        //---  Si hay alarmas ---//
                        if (dicAlarmasSonando.ContainsKey(int.Parse(reader["nroHabitacion"].ToString())))
                        {
                            PictureBox pb = new PictureBox();
                            pb.Size = dataGridView1.GetCellDisplayRectangle(4, 0, true).Size;
                            pb.Image = Resources.relojSonando_2;
                            pb.SizeMode = PictureBoxSizeMode.Zoom;
                            pb.BackColor = Color.Transparent;
                            pb.Location = dataGridView1.GetCellDisplayRectangle(4, col2.Rows[ultFila].Index, true).Location;
                            if (col2.Controls.Contains(dicAlarmasSonando[int.Parse(reader["nroHabitacion"].ToString())]))
                                col2.Controls.Remove(dicAlarmasSonando[int.Parse(reader["nroHabitacion"].ToString())]);
                            col2.Controls.Add(pb);
                        }
                        else
                        {
                            if (reader["aviso"].ToString() != "")
                                col2.Rows[ultFila].Cells["alarma"].Value = Resources.relojSonando_2;
                        }
                    }

                    if (reader["estado"].ToString() == "D")
                    {
                        col2.Rows[ultFila].Cells["estado"].Value = "D";
                        col2.Rows[ultFila].Cells["salida"].Value = "";
                        col2.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.vacio);
                        col2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                    }
                    else if (reader["estado"].ToString() == "A")
                    {
                        col2.Rows[ultFila].Cells["estado"].Value = "A";
                        col2.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                        col2.Rows[ultFila].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                        col2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                        ////Si hay alarmas
                        //if (reader["aviso"].ToString() != "")
                        //    if (!dicAlarmasSonando.ContainsKey(int.Parse(reader["nroHabitacion"].ToString())))
                        //        col2.Rows[ultFila].Cells["alarma"].Value = Resources.relojSonando_2;

                    }
                    else if (reader["estado"].ToString() == "O") // Ocupada
                    {
                        col2.Rows[ultFila].Cells["estado"].Value = "O";
                        col2.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                        col2.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                        col2.Rows[ultFila].DefaultCellStyle.Font = new Font(col2.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                        col2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Tomato;
                        //if (reader["aviso"].ToString() != "")
                        //    if (!dicAlarmasSonando.ContainsKey(int.Parse(reader["nroHabitacion"].ToString())))
                        //        col2.Rows[ultFila].Cells["alarma"].Value = Resources.relojSonando_2;
                    }
                    else if (reader["estado"].ToString() == "M") // Mucama
                    {
                        col2.Rows[ultFila].Cells["estado"].Value = "M"; // Mucama
                        col2.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                        col2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Yellow;
                    }
                    else // Otro...
                    {
                        //col2.Rows[ultFila].DefaultCellStyle.BackColor = Color.Gainsboro;
                        col2.Rows[ultFila].Cells["estado"].Value = "X"; // deshabilitado
                        col2.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.vacio);
                        col2.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Gainsboro;
                    }
                }
                col2.ClearSelection();
            }
            dataGridView1.ClearSelection();
            reader.Close();
            dataGridView1.DataSource = null;
            col2 = null;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            mut.ReleaseMutex();
        }

        public void dibujar(int maxFilas, int cantHab, SqlDataReader reader)
        {
            mut.WaitOne();
         

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Controls.Clear();
            }
            if (col2 != null)
            {
                this.tableLayoutPanel1.Controls.Remove(col2);
                col2.Rows.Clear();
                col2 = null;
            }
            int ultFila = 0;
            while (ultFila < maxFilas && reader.Read())
            {
                //                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(reader["nroHabitacion"], reader["categoria2"].ToString() == "" ? reader["categoria"] : reader["categoria2"]);
                ultFila = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None);


                dataGridView1.Rows[ultFila].Cells["importe"].Value = String.Format("{0:C}", reader["importe"]);

                //---  Seteo el reloj para las alarmas  ---//
                if (reader["estado"].ToString() == "A" || reader["estado"].ToString() == "O")
                {
                    //---  Si hay alarmas ---//
                    if (dicAlarmasSonando.ContainsKey(int.Parse(reader["nroHabitacion"].ToString())))
                    {
                        PictureBox pb = new PictureBox();
                        pb.Size = dataGridView1.GetCellDisplayRectangle(4, 0, true).Size;
                        pb.Image = Resources.relojSonando_2;
                        pb.SizeMode = PictureBoxSizeMode.Zoom;
                        pb.BackColor = Color.Transparent;
                        pb.Location = dataGridView1.GetCellDisplayRectangle(4, dataGridView1.Rows[ultFila].Index, true).Location;
                        //if (dataGridView1.Controls.Contains(dicAlarmasSonando[int.Parse(reader["nroHabitacion"].ToString())]))
                        //    dataGridView1.Controls.Remove(dicAlarmasSonando[int.Parse(reader["nroHabitacion"].ToString())]);
                        dataGridView1.Controls.Add(pb);
                    }
                    else
                    {
                        if (reader["aviso"].ToString() != "")
                            dataGridView1.Rows[ultFila].Cells["alarma"].Value = Resources.relojSonando_2;
                    }
                }

                if (reader["estado"].ToString() == "D") // Disponible
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "D";
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = "";
                    dataGridView1.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.vacio);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;

                }
                else if (reader["estado"].ToString() == "A") // Asignada
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "A";
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                    dataGridView1.Rows[ultFila].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Green;
                }
                else if (reader["estado"].ToString() == "O") // Ocupada
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "O";
                    dataGridView1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                    dataGridView1.Rows[ultFila].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Tomato;
                    //if (reader["aviso"].ToString() != "")
                    //    if (!dicAlarmasSonando.ContainsKey(int.Parse(reader["nroHabitacion"].ToString())))
                    //        dataGridView1.Rows[ultFila].Cells["alarma"].Value = Resources.relojSonando_2;
                }
                else if (reader["estado"].ToString() == "M") // Mucama
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "M"; // Mucama
                    dataGridView1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Yellow;
                }
                else // Otro...
                {
                    //dataGridView1.Rows[ultFila].DefaultCellStyle.BackColor = Color.Gainsboro;
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "X"; // deshabilitado
                    dataGridView1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.vacio);
                    dataGridView1.Rows[ultFila].Cells["nroHab"].Style.BackColor = Color.Gainsboro;
                }
            }
          
            dataGridView1.ClearSelection();
            reader.Close();
            dataGridView1.DataSource = null;
            col2 = null;
          
            mut.ReleaseMutex();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (conserjeActual == null)
                    return base.ProcessCmdKey(ref msg, keyData);

                //if (GestorTeclado.ProcesarTecla(keyData, this))
                //    return true;
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                log.Error("fPrincipal - ProcessCmdKey  = " + ex.Message);
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm");
            labelFecha.Text = String.Format("{0:ddd}", DateTime.Now).ToUpper() + " " + DateTime.Now.ToString("dd / MM / yyyy");
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

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void dataGridView2_Paint(object sender, PaintEventArgs e)
        {
            testPaint++;
            //string aux = this.labelHora.Text;
            if (testPaint > 40)
                this.labelHora.Text = testPaint.ToString();
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
            if (e.IsLastVisibleRow)
            {
                
                PictureBox pb = new PictureBox();
               

                foreach (Aviso item in alarmas)
                {
                    pb = new PictureBox();
                    pb.Size = dataGridView1.GetCellDisplayRectangle(4, 0, true).Size;
                    pb.Image = Resources.relojSonando_2;
                    pb.SizeMode = PictureBoxSizeMode.Zoom;
                    pb.BackColor = Color.Transparent;


                    foreach (DataGridViewRow row in this.dataGridView1.Rows)
                    {
                        if (((DataGridViewTextBoxCell)row.Cells["nrohab"]).Value.ToString() == item.nroHab.ToString())
                        {
                            pb.Location = dataGridView1.GetCellDisplayRectangle(4, row.Index, true).Location;
                            dataGridView1.Controls.Add(pb);
                            break;
                        }
                    }
                }
            }

        }

        private void dataGridView_Paint(object sender, PaintEventArgs e)
        {
            
            //e.Graphics.DrawRectangle(new Pen(Color.Black, 2), dataGridView1.GetCellDisplayRectangle(4, 1, true));
            //e.Graphics.DrawRectangle(new Pen(Color.Black, 2), dataGridView1.GetCellDisplayRectangle(4, 0, true));
          

        }

        private void timerParpadeo_Tick()
        {
            return;
            while (true)
            {
                mut.WaitOne();
                try
                {

                    if (dataGridView1 != null && dataGridView1.Rows != null)
                    {
                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            if (fila.Cells["estado"].Value.ToString() == "A")
                            {
                                if (estadoHabitaciones[int.Parse(fila.Cells["nroHab"].Value.ToString())] == 0)
                                {
                                    if (fila.Cells["nroHab"].Style.BackColor == Color.Green)
                                        fila.Cells["nroHab"].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                                    else
                                        fila.Cells["nroHab"].Style.BackColor = Color.Green;
                                }
                            }
                            else if (fila.Cells["estado"].Value.ToString() == "D")
                            {
                                if (estadoHabitaciones[int.Parse(fila.Cells["nroHab"].Value.ToString())] == 1)
                                {
                                    if (fila.Cells["nroHab"].Style.BackColor == Color.Tomato)
                                        fila.Cells["nroHab"].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                                    else
                                        fila.Cells["nroHab"].Style.BackColor = Color.Tomato;
                                }
                            }
                        }
                    }
                    if (col2 != null && col2.Rows != null)
                    {
                        foreach (DataGridViewRow fila in col2.Rows)
                        {
                            if (fila.Cells["estado"].Value.ToString() == "A")
                            {
                                if (estadoHabitaciones[int.Parse(fila.Cells["nroHab"].Value.ToString())] == 0)
                                {
                                    if (fila.Cells["nroHab"].Style.BackColor == Color.Green)
                                        fila.Cells["nroHab"].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                                    else
                                        fila.Cells["nroHab"].Style.BackColor = Color.Green;
                                }
                            }
                            else if (fila.Cells["estado"].Value.ToString() == "D")
                            {
                                if (estadoHabitaciones[int.Parse(fila.Cells["nroHab"].Value.ToString())] == 1)
                                {
                                    if (fila.Cells["nroHab"].Style.BackColor == Color.Tomato)
                                        fila.Cells["nroHab"].Style.BackColor = dataGridView1.DefaultCellStyle.BackColor;
                                    else
                                        fila.Cells["nroHab"].Style.BackColor = Color.Tomato;
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
                Thread.Sleep(500);
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
                        Alarma.activar(this, "Alarma ! " + alarmas[0].mensaje + "  Habitación Nro: " + alarmas[0].nroHab);
                    activarIconosAlarmas(alarmas);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message + " - " + ex.StackTrace);
                return;
            }
        }

        private void activarIconosAlarmas(List<Aviso> alarmas)
        {
            mut.WaitOne();
            bool redibujar = false;

            if (dataGridView1.Rows.Count > 0 && dataGridView1.GetCellDisplayRectangle(4, 0, true).Size.Width > 0 )
            {
                PictureBox pb;// = new PictureBox();
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
                        if (((DataGridViewTextBoxCell)row.Cells["nrohab"]).Value.ToString() == item.nroHab.ToString())
                        {
                            if (!dicAlarmasSonando.ContainsKey(item.nroHab))
                            {
                                ((DataGridViewImageCell)row.Cells["alarma"]).Value = Resources.vacio;
                                //pb.Location = dataGridView1.GetCellDisplayRectangle(4, row.Index, true).Location;
                                //dataGridView1.Controls.Add(pb);
                                dicAlarmasSonando.Add(item.nroHab, pb);
                            }
                            exit = true;
                            break;
                        }
                    }

                    if (exit)
                        continue;

                    foreach (DataGridViewRow row in this.col2.Rows)
                    {
                        if (((DataGridViewTextBoxCell)row.Cells["nrohab"]).Value.ToString() == item.nroHab.ToString())
                        {
                            if (!dicAlarmasSonando.ContainsKey(item.nroHab))
                            {
                                ((DataGridViewImageCell)row.Cells["alarma"]).Value = Resources.vacio;
                                //pb.Location = col2.GetCellDisplayRectangle(4, row.Index, true).Location;
                                //col2.Controls.Add(pb);
                                dicAlarmasSonando.Add(item.nroHab, pb);
                            }
                            break;
                        }
                    }
                }
            }
            mut.ReleaseMutex();

            if (redibujar)
            {
                SqlCommand comm = new SqlCommand("listaTurnos_2", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@orden", tools.obtenerParametroString("ordenListado"));
                this.dibujar(maxFilas, cantHab, comm.ExecuteReader());
            }
        }

        internal void QuitarReloj(int nroHab)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (int.Parse(row.Cells[0].Value.ToString()) == nroHab)
                {
                    row.Cells[4].Value = null;
                    return;
                }
            }
            foreach (DataGridViewRow row in col2.Rows)
            {
                if (int.Parse(row.Cells[0].Value.ToString()) == nroHab)
                {
                    row.Cells[4].Value = null;
                    return;
                }
            }

        }

        private void fPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            th.Abort();
        }

    }
}


//class RowComparer : System.Collections.IComparer
//{
//    private static int sortOrderModifier = 1;
//    public RowComparer(System.Windows.Forms.SortOrder sortOrder)
//    {
//        if (sortOrder == System.Windows.Forms.SortOrder.Descending)
//        {
//            sortOrderModifier = -1;
//        }
//        else if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
//        {
//            sortOrderModifier = 1;
//        }
//    }
//    public int Compare(object x, object y)
//    {
//        DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
//        DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;
//        // Try to sort based on the Last Name column.
//        int CompareResult = System.String.Compare(
//            DataGridViewRow1.Cells["estado"].Value.ToString(),
//            DataGridViewRow2.Cells["estado"].Value.ToString());
//        // If the estado are equal, sort based on the salida horario.
//        if (CompareResult == 0)
//        {
//            object row2 = DataGridViewRow2.Cells["salida"].Value;
//            object row1 = DataGridViewRow1.Cells["salida"].Value;
//            CompareResult = System.String.Compare(
//                row2.ToString(), row1.ToString());
//            if (CompareResult == 0)
//            {
//                CompareResult = System.String.CompareOrdinal(
//                DataGridViewRow2.Cells["nroHab"].Value.ToString(),
//                DataGridViewRow1.Cells["nroHab"].Value.ToString());
//            }
//        }
//        return CompareResult * sortOrderModifier;
//    }
//}










//protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
//{
//    base.OnPaint(e);
//    //ControlPaint.DrawBorder(textClave.CreateGraphics(), new Rectangle(textClave.Location, new Size(textClave.Width, textClave.Height)), Color.Red, ButtonBorderStyle.Solid);
//    //e.Graphics.DrawRectangle(new Pen(Color.Red,2.0f), 0, 0, (textUsuario.Width + 1), (textUsuario.Height + 1));
//    //e.Graphics.DrawLine(new Pen(Color.Red, 2.0f), 0, 0, 600, 600);
//}
//private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
//{
//    //if(e.RowIndex == -1 && e.ColumnIndex == 2){
//    //    Image InfoIcon = Image.FromFile(@"C:\wamp\www\Hermes\assets\backend\images\trash.png"); 
//    //    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
//    //    e.Graphics.DrawImage(InfoIcon, new Rectangle(e.CellBounds.Location.X, e.CellBounds.Location.Y, 20, 20));
//    //    e.Handled = true;
//    //}
//}
//private void dataGridView1_Paint(object sender, PaintEventArgs e)
//{

//    //if (!cuadricula)
//    //{
//    //    //cuadricula = true;
//    //    Rectangle rec = dataGridView1.Bounds;
//    //    using (Graphics gr = e.Graphics)//this.dataGridView1.CreateGraphics())
//    //    {
//    //        this.SuspendLayout();
//    //        gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Right - 1, rec.Top - dataGridView1.ColumnHeadersHeight), new Point(rec.Right - 1, rec.Bottom));
//    //        gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Left, rec.Top + 2 - dataGridView1.ColumnHeadersHeight), new Point(rec.Right + tableLayoutPanel1.Controls["col2"].Width, rec.Top + 2 - dataGridView1.ColumnHeadersHeight));
//    //        this.ResumeLayout(true);

//    //    }
//    //}
//    //if (e.IsLastVisibleRow)
//    //    cuadricula = true;
//    //Rectangle rec = e.ClipRectangle;
//    //this.SuspendLayout();

//    //using (Graphics gr = this.dataGridView1.CreateGraphics())
//    //{
//    //    gr.DrawLine(new Pen(Color.Black, 1), new Point(rec.Right-1, rec.Top), new Point(rec.Right-1, rec.Bottom));
//    //    //gr.DrawRectangle(Pens.Black, rec);
//    //    this.ResumeLayout(false);
//    //}
//}

//private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
//{
//    //if (!cuadricula)
//    //{
//    //    //cuadricula = true;
//    //    Rectangle rec = dataGridView1.Bounds;
//    //    rec.X = rec.Y = 0;
//    //    ControlPaint.DrawBorder(this.dataGridView1.CreateGraphics(), rec, Color.Black, ButtonBorderStyle.Solid);
//    //    //using (Graphics gr = this.dataGridView1.CreateGraphics())
//    //    //{

//    //    //    gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Right - 1, 0), new Point(rec.Right - 1, rec.Bottom));
//    //    //    //gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Left, rec.Top + 2 - dataGridView1.ColumnHeadersHeight), new Point(rec.Right + tableLayoutPanel1.Controls["col2"].Width, rec.Top + 2 - dataGridView1.ColumnHeadersHeight));

//    //    //}
//    //}
//    ////if (e.IsLastVisibleRow)
//    ////    cuadricula = true;

//}

//private void dataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
//{
//    //Rectangle rec = dataGridView1.Bounds;
//    //rec.X = rec.Y = 0;
//    //if(e.ColumnIndex==5)
//    //    ControlPaint.DrawBorder(this.dataGridView1.CreateGraphics(), rec, Color.Black, ButtonBorderStyle.Solid);
//}

////private void dataGridView1_Paint_1(object sender, PaintEventArgs e)
////{
////    Rectangle rec = dataGridView1.Bounds;
////    rec.X = rec.Y = 0;

////        ControlPaint.DrawBorder(this.dataGridView1.CreateGraphics(), rec, Color.Black, ButtonBorderStyle.Solid);
////}