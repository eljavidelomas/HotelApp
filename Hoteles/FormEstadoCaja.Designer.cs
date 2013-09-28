using Hoteles.Entities;
namespace Hoteles
{
    partial class FormEstadoCaja
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCaja = new System.Windows.Forms.DataGridView();
            this.mensajes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.detalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.mediosDePagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hoteles.hotelDataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.opcionesAsignarHabitacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet2 = new Hoteles.hotelDataSet2();
            this.opcionesAsignarHabitacionTableAdapter = new Hoteles.hotelDataSet2TableAdapters.OpcionesAsignarHabitacionTableAdapter();
            this.mediosDePagoTableAdapter = new Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter();
            this.panelGlobal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediosDePagoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesAsignarHabitacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGlobal
            // 
            this.panelGlobal.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.panelGlobal, 2);
            this.panelGlobal.Controls.Add(this.tableLayoutPanel2);
            this.panelGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGlobal.Location = new System.Drawing.Point(105, 49);
            this.panelGlobal.Margin = new System.Windows.Forms.Padding(0);
            this.panelGlobal.Name = "panelGlobal";
            this.tableLayoutPanel1.SetRowSpan(this.panelGlobal, 2);
            this.panelGlobal.Size = new System.Drawing.Size(1153, 637);
            this.panelGlobal.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgvCaja, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dgvTurnos, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelTitulo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelMensaje, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.95447F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.97488F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.91366F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1153, 637);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // dgvCaja
            // 
            this.dgvCaja.AllowUserToAddRows = false;
            this.dgvCaja.AllowUserToDeleteRows = false;
            this.dgvCaja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCaja.BackgroundColor = System.Drawing.Color.White;
            this.dgvCaja.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaja.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCaja.ColumnHeadersHeight = 50;
            this.dgvCaja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mensajes});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCaja.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCaja.Location = new System.Drawing.Point(581, 113);
            this.dgvCaja.Margin = new System.Windows.Forms.Padding(5);
            this.dgvCaja.Name = "dgvCaja";
            this.dgvCaja.ReadOnly = true;
            this.dgvCaja.RowHeadersVisible = false;
            this.dgvCaja.RowTemplate.Height = 60;
            this.dgvCaja.ShowCellErrors = false;
            this.dgvCaja.ShowCellToolTips = false;
            this.dgvCaja.ShowEditingIcon = false;
            this.dgvCaja.ShowRowErrors = false;
            this.dgvCaja.Size = new System.Drawing.Size(567, 423);
            this.dgvCaja.TabIndex = 6;
            // 
            // mensajes
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mensajes.DefaultCellStyle = dataGridViewCellStyle2;
            this.mensajes.FillWeight = 169.5432F;
            this.mensajes.HeaderText = "Caja";
            this.mensajes.Name = "mensajes";
            this.mensajes.ReadOnly = true;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.AllowUserToResizeColumns = false;
            this.dgvTurnos.AllowUserToResizeRows = false;
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnos.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvTurnos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTurnos.ColumnHeadersHeight = 50;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detalles});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurnos.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTurnos.Location = new System.Drawing.Point(5, 113);
            this.dgvTurnos.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.RowHeadersVisible = false;
            this.dgvTurnos.RowHeadersWidth = 20;
            this.dgvTurnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvTurnos.RowTemplate.Height = 60;
            this.dgvTurnos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(566, 423);
            this.dgvTurnos.TabIndex = 0;
            // 
            // detalles
            // 
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.detalles.DefaultCellStyle = dataGridViewCellStyle5;
            this.detalles.HeaderText = "Turnos";
            this.detalles.Name = "detalles";
            this.detalles.ReadOnly = true;
            // 
            // labelTitulo
            // 
            this.labelTitulo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.labelTitulo, 2);
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitulo.Font = new System.Drawing.Font("MV Boli", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Image = global::Hoteles.Properties.Resources.cajareg;
            this.labelTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitulo.Location = new System.Drawing.Point(5, 5);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(5);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Padding = new System.Windows.Forms.Padding(10);
            this.labelTitulo.Size = new System.Drawing.Size(1143, 98);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Estado de Caja";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMensaje
            // 
            this.labelMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.labelMensaje, 2);
            this.labelMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMensaje.Font = new System.Drawing.Font("MV Boli", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMensaje.Location = new System.Drawing.Point(5, 546);
            this.labelMensaje.Margin = new System.Windows.Forms.Padding(5);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(1143, 86);
            this.labelMensaje.TabIndex = 5;
            this.labelMensaje.Text = "Presione ESC para volver al menu principal";
            this.labelMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.834101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.78188F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.62519F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.605223F));
            this.tableLayoutPanel1.Controls.Add(this.panelGlobal, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.804124F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.8866F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.94845F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.773196F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1350, 730);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // opcionesAsignarHabitacionBindingSource
            // 
            this.opcionesAsignarHabitacionBindingSource.DataMember = "OpcionesAsignarHabitacion";
            this.opcionesAsignarHabitacionBindingSource.DataSource = this.hotelDataSet2;
            // 
            // hotelDataSet2
            // 
            this.hotelDataSet2.DataSetName = "hotelDataSet2";
            this.hotelDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opcionesAsignarHabitacionTableAdapter
            // 
            this.opcionesAsignarHabitacionTableAdapter.ClearBeforeFill = true;
            // 
            // mediosDePagoTableAdapter
            // 
            this.mediosDePagoTableAdapter.ClearBeforeFill = true;
            // 
            // FormEstadoCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormEstadoCaja";
            this.Text = "FormAsignar";
            this.Load += new System.EventHandler(this.FormAsignarHab_Load);
            this.panelGlobal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediosDePagoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opcionesAsignarHabitacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelMensaje;
        internal System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private hotelDataSet2 hotelDataSet2;
        private System.Windows.Forms.BindingSource opcionesAsignarHabitacionBindingSource;
        private Hoteles.hotelDataSet2TableAdapters.OpcionesAsignarHabitacionTableAdapter opcionesAsignarHabitacionTableAdapter;
        private hotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource mediosDePagoBindingSource;
        private Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter mediosDePagoTableAdapter;
        private System.Windows.Forms.DataGridView dgvCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajes;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalles;
        
        
        
        
    }
}