using Hoteles.Entities;
namespace Hoteles
{
    partial class FormCambiarEstado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.panelIngresoDatos = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNroHab = new System.Windows.Forms.Label();
            this.tbNroHab = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOpciones = new System.Windows.Forms.DataGridView();
            this.opcionesCambEst = new Hoteles.opcionesCambEst();
            this.opcionesCambioEstadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.opcionesCambioEstadoTableAdapter = new Hoteles.opcionesCambEstTableAdapters.opcionesCambioEstadoTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opcionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelGlobal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelIngresoDatos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesCambEst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesCambioEstadoBindingSource)).BeginInit();
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.93061F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.06939F));
            this.tableLayoutPanel2.Controls.Add(this.dgvOpciones, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelTitulo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelMensaje, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panelIngresoDatos, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.2449F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 72.99843F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.59969F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1153, 637);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // labelTitulo
            // 
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
            this.labelTitulo.Size = new System.Drawing.Size(1143, 68);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Cambiar Estado Habitación";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMensaje
            // 
            this.labelMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMensaje.Location = new System.Drawing.Point(695, 548);
            this.labelMensaje.Margin = new System.Windows.Forms.Padding(5);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(453, 84);
            this.labelMensaje.TabIndex = 5;
            this.labelMensaje.Text = "mensaje";
            this.labelMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMensaje.Visible = false;
            this.labelMensaje.Layout += new System.Windows.Forms.LayoutEventHandler(this.labelMensaje_Layout);
            // 
            // panelIngresoDatos
            // 
            this.panelIngresoDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngresoDatos.Controls.Add(this.labelNroHab);
            this.panelIngresoDatos.Controls.Add(this.tbNroHab);
            this.panelIngresoDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelIngresoDatos.Location = new System.Drawing.Point(5, 548);
            this.panelIngresoDatos.Margin = new System.Windows.Forms.Padding(5);
            this.panelIngresoDatos.Name = "panelIngresoDatos";
            this.panelIngresoDatos.Padding = new System.Windows.Forms.Padding(0, 25, 0, 20);
            this.panelIngresoDatos.Size = new System.Drawing.Size(680, 84);
            this.panelIngresoDatos.TabIndex = 7;
            // 
            // labelNroHab
            // 
            this.labelNroHab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNroHab.AutoSize = true;
            this.labelNroHab.Font = new System.Drawing.Font("Book Antiqua", 24F, System.Drawing.FontStyle.Bold);
            this.labelNroHab.Location = new System.Drawing.Point(3, 26);
            this.labelNroHab.Name = "labelNroHab";
            this.labelNroHab.Size = new System.Drawing.Size(309, 39);
            this.labelNroHab.TabIndex = 3;
            this.labelNroHab.Text = "Ingresar Habitación";
            // 
            // tbNroHab
            // 
            this.tbNroHab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNroHab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroHab.Location = new System.Drawing.Point(318, 28);
            this.tbNroHab.MaxLength = 5;
            this.tbNroHab.Name = "tbNroHab";
            this.tbNroHab.Size = new System.Drawing.Size(65, 35);
            this.tbNroHab.TabIndex = 2;
            this.tbNroHab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNroHab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroHab_KeyPress);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 81);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(684, 459);
            this.tableLayoutPanel3.TabIndex = 8;
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
            // dgvOpciones
            // 
            this.dgvOpciones.AllowUserToAddRows = false;
            this.dgvOpciones.AllowUserToDeleteRows = false;
            this.dgvOpciones.AllowUserToResizeColumns = false;
            this.dgvOpciones.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.dgvOpciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOpciones.AutoGenerateColumns = false;
            this.dgvOpciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOpciones.BackgroundColor = System.Drawing.Color.SeaShell;
            this.dgvOpciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOpciones.ColumnHeadersHeight = 50;
            this.dgvOpciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.opcionesDataGridViewTextBoxColumn});
            this.dgvOpciones.DataSource = this.opcionesCambioEstadoBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpciones.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOpciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOpciones.Location = new System.Drawing.Point(693, 81);
            this.dgvOpciones.Name = "dgvOpciones";
            this.dgvOpciones.ReadOnly = true;
            this.dgvOpciones.RowHeadersVisible = false;
            this.dgvOpciones.RowTemplate.Height = 60;
            this.dgvOpciones.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvOpciones.ShowCellErrors = false;
            this.dgvOpciones.ShowCellToolTips = false;
            this.dgvOpciones.ShowEditingIcon = false;
            this.dgvOpciones.ShowRowErrors = false;
            this.dgvOpciones.Size = new System.Drawing.Size(457, 459);
            this.dgvOpciones.TabIndex = 9;
            this.dgvOpciones.Visible = false;
            // 
            // opcionesCambEst
            // 
            this.opcionesCambEst.DataSetName = "opcionesCambEst";
            this.opcionesCambEst.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // opcionesCambioEstadoBindingSource
            // 
            this.opcionesCambioEstadoBindingSource.DataMember = "opcionesCambioEstado";
            this.opcionesCambioEstadoBindingSource.DataSource = this.opcionesCambEst;
            // 
            // opcionesCambioEstadoTableAdapter
            // 
            this.opcionesCambioEstadoTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.idDataGridViewTextBoxColumn.FillWeight = 20.79801F;
            this.idDataGridViewTextBoxColumn.HeaderText = "";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // opcionesDataGridViewTextBoxColumn
            // 
            this.opcionesDataGridViewTextBoxColumn.DataPropertyName = "Opciones";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.opcionesDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.opcionesDataGridViewTextBoxColumn.FillWeight = 115.7756F;
            this.opcionesDataGridViewTextBoxColumn.HeaderText = "Opciones";
            this.opcionesDataGridViewTextBoxColumn.Name = "opcionesDataGridViewTextBoxColumn";
            this.opcionesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormCambiarEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCambiarEstado";
            this.Text = "FormAsignar";
            this.Load += new System.EventHandler(this.FormAsignarHab_Load);
            this.panelGlobal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelIngresoDatos.ResumeLayout(false);
            this.panelIngresoDatos.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesCambEst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesCambioEstadoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGlobal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelNroHab;
        private System.Windows.Forms.Label labelMensaje;
        internal System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel panelIngresoDatos;
        public System.Windows.Forms.TextBox tbNroHab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvOpciones;
        private opcionesCambEst opcionesCambEst;
        private System.Windows.Forms.BindingSource opcionesCambioEstadoBindingSource;
        private Hoteles.opcionesCambEstTableAdapters.opcionesCambioEstadoTableAdapter opcionesCambioEstadoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn opcionesDataGridViewTextBoxColumn;
        
        
        
        
    }
}