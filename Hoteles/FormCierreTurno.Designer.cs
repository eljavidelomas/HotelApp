using Hoteles.Entities;
namespace Hoteles
{
    partial class FormCierreTurno
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOpcionesElegidas = new System.Windows.Forms.DataGridView();
            this.detalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.panelIngresoDatos = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNroHab = new System.Windows.Forms.Label();
            this.tbNroHab = new System.Windows.Forms.TextBox();
            this.panelPromos = new System.Windows.Forms.Panel();
            this.dgvMedioPago = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediosDePagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hoteles.hotelDataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.opcionesAsignarHabitacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mediosDePagoTableAdapter = new Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter();
            this.panelGlobal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcionesElegidas)).BeginInit();
            this.panelIngresoDatos.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelPromos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedioPago)).BeginInit();
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
            this.tableLayoutPanel2.Controls.Add(this.dgvOpcionesElegidas, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelTitulo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelMensaje, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelIngresoDatos, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelPromos, 1, 1);
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
            // dgvOpcionesElegidas
            // 
            this.dgvOpcionesElegidas.AllowUserToAddRows = false;
            this.dgvOpcionesElegidas.AllowUserToDeleteRows = false;
            this.dgvOpcionesElegidas.AllowUserToResizeColumns = false;
            this.dgvOpcionesElegidas.AllowUserToResizeRows = false;
            this.dgvOpcionesElegidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpcionesElegidas.BackgroundColor = System.Drawing.Color.Snow;
            this.dgvOpcionesElegidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpcionesElegidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvOpcionesElegidas.ColumnHeadersHeight = 50;
            this.dgvOpcionesElegidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOpcionesElegidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.detalles});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpcionesElegidas.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvOpcionesElegidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOpcionesElegidas.Location = new System.Drawing.Point(5, 113);
            this.dgvOpcionesElegidas.Margin = new System.Windows.Forms.Padding(5);
            this.dgvOpcionesElegidas.Name = "dgvOpcionesElegidas";
            this.dgvOpcionesElegidas.ReadOnly = true;
            this.dgvOpcionesElegidas.RowHeadersVisible = false;
            this.dgvOpcionesElegidas.RowHeadersWidth = 20;
            this.dgvOpcionesElegidas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOpcionesElegidas.RowTemplate.Height = 60;
            this.dgvOpcionesElegidas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpcionesElegidas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvOpcionesElegidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOpcionesElegidas.Size = new System.Drawing.Size(566, 423);
            this.dgvOpcionesElegidas.TabIndex = 0;
            // 
            // detalles
            // 
            this.detalles.HeaderText = "Detalles del Turno";
            this.detalles.Name = "detalles";
            this.detalles.ReadOnly = true;
            // 
            // labelTitulo
            // 
            this.labelTitulo.BackColor = System.Drawing.Color.Snow;
            this.labelTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.labelTitulo, 2);
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelTitulo.Font = new System.Drawing.Font("MV Boli", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitulo.Location = new System.Drawing.Point(5, 5);
            this.labelTitulo.Margin = new System.Windows.Forms.Padding(5);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Padding = new System.Windows.Forms.Padding(10);
            this.labelTitulo.Size = new System.Drawing.Size(1143, 98);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Cierre de Turno";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMensaje
            // 
            this.labelMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMensaje.Location = new System.Drawing.Point(581, 546);
            this.labelMensaje.Margin = new System.Windows.Forms.Padding(5);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(567, 86);
            this.labelMensaje.TabIndex = 5;
            this.labelMensaje.Text = "mensaje";
            this.labelMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMensaje.Visible = false;
            this.labelMensaje.Layout += new System.Windows.Forms.LayoutEventHandler(this.labelMensaje_Layout);
            // 
            // panelIngresoDatos
            // 
            this.panelIngresoDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngresoDatos.Controls.Add(this.flowLayoutPanel1);
            this.panelIngresoDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIngresoDatos.Location = new System.Drawing.Point(5, 546);
            this.panelIngresoDatos.Margin = new System.Windows.Forms.Padding(5);
            this.panelIngresoDatos.Name = "panelIngresoDatos";
            this.panelIngresoDatos.Size = new System.Drawing.Size(566, 86);
            this.panelIngresoDatos.TabIndex = 7;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Snow;
            this.flowLayoutPanel1.Controls.Add(this.labelNroHab);
            this.flowLayoutPanel1.Controls.Add(this.tbNroHab);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(564, 84);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // labelNroHab
            // 
            this.labelNroHab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNroHab.AutoSize = true;
            this.labelNroHab.Font = new System.Drawing.Font("Book Antiqua", 22F, System.Drawing.FontStyle.Bold);
            this.labelNroHab.Location = new System.Drawing.Point(3, 24);
            this.labelNroHab.Name = "labelNroHab";
            this.labelNroHab.Size = new System.Drawing.Size(288, 35);
            this.labelNroHab.TabIndex = 3;
            this.labelNroHab.Text = "Ingresar Habitación";
            // 
            // tbNroHab
            // 
            this.tbNroHab.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNroHab.Font = new System.Drawing.Font("Franklin Gothic Medium", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroHab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tbNroHab.Location = new System.Drawing.Point(294, 20);
            this.tbNroHab.Margin = new System.Windows.Forms.Padding(0);
            this.tbNroHab.MaxLength = 5;
            this.tbNroHab.Name = "tbNroHab";
            this.tbNroHab.Size = new System.Drawing.Size(96, 44);
            this.tbNroHab.TabIndex = 2;
            this.tbNroHab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNroHab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroHab_KeyPress);
            // 
            // panelPromos
            // 
            this.panelPromos.Controls.Add(this.dgvMedioPago);
            this.panelPromos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPromos.Location = new System.Drawing.Point(581, 113);
            this.panelPromos.Margin = new System.Windows.Forms.Padding(5);
            this.panelPromos.Name = "panelPromos";
            this.panelPromos.Size = new System.Drawing.Size(567, 423);
            this.panelPromos.TabIndex = 8;
            this.panelPromos.Visible = false;
            // 
            // dgvMedioPago
            // 
            this.dgvMedioPago.AllowUserToAddRows = false;
            this.dgvMedioPago.AllowUserToDeleteRows = false;
            this.dgvMedioPago.AllowUserToResizeColumns = false;
            this.dgvMedioPago.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvMedioPago.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvMedioPago.AutoGenerateColumns = false;
            this.dgvMedioPago.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedioPago.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvMedioPago.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMedioPago.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvMedioPago.ColumnHeadersHeight = 50;
            this.dgvMedioPago.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn});
            this.dgvMedioPago.DataSource = this.mediosDePagoBindingSource;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMedioPago.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvMedioPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMedioPago.Location = new System.Drawing.Point(0, 0);
            this.dgvMedioPago.Name = "dgvMedioPago";
            this.dgvMedioPago.ReadOnly = true;
            this.dgvMedioPago.RowHeadersVisible = false;
            this.dgvMedioPago.RowTemplate.Height = 60;
            this.dgvMedioPago.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvMedioPago.ShowCellErrors = false;
            this.dgvMedioPago.ShowCellToolTips = false;
            this.dgvMedioPago.ShowEditingIcon = false;
            this.dgvMedioPago.ShowRowErrors = false;
            this.dgvMedioPago.Size = new System.Drawing.Size(567, 423);
            this.dgvMedioPago.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle19;
            this.idDataGridViewTextBoxColumn.FillWeight = 25.38071F;
            this.idDataGridViewTextBoxColumn.HeaderText = "";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "nombre";
            dataGridViewCellStyle20.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.nombreDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle20;
            this.nombreDataGridViewTextBoxColumn.FillWeight = 174.6193F;
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Medios De Pago";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
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
            // mediosDePagoTableAdapter
            // 
            this.mediosDePagoTableAdapter.ClearBeforeFill = true;
            // 
            // FormCierreTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCierreTurno";
            this.Text = "FormAsignar";
            this.Load += new System.EventHandler(this.FormAsignarHab_Load);
            this.panelGlobal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcionesElegidas)).EndInit();
            this.panelIngresoDatos.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelPromos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedioPago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mediosDePagoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.opcionesAsignarHabitacionBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelNroHab;
        private System.Windows.Forms.Label labelMensaje;
        internal System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelIngresoDatos;
        private System.Windows.Forms.DataGridView dgvOpcionesElegidas;
        private System.Windows.Forms.Panel panelPromos;
        
        private System.Windows.Forms.BindingSource opcionesAsignarHabitacionBindingSource;
        
        public System.Windows.Forms.TextBox tbNroHab;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvMedioPago;
        private hotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource mediosDePagoBindingSource;
        private Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter mediosDePagoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        
        
        
        
    }
}