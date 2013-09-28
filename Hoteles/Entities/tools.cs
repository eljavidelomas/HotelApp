using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using Hoteles.Properties;
using System.Threading;

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
        public static Color backColorTableLayout = Color.DimGray;
        public static Color backColorTitulo = Color.White;
        public static Color backColorMsjError = Color.White;
        public static Color backColorIngresoDatos = SystemColors.ControlLightLight;
        public static Font fuenteConfirma = new Font("Palatino Linotype", 22, FontStyle.Bold);
        public static string dirAudio = tools.obtenerParametroString("directorioAudio");

        public static DataTable listadoTurnos()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter Adapter = new SqlDataAdapter("listaTurnos_2", fPrincipal2.conn);
                Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                Adapter.SelectCommand.Parameters.AddWithValue("@orden", tools.obtenerParametroString("ordenListado"));
                Adapter.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD("Error en obtener Listado de turno.\r\n" + ex.Message + "-" + ex.StackTrace);
                throw ex;
            }
        }

        public static void actualizarListadoTurnos(DataGridView dgv1, DataGridView dgv2)
        {
            DataTable dt = tools.listadoTurnos();
            DataGridView dgv;

            fPrincipal2.mut.WaitOne();

            try
            {
                int filaActual = 0;
                bool reiniciarCont = true;

                borrarIconosAlarmasSonando(dgv1);
                borrarIconosAlarmasSonando(dgv2);

                //fPrincipal2.borrarPicturesBoxesParpadeo(dgv1, dgv2);

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
                    /*--- Logica por si el importe es negativo ---*/
                    decimal importeAux;
                    decimal.TryParse(dr["importe"].ToString(), out importeAux);
                    if (importeAux < 0)
                        dgv.Rows[filaActual].Cells[7].Value = String.Format("{0:C}", 0);
                    else
                        dgv.Rows[filaActual].Cells[7].Value = String.Format("{0:C}", dr["importe"]);
                    dgv.Rows[filaActual].Cells[6].Value = "";// h.Sal 
                    dgv.Rows[filaActual].Cells[2].Value = ((System.Drawing.Image)Resources.vacio);//bar
                    dgv.Rows[filaActual].Cells[3].Value = ((System.Drawing.Image)Resources.vacio);//acc
                    dgv.Rows[filaActual].Cells[4].Value = ((System.Drawing.Image)Resources.vacio);//alarma
                    dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.vacio);//luz
                    dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Green;

                    /*--------------------------- Color de los Avisos  -------------------*/

                    if (dr["avisoVerdad"].ToString() != "")
                    {
                        Color color = new Color();
                        switch (dr["avisoVerdad"].ToString())
                        {
                            case "1":
                                color = Color.Red;
                                break;
                            case "2":
                                color = Color.Green;
                                break;
                            case "3":
                                color = Color.Yellow;
                                break;
                            case "4":
                                color = Color.Blue;
                                break;
                            case "5":
                                color = Color.Black;
                                break;
                        }

                        dgv.Rows[filaActual].Cells[4].Style.BackColor = color;
                    }
                    else
                        dgv.Rows[filaActual].Cells[4].Style.BackColor = dgv.DefaultCellStyle.BackColor;
                    //---------------------------------------------------------------------//


                    /*---------------------------  Dibujo Alarma -------------------------*/

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
                    //---------------------------------------------------------------------//



                    if (dr["estado"].ToString() == "D") // Disponible
                    {
                        dgv.Rows[filaActual].Cells[8].Value = "D";
                    }


                    else if (dr["estado"].ToString() == "A") // Asignada
                    {
                        dgv.Rows[filaActual].Cells[8].Value = "A";
                        dgv.Rows[filaActual].Cells[6].Value = (DateTime.Parse(dr["hsalida"].ToString())).ToString("HH:mm");
                        if (dgv.Rows[filaActual].Cells.Count > 9)
                            dgv.Rows[filaActual].Cells[9].Value = DateTime.Parse(dr["hsalida"].ToString());
                        dgv.Rows[filaActual].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);
                        dgv.Rows[filaActual].Cells[2].Value = Resources.bar;
                        dgv.Rows[filaActual].Cells[3].Value = Resources.aac;
                    }


                    else if (dr["estado"].ToString() == "O") // Ocupada
                    {
                        dgv.Rows[filaActual].Cells[8].Value = "O";
                        dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.luzOn);
                        dgv.Rows[filaActual].Cells[6].Value = (DateTime.Parse(dr["hsalida"].ToString())).ToString("HH:mm");
                        if (dgv.Rows[filaActual].Cells.Count > 9)
                            dgv.Rows[filaActual].Cells[9].Value = DateTime.Parse(dr["hsalida"].ToString());
                        dgv.Rows[filaActual].DefaultCellStyle.Font = new Font(dgv.DefaultCellStyle.Font, FontStyle.Bold);
                        dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Tomato;

                    }


                    else if (dr["estado"].ToString() == "M") // Mucama
                    {
                        dgv.Rows[filaActual].Cells[8].Value = "M"; // Mucama
                        dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.luzOn);
                        dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Yellow;
                        dgv.Rows[filaActual].Cells[0].Style.ForeColor = Color.Black;
                    }


                    else // Otro...
                    {
                        //dgv.Rows[filaActual].DefaultCellStyle.BackColor = Color.Gainsboro;
                        dgv.Rows[filaActual].Cells[8].Value = "X"; // deshabilitado
                        dgv.Rows[filaActual].Cells[5].Value = ((System.Drawing.Image)Resources.vacio);
                        dgv.Rows[filaActual].Cells[0].Style.BackColor = Color.Gainsboro;
                        dgv.Rows[filaActual].Cells[0].Style.ForeColor = Color.Black;
                    }

                    filaActual++;

                }
                dgv1.ClearSelection();
                dgv2.ClearSelection();
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(ex.Message + " - " + ex.StackTrace);
            }

            fPrincipal2.mut.ReleaseMutex();

            //((fPrincipal2)dgv1.FindForm()).timerParpadeo_Tick(null, EventArgs.Empty);
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

        public static decimal redondeo(decimal monto)
        {
            decimal f = decimal.Parse(tools.obtenerParametroString("redondeo"));
            int fEnt = (int)f;
            decimal fDec = f - fEnt;
            int montoEnt = (int)monto;
            decimal montoDec = monto - montoEnt;
            decimal cantVeces = montoDec / (1 / (decimal)fEnt);
            decimal cantVecesDec = cantVeces < 1 ? 0 : cantVeces % (int)cantVeces;
            if (fDec == 0 || cantVecesDec <= fDec)
                cantVeces = Math.Floor(cantVeces);
            else
                cantVeces = Math.Ceiling(cantVeces);

            decimal resDecimal = (cantVeces / fEnt);

            return montoEnt + resDecimal;
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
            
            if (parametro == "directorioAudio")
            {
                string salida = comm.ExecuteScalar().ToString();
                salida = salida.EndsWith("\\") ? salida : salida + '\\';
                return salida;
            }

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
        public static int obtenerParametroInt(string parametro, SqlConnection conn, SqlTransaction tran)
        {
            SqlCommand comm;
            int result = 0;
            comm = new SqlCommand("select val1 from parametros where nombre = '" + parametro + "'", conn);
            comm.Transaction = tran;

            int.TryParse(comm.ExecuteScalar().ToString(), out result);

            return result;
        }

    }
}
