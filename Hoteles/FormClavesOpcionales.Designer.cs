using Hoteles.Entities;
namespace Hoteles
{
    partial class FormClavesOpcionales
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
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvOpcionesElegidas = new System.Windows.Forms.DataGridView();
            this.nroClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.panelIngresoDatos = new System.Windows.Forms.FlowLayoutPanel();
            this.labelNroHab = new System.Windows.Forms.Label();
            this.tbNroHab = new System.Windows.Forms.TextBox();
            this.opcionesAsignarHabitacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet2 = new Hoteles.hotelDataSet2();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.opcionesAsignarHabitacionTableAdapter = new Hoteles.hotelDataSet2TableAdapters.OpcionesAsignarHabitacionTableAdapter();
            this.panelGlobal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcionesElegidas)).BeginInit();
            this.panelIngresoDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesAsignarHabitacionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.95447F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.34066F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.86185F));
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
            this.dgvOpcionesElegidas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpcionesElegidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOpcionesElegidas.ColumnHeadersHeight = 50;
            this.dgvOpcionesElegidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOpcionesElegidas.ColumnHeadersVisible = false;
            this.dgvOpcionesElegidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nroClave,
            this.descripcion});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOpcionesElegidas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOpcionesElegidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOpcionesElegidas.Location = new System.Drawing.Point(5, 112);
            this.dgvOpcionesElegidas.Margin = new System.Windows.Forms.Padding(5);
            this.dgvOpcionesElegidas.Name = "dgvOpcionesElegidas";
            this.dgvOpcionesElegidas.ReadOnly = true;
            this.dgvOpcionesElegidas.RowHeadersVisible = false;
            this.dgvOpcionesElegidas.RowHeadersWidth = 20;
            this.dgvOpcionesElegidas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvOpcionesElegidas.RowTemplate.Height = 60;
            this.dgvOpcionesElegidas.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOpcionesElegidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOpcionesElegidas.Size = new System.Drawing.Size(566, 367);
            this.dgvOpcionesElegidas.TabIndex = 8;
            // 
            // nroClave
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nroClave.DefaultCellStyle = dataGridViewCellStyle2;
            this.nroClave.FillWeight = 180F;
            this.nroClave.HeaderText = "";
            this.nroClave.Name = "nroClave";
            this.nroClave.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.FillWeight = 366F;
            this.descripcion.HeaderText = "descripcionClave";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
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
            this.labelTitulo.Size = new System.Drawing.Size(1143, 97);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Claves Opcionales";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMensaje
            // 
            this.labelMensaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelMensaje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMensaje.Location = new System.Drawing.Point(581, 489);
            this.labelMensaje.Margin = new System.Windows.Forms.Padding(5);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(567, 143);
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
            this.panelIngresoDatos.Location = new System.Drawing.Point(5, 489);
            this.panelIngresoDatos.Margin = new System.Windows.Forms.Padding(5);
            this.panelIngresoDatos.Name = "panelIngresoDatos";
            this.panelIngresoDatos.Padding = new System.Windows.Forms.Padding(0, 50, 0, 25);
            this.panelIngresoDatos.Size = new System.Drawing.Size(566, 143);
            this.panelIngresoDatos.TabIndex = 7;
            // 
            // labelNroHab
            // 
            this.labelNroHab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelNroHab.AutoSize = true;
            this.labelNroHab.Font = new System.Drawing.Font("Book Antiqua", 24F, System.Drawing.FontStyle.Bold);
            this.labelNroHab.Location = new System.Drawing.Point(3, 51);
            this.labelNroHab.Name = "labelNroHab";
            this.labelNroHab.Size = new System.Drawing.Size(229, 39);
            this.labelNroHab.TabIndex = 3;
            this.labelNroHab.Text = "Ingresar Clave";
            // 
            // tbNroHab
            // 
            this.tbNroHab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbNroHab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroHab.Location = new System.Drawing.Point(238, 53);
            this.tbNroHab.MaxLength = 5;
            this.tbNroHab.Name = "tbNroHab";
            this.tbNroHab.Size = new System.Drawing.Size(140, 35);
            this.tbNroHab.TabIndex = 2;
            this.tbNroHab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNroHab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroHab_KeyPress);
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
            // opcionesAsignarHabitacionTableAdapter
            // 
            this.opcionesAsignarHabitacionTableAdapter.ClearBeforeFill = true;
            // 
            // FormClavesOpcionales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormClavesOpcionales";
            this.Text = "FormAsignar";
            this.Load += new System.EventHandler(this.FormAsignarHab_Load);
            this.panelGlobal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcionesElegidas)).EndInit();
            this.panelIngresoDatos.ResumeLayout(false);
            this.panelIngresoDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.opcionesAsignarHabitacionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDataSet2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private hotelDataSet2 hotelDataSet2;
        private System.Windows.Forms.BindingSource opcionesAsignarHabitacionBindingSource;
        private Hoteles.hotelDataSet2TableAdapters.OpcionesAsignarHabitacionTableAdapter opcionesAsignarHabitacionTableAdapter;
        public System.Windows.Forms.TextBox tbNroHab;
        private System.Windows.Forms.DataGridView dgvOpcionesElegidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        
        
        
        
    }
}