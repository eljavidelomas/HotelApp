using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using Administrador.Properties;
using System.Threading;
using Administrador.Entities;
using System.Drawing.Printing;

namespace Administrador
{
    public partial class FAdministrador : Form
    {
        public static SqlConnection conn = new SqlConnection(Settings.Default.hotelConnectionString2);
        public static int errorMsj = 0;


        public FAdministrador()
        {
            initConnection();
            InitializeComponent();
        }

        public void initConnection()
        {
            conn.Open();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsCompras.compras' Puede moverla o quitarla según sea necesario.
                this.comprasTableAdapter.Fill(this.dsCompras.compras);
                // TODO: esta línea de código carga datos en la tabla 'dsHabitaciones.habitaciones' Puede moverla o quitarla según sea necesario.
                this.habitacionesTableAdapter.Fill(this.dsHabitaciones.habitaciones);
                // TODO: esta línea de código carga datos en la tabla 'dsRopaHotel.ropaHotel' Puede moverla o quitarla según sea necesario.
                this.ropaHotelTableAdapter.Fill(this.dsRopaHotel.ropaHotel);
                // TODO: esta línea de código carga datos en la tabla 'dsTiposCuentasGastos.tiposCuentasGastos' Puede moverla o quitarla según sea necesario.
                this.tiposCuentasGastosTableAdapter.Fill(this.dsTiposCuentasGastos.tiposCuentasGastos);
                // TODO: esta línea de código carga datos en la tabla 'dsPromociones.descuentos' Puede moverla o quitarla según sea necesario.
                this.descuentosTableAdapter1.Fill(this.dsPromociones.descuentos);
                // TODO: esta línea de código carga datos en la tabla 'dsDescuentos.descuentos' Puede moverla o quitarla según sea necesario.
                this.descuentosTableAdapter.Fill(this.dsDescuentos.descuentos);
                // TODO: esta línea de código carga datos en la tabla 'dsDias.dias' Puede moverla o quitarla según sea necesario.
                this.diasTableAdapter.Fill(this.dsDias.dias);
                // TODO: esta línea de código carga datos en la tabla 'dsTarifas.tarifas' Puede moverla o quitarla según sea necesario.
                this.tarifasTableAdapter.Fill(this.dsTarifas.tarifas);
                // TODO: esta línea de código carga datos en la tabla 'dsArticulosCombo.articulos' Puede moverla o quitarla según sea necesario.
                this.articulosTableAdapter1.Fill(this.dsArticulosCombo.articulos);
                // TODO: esta línea de código carga datos en la tabla 'dsArticulos_combo.articulos_obtenerListado' Puede moverla o quitarla según sea necesario.
                this.articulos_obtenerListadoTableAdapter.Fill(this.dsArticulos_combo.articulos_obtenerListado);
                // TODO: esta línea de código carga datos en la tabla 'dsSocios.socios' Puede moverla o quitarla según sea necesario.
                this.sociosTableAdapter.Fill(this.dsSocios.socios);
                // TODO: esta línea de código carga datos en la tabla 'dsArticulos.articulos' Puede moverla o quitarla según sea necesario.
                this.articulosTableAdapter.Fill(this.dsArticulos.articulos);
                // TODO: esta línea de código carga datos en la tabla 'dsCuentaGastos.cuentasGastos' Puede moverla o quitarla según sea necesario.
                this.cuentasGastosTableAdapter.Fill(this.dsCuentaGastos.cuentasGastos);
                // TODO: esta línea de código carga datos en la tabla 'dsMucamas.mucamas' Puede moverla o quitarla según sea necesario.
                this.mucamasTableAdapter.Fill(this.dsMucamas.mucamas);
                // TODO: esta línea de código carga datos en la tabla 'dsConserjes.conserjes' Puede moverla o quitarla según sea necesario.
                this.conserjesTableAdapter.Fill(this.dsConserjes.conserjes);
                // TODO: esta línea de código carga datos en la tabla 'dsFeriados.feriados' Puede moverla o quitarla según sea necesario.
                this.feriadosTableAdapter.Fill(this.dsFeriados.feriados);
                // TODO: esta línea de código carga datos en la tabla 'hotelDataSet.mediosDePago' Puede moverla o quitarla según sea necesario.
                this.mediosDePagoTableAdapter.Fill(this.dsFormasDePago.mediosDePago);
                // TODO: esta línea de código carga datos en la tabla 'dsCategorias.categorias' Puede moverla o quitarla según sea necesario.
                this.categoriasTableAdapter.Fill(this.dsCategorias.categorias);

                //int valSel = (int) ( listArtCompuestos.SelectedValue== null?0:listArtCompuestos.SelectedValue);
                if(listArtCompuestos.SelectedValue != null)
                    articulosCompuestos_getTableAdapter.Fill(dsCompuestoPor.articulosCompuestos_get, (int)listArtCompuestos.SelectedValue);
                descuentos_ObtenerArticulosByDescuentoIdTableAdapter.Fill(spDescuentosObtenerArticulosByDescId.Descuentos_ObtenerArticulosByDescuentoId, (int)listPromociones.SelectedValue);
                dgvCompuestoPor.ClearSelection();
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + "-" + ex.StackTrace);
            }
        }

        private static DataSet obtenerHabitacion(string p)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + p, FAdministrador.conn);
                dataAdapter.Fill(ds);
            }
            catch
            {
            }

            return ds;
        }


        private void blanquearCampos(ICollection controles, Control excepcion)
        {
            foreach (Control item in controles)
            {
                if (!item.Equals(excepcion) && item.GetType() == typeof(TextBox))
                {
                    item.Text = "";
                }
            }
        }

        private void txtHab_nro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                categoriasTableAdapter.Update(dsCategorias);
                categoriasTableAdapter.Fill(dsCategorias.categorias);
                loadCategorias();                
                lblCat_msjSalida.Visible = false;
            }
            catch (Exception ex)
            {
                lblCat_msjSalida.Visible = true;
                lblCat_msjSalida.ForeColor = Color.Red;
                if (ex.Message.Contains("FK_habitaciones_categorias"))
                {
                    lblCat_msjSalida.Text = "No se puede Eliminar la categoria, ya que esta asignada a alguna Habitación.";
                }
                else
                    lblCat_msjSalida.Text = ex.Message;
                categoriasTableAdapter.Fill(dsCategorias.categorias);
            }
        }

        private void btnTarj_save_Click(object sender, EventArgs e)
        {
            try
            {
                mediosDePagoTableAdapter.Update(dsFormasDePago);
                mediosDePagoTableAdapter.Fill(dsFormasDePago.mediosDePago);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("FK_turnos_mediosDePago"))
                {
                    MessageBox.Show("No se puede borrar el medio de pago por que hay turnos que lo tienen asignado.", "Error");

                }
                mediosDePagoTableAdapter.Fill(dsFormasDePago.mediosDePago);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fecha = monthCalendar1.SelectionStart;
            byte comportamiento = Convert.ToByte(listSeComportaComo.SelectedValue);
            feriadosTableAdapter.Adapter.InsertCommand = new SqlCommand("insert into feriados (mes,dia,seComportaComo) values (" + fecha.Month + " , " + fecha.Day + "," + comportamiento + " )", FAdministrador.conn);
            try
            {
                feriadosTableAdapter.Adapter.InsertCommand.ExecuteNonQuery();
            }
            catch (Exception)
            { };

            feriadosTableAdapter.Fill(dsFeriados.feriados);
        }

        private void dataGridView3_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            dataGridView3.ClearSelection();
        }

        private void dataGridView3_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            feriadosTableAdapter.Adapter.DeleteCommand = new SqlCommand("delete from feriados where mes = " + dsFeriados.feriados.Rows[e.Row.Index][2].ToString() + " and dia = " + dsFeriados.feriados.Rows[e.Row.Index][0].ToString(), FAdministrador.conn);
            feriadosTableAdapter.Adapter.DeleteCommand.ExecuteNonQuery();
        }


        private void btnConserjes_save_Click(object sender, EventArgs e)
        {
            try
            {
                conserjesTableAdapter.Update(dsConserjes);
            }
            catch (Exception ex)
            {
                
            }
            conserjesTableAdapter.Fill(dsConserjes.conserjes);
        }

        private void btnMucamas_save_Click(object sender, EventArgs e)
        {
            mucamasTableAdapter.Update(dsMucamas);
            mucamasTableAdapter.Fill(dsMucamas.mucamas);
        }

        private void btnGastos_save_Click(object sender, EventArgs e)
        {
            cuentasGastosTableAdapter.Update(dsCuentaGastos);
            cuentasGastosTableAdapter.Fill(dsCuentaGastos.cuentasGastos);
        }

        private void btnSocios_save_Click(object sender, EventArgs e)
        {
            try
            {
                sociosTableAdapter.Update(dsSocios);
            }
            catch (Exception ex)
            {
            }
            sociosTableAdapter.Fill(dsSocios.socios);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor;

            if (((ComboBox)sender).SelectedValue != null)
                if (int.TryParse(((ComboBox)sender).SelectedValue.ToString(), out valor))
                    articulosCompuestos_getTableAdapter.Fill(dsCompuestoPor.articulosCompuestos_get, valor);
        }

        private void dgvCompuestoPor_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            articulosCompuestos_getTableAdapter.articulosCompuestos_delete(Convert.ToInt32(e.Row.Cells[2].Value));
        }

        private void btnArtSave_Click(object sender, EventArgs e)
        {            
            articulosTableAdapter.Update(dsArticulos);
            articulosTableAdapter.Fill(dsArticulos.articulos);
            articulosTableAdapter1.Fill(dsArticulosCombo.articulos);
            comboBox1_SelectedIndexChanged(listArtCompuestos, EventArgs.Empty);

        }

        private void articulosBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
             try
            {
                if (((BindingSource)sender).Current != null)
                {
                    if (((BindingSource)sender).Current.GetType() == typeof(DataRowView))
                    {
                        articulosTableAdapter.Update(((DataRowView)((BindingSource)sender).Current).Row);
                        articulosTableAdapter1.Fill(dsArticulosCombo.articulos);
                    }
                }
             }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + "-" + ex.StackTrace);
            }
            dgvCompuestoPor.ClearSelection();
        }

        private void articulosBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            try
            {
                articulosTableAdapter.Update(dsArticulos.articulos);
                articulosTableAdapter1.Fill(dsArticulosCombo.articulos);                
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("null"))
                {
                    MessageBox.Show("\r\nLos campos \"Stock Actual\", \"Stock Recomendado\" y \"Precio\" no puede estar vacios, debe completarlos con Cero.\r\n", "Error al Grabar Datos");                    
                }
            }
            dgvCompuestoPor.ClearSelection();            
        }

        private void btnArtComp_save_Click(object sender, EventArgs e)
        {
            articulosTableAdapter1.Insert(int.Parse(listArtCompuestos.SelectedValue.ToString()), int.Parse(listArtCompId.SelectedValue.ToString()), int.Parse(txtArt_Cant.Text));
            articulosCompuestos_getTableAdapter.Fill(dsCompuestoPor.articulosCompuestos_get, int.Parse(listArtCompuestos.SelectedValue.ToString()));
            dgvCompuestoPor.ClearSelection();
        }

        private void tarifasBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                if (((BindingSource)sender).Current != null)
                {
                    if (((BindingSource)sender).Current.GetType() == typeof(DataRowView))
                    {
                        tarifasTableAdapter.Update(((DataRowView)((BindingSource)sender).Current).Row);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + "-" + ex.StackTrace);
            }
            dgvCompuestoPor.ClearSelection();
        }

        private void tarifasBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            tarifasTableAdapter.Update(dsTarifas.tarifas);
        }

        private void loadCategorias()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("select id,nombre from categorias", FAdministrador.conn);
            adapter.Fill(ds);
            ds.Tables[0].Rows.Add(0, "Ninguna");
        }
                
        private void listPromociones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int valor;

            if (((ComboBox)sender).SelectedValue != null)
                if (int.TryParse(((ComboBox)sender).SelectedValue.ToString(), out valor))
                    descuentos_ObtenerArticulosByDescuentoIdTableAdapter.Fill(spDescuentosObtenerArticulosByDescId.Descuentos_ObtenerArticulosByDescuentoId, valor);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                descuentos_ObtenerArticulosByDescuentoIdTableAdapter.Insert(int.Parse(listArtToInsertPromo.SelectedValue.ToString()), int.Parse(listPromociones.SelectedValue.ToString()));
                descuentos_ObtenerArticulosByDescuentoIdTableAdapter.Fill(spDescuentosObtenerArticulosByDescId.Descuentos_ObtenerArticulosByDescuentoId, int.Parse(listPromociones.SelectedValue.ToString()));
            }
            catch { }
        }

        private void btnPromociones_savePromo_Click(object sender, EventArgs e)
        {
            descuentosTableAdapter1.Update(dsPromociones);
            descuentosTableAdapter1.Fill(dsPromociones.descuentos);
            descuentosTableAdapter.Fill(dsDescuentos.descuentos);
            listPromociones_SelectedIndexChanged(listPromociones, EventArgs.Empty);
        }

        private void listArtToInsertPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)// Si presiono enter en el Combo box, que sea igual a hacer click en boton
            {
                button3_Click(sender, EventArgs.Empty);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            tiposCuentasGastosTableAdapter.Update(dsTiposCuentasGastos);
            tiposCuentasGastosTableAdapter.Fill(dsTiposCuentasGastos.tiposCuentasGastos);
        }

        private void tpLavadero_BtnSave_Click(object sender, EventArgs e)
        {
            ropaHotelTableAdapter.Update(dsRopaHotel);
            ropaHotelTableAdapter.Fill(dsRopaHotel.ropaHotel);
        }

        private void habitacionesBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            try
            {
                if (((BindingSource)sender).Current != null)
                {
                    if (((BindingSource)sender).Current.GetType() == typeof(DataRowView))
                    {
                        habitacionesTableAdapter.Update(((DataRowView)((BindingSource)sender).Current).Row);
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + "-" + ex.StackTrace);
            }
        }

        private void habitacionesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            habitacionesTableAdapter.Update(dsHabitaciones.habitaciones);
        }

      
        private void button4_Click(object sender, EventArgs e)
        {            
            grillaImprimir = dataGridView8;
            prepararImpresion();
        }

        private void prepararImpresion()
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument1;
            printDialog.UseEXDialog = true;
            //Get the document
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                printDocument1.DocumentName = "Listado";
                printDocument1.DefaultPageSettings.Margins = new Margins(15, 15, 40, 0);
                //printDocument1.Print();
                PrintPreviewDialog objPPdialog = new PrintPreviewDialog();
                objPPdialog.Document = printDocument1;
                objPPdialog.ShowDialog();
            }
        }

        #region Member Variables

        StringFormat strFormat; //Used to format the grid rows.
        ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        int iCellHeight = 0; //Used to get/set the datagridview cell height
        int iTotalWidth = 0; //
        int iRow = 0;//Used as counter
        bool bFirstPage = false; //Used to check whether we are printing first page
        bool bNewPage = false;// Used to check whether we are printing a new page
        int iHeaderHeight = 0; //Used for the header height
        DataGridView grillaImprimir;
        #endregion

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;
                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();
                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                // Calculating Total Widths
                iTotalWidth = 0;
                foreach (DataGridViewColumn dgvGridCol in grillaImprimir.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                //Set the left margin
                int iLeftMargin = e.MarginBounds.Left;
                //Set the top margin
                int iTopMargin = e.MarginBounds.Top;
                //Whether more pages have to print or not
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;

                //For the first page to print set the cell width and header height
                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in grillaImprimir.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width /
                                       (double)iTotalWidth * (double)iTotalWidth *
                                       ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText,
                                    GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        // Save width and height of headres
                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }
                //Loop till all the grid rows not get printed
                while (iRow <= grillaImprimir.Rows.Count - 1)
                {
                    DataGridViewRow GridRow = grillaImprimir.Rows[iRow];
                    //Set the cell height
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0;
                    //Check whether the current page settings allo more rows to print
                    if (iTopMargin + iCellHeight >= e.MarginBounds.Height + e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                           
                            String strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
                            //Draw Date
                            e.Graphics.DrawString(strDate, new Font(grillaImprimir.Font, FontStyle.Bold),
                                    Brushes.Black, e.MarginBounds.Left + (e.MarginBounds.Width -
                                    e.Graphics.MeasureString(strDate, new Font(grillaImprimir.Font,
                                    FontStyle.Bold), e.MarginBounds.Width).Width), e.MarginBounds.Top -
                                    e.Graphics.MeasureString("Customer Summary", new Font(new Font(grillaImprimir.Font,
                                    FontStyle.Bold), FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            //Draw Columns                 
                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in grillaImprimir.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray),
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black,
                                    new Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                if (GridCol.HeaderText.ToLower().Contains("categor"))
                                    GridCol.HeaderText = "Cat";
                                if (GridCol.HeaderText.ToLower().Contains("extension"))
                                    GridCol.HeaderText = "Ext.";

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font,
                                    new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);
                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        //Draw Columns Contents                
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value != null)
                            {
                                //Cel.GetType() == typeof(DataGridViewComboBoxCell) ? Cel.FormattedValue.ToString() : Cel.Value.ToString()
                                e.Graphics.DrawString(Cel.FormattedValue.ToString(),
                                            Cel.InheritedStyle.Font,
                                            new SolidBrush(Cel.InheritedStyle.ForeColor),
                                            new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin,
                                            (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }
                            //Drawing Cells Borders 
                            e.Graphics.DrawRectangle(Pens.Black, new Rectangle((int)arrColumnLefts[iCount],
                                    iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));

                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;
                }

                //If more lines exist, print another page.
                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grillaImprimir = dataGridView1;
            prepararImpresion();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            grillaImprimir = dataGridView7;
            prepararImpresion();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            grillaImprimir = dataGridView5;
            prepararImpresion();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            grillaImprimir = dgvSocios;
            prepararImpresion();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            grillaImprimir = dataGridView6;
            prepararImpresion();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            grillaImprimir = dataGridView4;
            prepararImpresion();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            grillaImprimir = dgvConserjes;
            prepararImpresion();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            grillaImprimir = dgvMucamas;
            prepararImpresion();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            grillaImprimir = dataGridView3;
            prepararImpresion();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            grillaImprimir = dataGridView2;
            prepararImpresion();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            grillaImprimir = dgvTarifas;
            prepararImpresion();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            grillaImprimir = dgvArticulos;
            prepararImpresion();
        }

        private void button17_Click(object sender, EventArgs e)//Compras
        {
            int Compras = (int)nCompra.Value;
            int Reposicion = (int)nReposicion.Value;
            string comentario = txtComentario.Text;
            DateTime fecha = dpFecha.Value;
            int idArticulo = (int)cbArticulo.SelectedValue;
            string descripcion = cbArticulo.Text;
                        
            try
            {
                SqlCommand comm = new SqlCommand("compras_insertar", FAdministrador.conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@articuloId", idArticulo);
                comm.Parameters.AddWithValue("@descripcion", descripcion);
                comm.Parameters.AddWithValue("@fecha", fecha);
                comm.Parameters.AddWithValue("@comentario", comentario);
                comm.Parameters.AddWithValue("compra", Compras);
                comm.Parameters.AddWithValue("reposicion", Reposicion);
                if (nPrecioUnit.Value > 0)
                    comm.Parameters.AddWithValue("precioU", nPrecioUnit.Value);
                comm.ExecuteNonQuery();

                //Actualizo tabla
                comprasTableAdapter.Fill(dsCompras.compras);

                //Limpio campos
                txtComentario.Clear();
                nReposicion.Value = 0;
                nCompra.Value = 0;
                nPrecioUnit.Value = 0;
                cbArticulo.SelectedIndex = 0;
                cbArticulo.Focus();

            }
            catch (Exception ex)
            {
                LoggerProxy.ErrorSinBD(ex.Message + " - " + ex.StackTrace);
            }

        }

        private void nCompra_Enter(object sender, EventArgs e)
        {
            nCompra.ResetText();
        }

    }
}
