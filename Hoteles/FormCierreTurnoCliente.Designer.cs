using Hoteles.Entities;
namespace Hoteles
{
    partial class FormCierreTurnoCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.panelPromos = new System.Windows.Forms.Panel();
            this.lblNroHab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetallesTurno = new System.Windows.Forms.DataGridView();
            this.cantArticulos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediosDePagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hoteles.hotelDataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.opcionesAsignarHabitacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mediosDePagoTableAdapter = new Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label4 = new System.Windows.Forms.Label();
            this.lHora = new System.Windows.Forms.Label();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.panelGlobal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelPromos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediosDePagoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesAsignarHabitacionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.panelGlobal, 2);
            this.panelGlobal.Controls.Add(this.tableLayoutPanel2);
            this.panelGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGlobal.Location = new System.Drawing.Point(40, 54);
            this.panelGlobal.Margin = new System.Windows.Forms.Padding(0);
            this.panelGlobal.Name = "panelGlobal";
            this.tableLayoutPanel1.SetRowSpan(this.panelGlobal, 2);
            this.panelGlobal.Size = new System.Drawing.Size(1268, 636);
            this.panelGlobal.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.PaleTurquoise;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.33438F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.66562F));
            this.tableLayoutPanel2.Controls.Add(this.dgvDetallesTurno, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelPromos, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.94969F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.19685F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.83465F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1268, 636);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // lblMonto
            // 
            this.lblMonto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonto.Font = new System.Drawing.Font("Stencil", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMonto.Location = new System.Drawing.Point(5, 517);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(537, 109);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "$ 77.065,25";
            this.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPromos
            // 
            this.panelPromos.Controls.Add(this.label4);
            this.panelPromos.Controls.Add(this.lHora);
            this.panelPromos.Controls.Add(this.lblMonto);
            this.panelPromos.Controls.Add(this.label2);
            this.panelPromos.Controls.Add(this.label1);
            this.panelPromos.Controls.Add(this.lblNroHab);
            this.panelPromos.Controls.Add(this.shapeContainer1);
            this.panelPromos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPromos.Location = new System.Drawing.Point(726, 0);
            this.panelPromos.Margin = new System.Windows.Forms.Padding(0);
            this.panelPromos.Name = "panelPromos";
            this.tableLayoutPanel2.SetRowSpan(this.panelPromos, 3);
            this.panelPromos.Size = new System.Drawing.Size(542, 636);
            this.panelPromos.TabIndex = 8;
            // 
            // lblNroHab
            // 
            this.lblNroHab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNroHab.Font = new System.Drawing.Font("Stencil", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroHab.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNroHab.Location = new System.Drawing.Point(270, 29);
            this.lblNroHab.Margin = new System.Windows.Forms.Padding(5);
            this.lblNroHab.Name = "lblNroHab";
            this.lblNroHab.Size = new System.Drawing.Size(273, 114);
            this.lblNroHab.TabIndex = 6;
            this.lblNroHab.Text = "115";
            this.lblNroHab.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 60F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(9, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(528, 79);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDetallesTurno
            // 
            this.dgvDetallesTurno.AllowUserToAddRows = false;
            this.dgvDetallesTurno.AllowUserToDeleteRows = false;
            this.dgvDetallesTurno.AllowUserToResizeColumns = false;
            this.dgvDetallesTurno.AllowUserToResizeRows = false;
            this.dgvDetallesTurno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesTurno.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.dgvDetallesTurno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetallesTurno.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesTurno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDetallesTurno.ColumnHeadersHeight = 40;
            this.dgvDetallesTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetallesTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantArticulos,
            this.descripcion,
            this.precio});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesTurno.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvDetallesTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetallesTurno.EnableHeadersVisualStyles = false;
            this.dgvDetallesTurno.Location = new System.Drawing.Point(0, 0);
            this.dgvDetallesTurno.Margin = new System.Windows.Forms.Padding(0);
            this.dgvDetallesTurno.Name = "dgvDetallesTurno";
            this.dgvDetallesTurno.ReadOnly = true;
            this.dgvDetallesTurno.RowHeadersVisible = false;
            this.dgvDetallesTurno.RowHeadersWidth = 20;
            this.dgvDetallesTurno.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel2.SetRowSpan(this.dgvDetallesTurno, 3);
            this.dgvDetallesTurno.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvDetallesTurno.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.PaleTurquoise;
            this.dgvDetallesTurno.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetallesTurno.RowTemplate.Height = 30;
            this.dgvDetallesTurno.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesTurno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetallesTurno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesTurno.Size = new System.Drawing.Size(726, 636);
            this.dgvDetallesTurno.TabIndex = 0;
            // 
            // cantArticulos
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantArticulos.DefaultCellStyle = dataGridViewCellStyle10;
            this.cantArticulos.FillWeight = 15F;
            this.cantArticulos.HeaderText = "Cant";
            this.cantArticulos.Name = "cantArticulos";
            this.cantArticulos.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.FillWeight = 65F;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // precio
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precio.DefaultCellStyle = dataGridViewCellStyle11;
            this.precio.FillWeight = 20F;
            this.precio.HeaderText = "Importe";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // mediosDePagoBindingSource
            // 
            this.mediosDePagoBindingSource.DataMember = "mediosDePago";
            this.mediosDePagoBindingSource.DataSource = this.hotelDataSet;
            // 
            // hotelDataSet
            // 
            this.hotelDataSet.DataSetName = "hotelDataSet";
            this.hotelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.74074F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.18518F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3F));
            this.tableLayoutPanel1.Controls.Add(this.panelGlobal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.534246F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.05479F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.34246F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.342466F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 730);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(43, 690);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1262, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Enter - Confirma                    Esc - Cancela";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mediosDePagoTableAdapter
            // 
            this.mediosDePagoTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 80F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(19, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 109);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hab";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(542, 636);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lineShape1.BorderWidth = 3;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 1;
            this.lineShape1.X2 = 1;
            this.lineShape1.Y1 = 1;
            this.lineShape1.Y2 = 636;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(76, 219);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 109);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hora :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lHora
            // 
            this.lHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lHora.Font = new System.Drawing.Font("Stencil", 60F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHora.ForeColor = System.Drawing.Color.Firebrick;
            this.lHora.Location = new System.Drawing.Point(234, 225);
            this.lHora.Margin = new System.Windows.Forms.Padding(0);
            this.lHora.Name = "lHora";
            this.lHora.Size = new System.Drawing.Size(292, 96);
            this.lHora.TabIndex = 9;
            this.lHora.Text = "11:55";
            this.lHora.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.BorderWidth = 3;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 2;
            this.lineShape2.X2 = 540;
            this.lineShape2.Y1 = 418;
            this.lineShape2.Y2 = 418;
            // 
            // FormCierreTurnoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCierreTurnoCliente";
            this.Text = "FormAsignar";
            this.Load += new System.EventHandler(this.FormAsignarHab_Load);
            this.panelGlobal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelPromos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediosDePagoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesAsignarHabitacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvDetallesTurno;
        private System.Windows.Forms.Panel panelPromos;

        private System.Windows.Forms.BindingSource opcionesAsignarHabitacionBindingSource;
        private hotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource mediosDePagoBindingSource;
        private Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter mediosDePagoTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNroHab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lHora;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        
        
        
        
    }
}