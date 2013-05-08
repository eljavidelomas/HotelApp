using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using Hoteles.Properties;

namespace Hoteles.Entities
{
    public static class tools
    {
        public static int altoFilaBar = 35;
        public static int minCantFilas = 8;
        public static Font fuenteLabelNroHab = new System.Drawing.Font("Book Antiqua", 22F, System.Drawing.FontStyle.Bold);
        public static Padding margenPanelIngresoDatos = new System.Windows.Forms.Padding(5);
        public static Padding paddingPanelIngresoDatos = new System.Windows.Forms.Padding(0, 25, 0, 20);
        public static Color backColorDetallesHab = Color.Snow;
        public static Font fuenteConfirma = new Font("Palatino Linotype", 22, FontStyle.Bold);

        public static DataTable listadoTurnos()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter Adapter = new SqlDataAdapter("listaTurnos_2", fPrincipal2.conn);
            Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            Adapter.SelectCommand.Parameters.AddWithValue("@orden", tools.obtenerParametroString("ordenListado"));
            Adapter.Fill(ds);

            return ds.Tables[0];

        }

        public static void actualizarListadoTurnos(DataGridView dgv1, DataGridView dgv2)
        {
            DataTable dt = tools.listadoTurnos();
            DataGridView dgv;
            fPrincipal2.mut.WaitOne();
            int filaActual = 0;
            bool reiniciarCont = true;

            borrarIconosAlarmasSonando(dgv1);
            borrarIconosAlarmasSonando(dgv2);

            foreach (DataRow dr in dt.Rows)
            {
                if (reiniciarCont && filaActual < fPrincipal2.maxFilas)
                    dgv = dgv1;
                else
                {
                    dgv = dgv2;

                    if (reiniciarCont)
                    {
                        reiniciarCont = false;
                        filaActual = 0;
                    }
                }

                if ((dgv1.Rows.Count + dgv2.Rows.Count) == dt.Rows.Count)// Si hay datos, los actualizo,
                    dgv.Rows[filaActual].SetValues(dr["nroHabitacion"], dr["categoria2"].ToString() == "" ? dr["categoria"] : dr["categoria2"]);
                else
                {
                    dgv.Rows.Add(dr["nroHabitacion"], dr["categoria2"].ToString() == "" ? dr["categoria"] : dr["categoria2"]);
                    filaActual = dgv.Rows.GetLastRow(DataGridViewElementStates.None);
                }
                

                if (dr["estado"].ToString() == "A" || dr["estado"].ToString() == "O")
                {
                    if (!fPrincipal2.dicAlarmasSonando.ContainsKey(int.Parse(dr["nroHabitacion"].ToString())))// Si hay alarmas Sonando, creo el picture box
                    {
                        if (dr["aviso"].ToString() != "")
                            dgv.Rows[filaActual].Cells[4].Value = Resources.relojSonando_2;
                        else
                            dgv.Rows[filaActual].Cells[4].Value = Resources.vacio;
                    }
                }

                dgv.Rows[filaActual].Cells[7].Value = String.Format("{0:C}", dr["importe"]);
                dgv.Rows[filaActual].Cells[6].Value = "";// h.Sal 
                dgv.Rows[filaActual].Cells[2].Value = ((System.Drawing.Image)Resources.vacio);//bar
                dgv.Rows[filaActual].Cells[3].Value = ((System.Drawing.Image)Resources.vacio);//acc
                dgv.Rows[filaActual].Cells[4].Value = ((System.Drawing.Image)Resources.vacio);//alarma
                dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.vacio);//luz
                dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Green;
                dgv.Rows[filaActual].Cells[0].Style.ForeColor = Color.Black;

                if (dr["estado"].ToString() == "D") // Disponible
                {
                    dgv.Rows[filaActual].Cells[8].Value = "D";                                      
                }
                else if (dr["estado"].ToString() == "A") // Asignada
                {
                    dgv.Rows[filaActual].Cells[8].Value = "A";
                    dgv.Rows[filaActual].Cells[6].Value = (DateTime.Parse(dr["hsalida"].ToString())).ToString("HH:mm");
                    dgv.Rows[filaActual].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);                    
                    dgv.Rows[filaActual].Cells[2].Value = Resources.bar;
                    dgv.Rows[filaActual].Cells[3].Value = Resources.aac;
                }
                else if (dr["estado"].ToString() == "O") // Ocupada
                {
                    dgv.Rows[filaActual].Cells[8].Value = "O";
                    dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.luzOn);
                    dgv.Rows[filaActual].Cells[6].Value = (DateTime.Parse(dr["hsalida"].ToString())).ToString("HH:mm");
                    dgv.Rows[filaActual].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);
                    dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Tomato;

                }
                else if (dr["estado"].ToString() == "M") // Mucama
                {
                    dgv.Rows[filaActual].Cells[8].Value = "M"; // Mucama
                    dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.luzOn);
                    dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Yellow;
                }
                else // Otro...
                {
                    //dgv.Rows[filaActual].DefaultCellStyle.BackColor = Color.Gainsboro;
                    dgv.Rows[filaActual].Cells[8].Value = "X"; // deshabilitado
                    dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.vacio);
                    dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Gainsboro;
                }

                filaActual++;

            }
            dgv1.ClearSelection();
            dgv2.ClearSelection();

            fPrincipal2.mut.ReleaseMutex();
        }

        public static void borrarIconosAlarmasSonando(DataGridView dgv)
        {
            List<Control> lis = new List<Control>();
            foreach (Control item in dgv.Controls)
            {
                if (item.GetType() == typeof(PictureBox))
                {
                    if (((PictureBox)item).Tag != null && ((PictureBox)item).Tag.ToString() == "alarmaSonando")
                    {
                        lis.Add(item);
                    }
                }
            }
            foreach (Control c in lis)
            {
                dgv.Controls.Remove(c);
            }

        }

        static public PictureBox crearPB_AlarmaSonando(DataGridViewRow fila)
        {            
            PictureBox pb = new PictureBox();
            pb.Size = fila.DataGridView.GetCellDisplayRectangle(4, 0, true).Size;
            pb.Image = Resources.relojSonando_2;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Tag = "alarmaSonando";
            pb.BackColor = Color.Transparent;
            pb.Name = "as";
            pb.Location = fila.DataGridView.GetCellDisplayRectangle(4, fila.Index, true).Location;

            return pb;
        }

        public static int calcularAltoFila(DataGridView dataGridView1, int cantFilas, int maxFilas)
        {
            if (cantFilas > maxFilas)
                cantFilas = maxFilas + 1;
            return (dataGridView1.Height - dataGridView1.ColumnHeadersHeight) / cantFilas;
        }

        public static void calcularAlturas(int D, float cantFilas, out int altoFila, out int altoFilaExtra)
        {
            altoFila = (int)(D / cantFilas);
            int to = (int)(cantFilas * altoFila);
            altoFilaExtra = D - to;
        }

        public static DataGridView CopyDataGridView(DataGridView dgv_in, DataGridView dgv_out)
        {
            //DataGridView dgv_copy = new DataGridView();
            try
            {
                if (dgv_out.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgv_in.Columns)
                    {
                        dgv_out.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgv_in.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgv_in.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgv_in.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }
                    dgv_out.Rows.Add(row);
                }
                dgv_out.AllowUserToAddRows = false;
                dgv_out.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Copy DataGridViw" + ex.Message);
            }
            return dgv_out;
        }

        public static FlowLayoutPanel crearFormIngreso()
        {
            FlowLayoutPanel fIngresos = new System.Windows.Forms.FlowLayoutPanel();
            Label lTitulo = new Label();

            fIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            fIngresos.Controls.Add(lTitulo);

            fIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            //fIngresos.Location = new System.Drawing.Point(323, 403);
            fIngresos.Name = "fIngresos";
            //fIngresos.Size = new System.Drawing.Size(314, 49);
            fIngresos.TabIndex = 6;

            return fIngresos;

        }

        internal static void completarDG(DataGridView dgv, int altoFilaExtra)
        {
            int cantFilas = dgv.Rows.Count;
            if (dgv.Rows.Count < tools.minCantFilas)
            {
                for (int i = tools.minCantFilas; i - cantFilas > 0; i--)
                {
                    dgv.Rows.Add();
                }
            }
            if (altoFilaExtra > 0)
                dgv.Rows[dgv.Rows.GetLastRow(DataGridViewElementStates.None)].Height += altoFilaExtra;
        }

        public static string obtenerParametroString(string parametro)
        {
            SqlCommand comm;
            comm = new SqlCommand("select val1_string from parametros where nombre = '" + parametro + "'", fPrincipal2.conn);

            return comm.ExecuteScalar().ToString();
        }

        public static int obtenerParametroInt(string parametro)
        {
            SqlCommand comm;
            int result = 0;
            comm = new SqlCommand("select val1 from parametros where nombre = '" + parametro + "'", fPrincipal2.conn);

            int.TryParse(comm.ExecuteScalar().ToString(), out result);

            return result;
        }


    }
}
