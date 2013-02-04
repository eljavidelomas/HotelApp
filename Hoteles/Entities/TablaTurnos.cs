using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using Hoteles.Properties;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    static class TablaTurnos
    {
        static public DataGridView nuevaTabla()
        {

            DataGridViewCellStyle columnHeaderCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle datosCellStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewTextBoxColumn nrohab = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn categoria = new DataGridViewTextBoxColumn();
            DataGridViewImageColumn bar = new DataGridViewImageColumn();
            DataGridViewImageColumn aac = new DataGridViewImageColumn();
            DataGridViewImageColumn alarma = new DataGridViewImageColumn();
            DataGridViewImageColumn luz = new DataGridViewImageColumn();
            DataGridViewTextBoxColumn salida = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn importe = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn estado = new DataGridViewTextBoxColumn();
                       

            // 
            // nrohab
            // 
            //dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            //dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            //nrohab.DefaultCellStyle = dataGridViewCellStyle2;
            nrohab.FillWeight = 56.33804F;
            nrohab.HeaderText = "Nº Hab";
            nrohab.MinimumWidth = 35;
            nrohab.Name = "nrohab";
            nrohab.ReadOnly = true;
            nrohab.Width = 45;
            // 
            // categoria
            // 
            categoria.FillWeight = 79.05887F;
            categoria.HeaderText = "  Cat";
            categoria.Name = "categoria";
            categoria.ReadOnly = true;
            categoria.Width = 63;
            // 
            // bar
            // 
            bar.FillWeight = 63.06764F;
            bar.HeaderText = "Bar";
            bar.Image = Resources.vacio;
            bar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            bar.Name = "bar";
            bar.ReadOnly = true;
            bar.Width = 37;
            // 
            // aac
            // 
            aac.FillWeight = 72.46375F;
            aac.HeaderText = "AAC";
            aac.Image = Resources.vacio;
            aac.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            aac.Name = "aac";
            aac.ReadOnly = true;
            aac.Width = 37;
            // 
            // alarma
            // 
            alarma.FillWeight = 81.30112F;
            alarma.HeaderText = "Ala";
            alarma.Image = Resources.vacio;
            alarma.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            alarma.Name = "alarma";
            alarma.ReadOnly = true;
            alarma.Width = 37;
            // 
            // luz
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;            
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            luz.DefaultCellStyle = dataGridViewCellStyle3;
            luz.FillWeight = 89.61292F;
            luz.HeaderText = "Luz";
            luz.Image = Resources.luzOff3;
            luz.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            luz.Name = "luz";
            luz.ReadOnly = true;
            luz.Width = 37;
            // 
            // salida
            // 
            salida.FillWeight = 161.5295F;
            salida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            salida.HeaderText = "H. Sal";
            salida.Name = "salida";
            salida.ReadOnly = true;
            salida.Width = 129;
            // 
            // importe
            // 
            importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            importe.FillWeight = 196.6283F;
            importe.HeaderText = "Importe";
            importe.Name = "importe";
            importe.ReadOnly = true;
            importe.Width = 150;
            // 
            // estado
            // 
            estado.HeaderText = "estado";
            estado.Name = "estado";
            estado.ReadOnly = true;
            estado.Visible = false;
            // 


            columnHeaderCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnHeaderCellStyle.Padding = new Padding(0);
            columnHeaderCellStyle.BackColor = System.Drawing.SystemColors.Control;
            columnHeaderCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            columnHeaderCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            columnHeaderCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            columnHeaderCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            columnHeaderCellStyle.WrapMode = DataGridViewTriState.True;

            datosCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            datosCellStyle.Padding = new Padding(0);
            datosCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            datosCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            datosCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            datosCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            datosCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            datosCellStyle.WrapMode = DataGridViewTriState.False;


            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;          
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderCellStyle;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] {
            nrohab,
            categoria,
            bar,
            aac,
            alarma,
            luz,
            salida,
            importe,
            estado});            
            
            dataGridView1.DefaultCellStyle = datosCellStyle;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new System.Drawing.Point(0, 0);
            dataGridView1.Margin = new Padding(0,0,0,0);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "col2";
            dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;            
            dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.False;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.DataSource = null;
            

            return dataGridView1;
        }

        
    }
}
