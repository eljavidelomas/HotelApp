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

namespace Hoteles
{
    public partial class fPrincipal : Form
    {
        public DataGridView dataGridView1;
        public DataGridView col2;
        static bool cuadricula = false;
        public static SqlConnection conn;
        Conserje conserjeActual;


        public fPrincipal()
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

        private void fPrincipal_Load(object sender, EventArgs e)
        {
            int maxFilas;
            SqlDataReader reader;
            int ultFila = 0;


            if (conn == null)
            {
                conn = new SqlConnection();
                conn.ConnectionString = Settings.Default.hotelConnectionString;
                conn.Open();
            }

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

            labelHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
            labelFecha.Text = "Fecha: " + DateTime.Now.ToString("dd / MM / yyyy");
            SqlCommand comm = new SqlCommand("listaTurnos", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlParameter cantHab = new SqlParameter("@ret", SqlDbType.Int);
            cantHab.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(cantHab);
            comm.ExecuteNonQuery();
            maxFilas = ((int)cantHab.Value / 2) - 1;

            dataGridView1 = TablaTurnos.nuevaTabla();
            this.tableLayoutPanel1.Controls.Add(dataGridView1, 0, 1);
            this.tableLayoutPanel1.SetRowSpan(dataGridView1, 2);
            dataGridView1.RowTemplate.Height = tools.calcularAltoFila(this, (int)cantHab.Value, maxFilas);
            float resto = dataGridView1.Height - dataGridView1.ColumnHeadersHeight - (dataGridView1.RowTemplate.Height * (maxFilas + 1));
            if (resto > 5)
                resto = resto - 5;
            dataGridView1.ColumnHeadersHeight = dataGridView1.ColumnHeadersHeight + (int)(Math.Floor(resto));
            reader = comm.ExecuteReader();
            float tamFuente = 12f + (3.6f - (0.1f * (int)cantHab.Value));
            dataGridView1.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", tamFuente, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            while (ultFila < maxFilas && reader.Read())
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(reader["nroHabitacion"], reader["categoria"]);
                ultFila = dataGridView1.Rows.GetLastRow(DataGridViewElementStates.None);

                dataGridView1.Rows[ultFila].Cells["importe"].Value = String.Format("{0:C}", reader["importe"]);
                if (reader["estado"].ToString() == "D")
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "D";
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = "";
                    dataGridView1.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.vacio);
                    dataGridView1.Rows[ultFila].DefaultCellStyle.ForeColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[ultFila].Cells["estado"].Value = "O";
                    dataGridView1.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                    dataGridView1.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.bar);
                    dataGridView1.Rows[ultFila].Cells["aac"].Value = ((System.Drawing.Image)Resources.aac);
                    dataGridView1.Rows[ultFila].Cells["alarma"].Value = ((System.Drawing.Image)Resources.relojdespertador);                    
                    dataGridView1.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                    dataGridView1.Rows[ultFila].DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold); //dataGridView1.ColumnHeadersDefaultCellStyle.Font;
                    dataGridView1.Rows[ultFila].DefaultCellStyle.ForeColor = Color.Tomato;
                }
            }
            if ((int)cantHab.Value > maxFilas)
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
                    DataGridViewRow row = new DataGridViewRow();
                    col2.Rows.Add(reader["nroHabitacion"], reader["categoria"]);
                    ultFila = col2.Rows.GetLastRow(DataGridViewElementStates.None);

                    col2.Rows[ultFila].Cells["importe"].Value = String.Format("{0:C}", reader["importe"]);
                    if (reader["estado"].ToString() == "D")
                    {
                        col2.Rows[ultFila].Cells["estado"].Value = "D";
                        col2.Rows[ultFila].Cells["salida"].Value = "";
                        col2.Rows[ultFila].Cells["bar"].Value = ((System.Drawing.Image)Resources.vacio);
                        col2.Rows[ultFila].DefaultCellStyle.ForeColor = Color.Green;
                    }
                    else
                    {
                        col2.Rows[ultFila].Cells["estado"].Value = "O";
                        col2.Rows[ultFila].Cells["luz"].Value = ((System.Drawing.Image)Resources.luzOn);
                        col2.Rows[ultFila].Cells["salida"].Value = (DateTime.Parse(reader["hsalida"].ToString())).ToString("HH:mm");
                        col2.Rows[ultFila].DefaultCellStyle.Font = new Font(col2.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
                        col2.Rows[ultFila].DefaultCellStyle.ForeColor = Color.Tomato;
                    }
                }
                col2.Sort(new RowComparer(System.Windows.Forms.SortOrder.Descending));
                col2.ClearSelection();
                //DataGridViewCell celda = new myDGVCell();

                //col2.CurrentRow.Cells[0] = celda;

            }
            dataGridView1.Sort(new RowComparer(System.Windows.Forms.SortOrder.Descending));
            dataGridView1.ClearSelection();
            //col2.Sort(new RowComparer(System.Windows.Forms.SortOrder.Descending));
            //this.tableLayoutPanel1.Controls.Add(col2,1,1);
            //this.tableLayoutPanel1.SetRowSpan(col2, 1);
            dataGridView1.Enabled = true;

            //lAviso.Text = "Alarma !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! - Alto: " + dataGridView1.RowTemplate.Height;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            //ControlPaint.DrawBorder(textClave.CreateGraphics(), new Rectangle(textClave.Location, new Size(textClave.Width, textClave.Height)), Color.Red, ButtonBorderStyle.Solid);
            //e.Graphics.DrawRectangle(new Pen(Color.Red,2.0f), 0, 0, (textUsuario.Width + 1), (textUsuario.Height + 1));
            //e.Graphics.DrawLine(new Pen(Color.Red, 2.0f), 0, 0, 600, 600);
        }


        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if(e.RowIndex == -1 && e.ColumnIndex == 2){
            //    Image InfoIcon = Image.FromFile(@"C:\wamp\www\Hermes\assets\backend\images\trash.png"); 
            //    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);
            //    e.Graphics.DrawImage(InfoIcon, new Rectangle(e.CellBounds.Location.X, e.CellBounds.Location.Y, 20, 20));
            //    e.Handled = true;
            //}
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (GestorTeclado.ProcesarTecla(keyData, this))
                return true;
            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            //if (!cuadricula)
            //{
            //    //cuadricula = true;
            //    Rectangle rec = dataGridView1.Bounds;
            //    using (Graphics gr = e.Graphics)//this.dataGridView1.CreateGraphics())
            //    {
            //        this.SuspendLayout();
            //        gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Right - 1, rec.Top - dataGridView1.ColumnHeadersHeight), new Point(rec.Right - 1, rec.Bottom));
            //        gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Left, rec.Top + 2 - dataGridView1.ColumnHeadersHeight), new Point(rec.Right + tableLayoutPanel1.Controls["col2"].Width, rec.Top + 2 - dataGridView1.ColumnHeadersHeight));
            //        this.ResumeLayout(true);

            //    }
            //}
            //if (e.IsLastVisibleRow)
            //    cuadricula = true;
            //Rectangle rec = e.ClipRectangle;
            //this.SuspendLayout();

            //using (Graphics gr = this.dataGridView1.CreateGraphics())
            //{
            //    gr.DrawLine(new Pen(Color.Black, 1), new Point(rec.Right-1, rec.Top), new Point(rec.Right-1, rec.Bottom));
            //    //gr.DrawRectangle(Pens.Black, rec);
            //    this.ResumeLayout(false);
            //}
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //if (!cuadricula)
            //{
            //    //cuadricula = true;
            //    Rectangle rec = dataGridView1.Bounds;
            //    rec.X = rec.Y = 0;
            //    ControlPaint.DrawBorder(this.dataGridView1.CreateGraphics(), rec, Color.Black, ButtonBorderStyle.Solid);
            //    //using (Graphics gr = this.dataGridView1.CreateGraphics())
            //    //{

            //    //    gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Right - 1, 0), new Point(rec.Right - 1, rec.Bottom));
            //    //    //gr.DrawLine(new Pen(Color.Black, 2), new Point(rec.Left, rec.Top + 2 - dataGridView1.ColumnHeadersHeight), new Point(rec.Right + tableLayoutPanel1.Controls["col2"].Width, rec.Top + 2 - dataGridView1.ColumnHeadersHeight));

            //    //}
            //}
            ////if (e.IsLastVisibleRow)
            ////    cuadricula = true;

        }



        private void dataGridView1_CellPainting_1(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //Rectangle rec = dataGridView1.Bounds;
            //rec.X = rec.Y = 0;
            //if(e.ColumnIndex==5)
            //    ControlPaint.DrawBorder(this.dataGridView1.CreateGraphics(), rec, Color.Black, ButtonBorderStyle.Solid);
        }

        //private void dataGridView1_Paint_1(object sender, PaintEventArgs e)
        //{
        //    Rectangle rec = dataGridView1.Bounds;
        //    rec.X = rec.Y = 0;

        //        ControlPaint.DrawBorder(this.dataGridView1.CreateGraphics(), rec, Color.Black, ButtonBorderStyle.Solid);
        //}

        private void timerHora_Tick(object sender, EventArgs e)
        {
            labelHora.Text = "Hora: " + DateTime.Now.ToString("HH:mm:ss");
            labelFecha.Text = "Fecha: " + DateTime.Now.ToString("dd / MM / yyyy");
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
                if (textClave.Text == "" || int.TryParse(textClave.Text,out clave) == false)
                    textClave.Text = "0";

                conserjeActual = Conserje.Login(usuario,clave);
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
            if (textClave.Visible)
            {
                textUsuario.Focus();
                int ancho = 1;
                e.Graphics.DrawRectangle(new Pen(Color.Chocolate, ancho+2), textUsuario.Bounds.X - ancho, textUsuario.Bounds.Y - ancho, textUsuario.Bounds.Width+ancho,textUsuario.Bounds.Height+ancho);
                e.Graphics.DrawRectangle(new Pen(Color.Chocolate, ancho + 2), textClave.Bounds.X - ancho, textClave.Bounds.Y - ancho, textClave.Bounds.Width + ancho, textClave.Bounds.Height + ancho);
                e.Graphics.DrawRectangle(new Pen(Color.Chocolate, ancho+2), textClave.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(panelDatosHotel.BackColor), e.ClipRectangle);
            }
        }

    }
}


class RowComparer : System.Collections.IComparer
{
    private static int sortOrderModifier = 1;
    public RowComparer(System.Windows.Forms.SortOrder sortOrder)
    {
        if (sortOrder == System.Windows.Forms.SortOrder.Descending)
        {
            sortOrderModifier = -1;
        }
        else if (sortOrder == System.Windows.Forms.SortOrder.Ascending)
        {
            sortOrderModifier = 1;
        }
    }
    public int Compare(object x, object y)
    {
        DataGridViewRow DataGridViewRow1 = (DataGridViewRow)x;
        DataGridViewRow DataGridViewRow2 = (DataGridViewRow)y;
        // Try to sort based on the Last Name column.
        int CompareResult = System.String.Compare(
            DataGridViewRow1.Cells["estado"].Value.ToString(),
            DataGridViewRow2.Cells["estado"].Value.ToString());
        // If the Last Names are equal, sort based on the First Name.
        if (CompareResult == 0)
        {
            CompareResult = System.String.Compare(
                DataGridViewRow2.Cells["salida"].Value.ToString(),
                DataGridViewRow1.Cells["salida"].Value.ToString());
            if (CompareResult == 0)
            {
                CompareResult = System.String.CompareOrdinal(
                DataGridViewRow2.Cells["nroHab"].Value.ToString(),
                DataGridViewRow1.Cells["nroHab"].Value.ToString());
            }
        }
        return CompareResult * sortOrderModifier;
    }
}


