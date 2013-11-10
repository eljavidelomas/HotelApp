using Hoteles.Entities;
namespace Hoteles
{
    partial class FormCierreTurnoCliente2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelGlobal = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.panelPromos = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lHoraSal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lHoraEnt = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNroHab = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.dgvDetallesTurno = new System.Windows.Forms.DataGridView();
            this.cantArticulos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mediosDePagoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDataSet = new Hoteles.hotelDataSet();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.mediosDePagoTableAdapter = new Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter();
            this.opcionesAsignarHabitacionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelGlobal.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelPromos.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panelGlobal.Location = new System.Drawing.Point(65, 35);
            this.panelGlobal.Margin = new System.Windows.Forms.Padding(0);
            this.panelGlobal.Name = "panelGlobal";
            this.tableLayoutPanel1.SetRowSpan(this.panelGlobal, 2);
            this.panelGlobal.Size = new System.Drawing.Size(1216, 651);
            this.panelGlobal.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Gray;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.89474F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.10526F));
            this.tableLayoutPanel2.Controls.Add(this.labelTitulo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panelPromos, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.dgvDetallesTurno, 1, -1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.67128F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.81721F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.51152F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1216, 651);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // labelTitulo
            // 
            this.labelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
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
            this.labelTitulo.Size = new System.Drawing.Size(1206, 79);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Cierre de Turno";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPromos
            // 
            this.panelPromos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(240)))));
            this.panelPromos.Controls.Add(this.label5);
            this.panelPromos.Controls.Add(this.lHoraSal);
            this.panelPromos.Controls.Add(this.label4);
            this.panelPromos.Controls.Add(this.lHoraEnt);
            this.panelPromos.Controls.Add(this.label2);
            this.panelPromos.Controls.Add(this.lblNroHab);
            this.panelPromos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPromos.Location = new System.Drawing.Point(709, 94);
            this.panelPromos.Margin = new System.Windows.Forms.Padding(5);
            this.panelPromos.Name = "panelPromos";
            this.panelPromos.Size = new System.Drawing.Size(502, 437);
            this.panelPromos.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Latha", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(288, 365);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 41);
            this.label5.TabIndex = 16;
            this.label5.Text = "Salida :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lHoraSal
            // 
            this.lHoraSal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lHoraSal.AutoSize = true;
            this.lHoraSal.Font = new System.Drawing.Font("Latha", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHoraSal.ForeColor = System.Drawing.Color.Firebrick;
            this.lHoraSal.Location = new System.Drawing.Point(406, 367);
            this.lHoraSal.Margin = new System.Windows.Forms.Padding(0);
            this.lHoraSal.Name = "lHoraSal";
            this.lHoraSal.Size = new System.Drawing.Size(81, 41);
            this.lHoraSal.TabIndex = 17;
            this.lHoraSal.Text = "11:55";
            this.lHoraSal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Latha", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 366);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 41);
            this.label4.TabIndex = 14;
            this.label4.Text = "Entrada :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lHoraEnt
            // 
            this.lHoraEnt.AutoSize = true;
            this.lHoraEnt.Font = new System.Drawing.Font("Latha", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHoraEnt.ForeColor = System.Drawing.Color.Firebrick;
            this.lHoraEnt.Location = new System.Drawing.Point(142, 368);
            this.lHoraEnt.Margin = new System.Windows.Forms.Padding(0);
            this.lHoraEnt.Name = "lHoraEnt";
            this.lHoraEnt.Size = new System.Drawing.Size(81, 41);
            this.lHoraEnt.TabIndex = 15;
            this.lHoraEnt.Text = "11:55";
            this.lHoraEnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS PGothic", 76F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(491, 102);
            this.label2.TabIndex = 12;
            this.label2.Text = "Habitación";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNroHab
            // 
            this.lblNroHab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNroHab.Font = new System.Drawing.Font("Times New Roman", 120F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroHab.ForeColor = System.Drawing.Color.Firebrick;
            this.lblNroHab.Location = new System.Drawing.Point(54, 151);
            this.lblNroHab.Margin = new System.Windows.Forms.Padding(5);
            this.lblNroHab.Name = "lblNroHab";
            this.lblNroHab.Size = new System.Drawing.Size(397, 181);
            this.lblNroHab.TabIndex = 13;
            this.lblNroHab.Text = "90";
            this.lblNroHab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblMonto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(709, 541);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 105);
            this.panel1.TabIndex = 9;
            // 
            // lblMonto
            // 
            this.lblMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.lblMonto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMonto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMonto.Font = new System.Drawing.Font("Times New Roman", 65F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.Black;
            this.lblMonto.Location = new System.Drawing.Point(0, 0);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(502, 105);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "$ 77.065,25";
            this.lblMonto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDetallesTurno
            // 
            this.dgvDetallesTurno.AllowUserToAddRows = false;
            this.dgvDetallesTurno.AllowUserToDeleteRows = false;
            this.dgvDetallesTurno.AllowUserToResizeColumns = false;
            this.dgvDetallesTurno.AllowUserToResizeRows = false;
            this.dgvDetallesTurno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetallesTurno.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvDetallesTurno.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetallesTurno.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetallesTurno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetallesTurno.ColumnHeadersHeight = 40;
            this.dgvDetallesTurno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetallesTurno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cantArticulos,
            this.descripcion,
            this.precio});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesTurno.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetallesTurno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetallesTurno.Location = new System.Drawing.Point(5, 94);
            this.dgvDetallesTurno.Margin = new System.Windows.Forms.Padding(5);
            this.dgvDetallesTurno.Name = "dgvDetallesTurno";
            this.dgvDetallesTurno.ReadOnly = true;
            this.dgvDetallesTurno.RowHeadersVisible = false;
            this.dgvDetallesTurno.RowHeadersWidth = 20;
            this.dgvDetallesTurno.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel2.SetRowSpan(this.dgvDetallesTurno, 2);
            this.dgvDetallesTurno.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetallesTurno.RowTemplate.Height = 30;
            this.dgvDetallesTurno.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetallesTurno.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetallesTurno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetallesTurno.Size = new System.Drawing.Size(694, 552);
            this.dgvDetallesTurno.TabIndex = 0;
            // 
            // cantArticulos
            // 
            this.cantArticulos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cantArticulos.DefaultCellStyle = dataGridViewCellStyle2;
            this.cantArticulos.FillWeight = 10F;
            this.cantArticulos.HeaderText = "Cant";
            this.cantArticulos.Name = "cantArticulos";
            this.cantArticulos.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.FillWeight = 70F;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.precio.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.814815F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.59259F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.48148F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.037037F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.panelGlobal, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.79452F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.24657F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.94845F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.773196F));
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
            this.label3.Location = new System.Drawing.Point(68, 686);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1210, 44);
            this.label3.TabIndex = 2;
            this.label3.Text = "Enter - Confirma                    Esc - Cancela";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mediosDePagoTableAdapter
            // 
            this.mediosDePagoTableAdapter.ClearBeforeFill = true;
            // 
            // FormCierreTurnoCliente2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormCierreTurnoCliente2";
            this.Text = "FormAsignar";
            this.Load += new System.EventHandler(this.FormAsignarHab_Load);
            this.panelGlobal.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panelPromos.ResumeLayout(false);
            this.panelPromos.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        internal System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelPromos;

        private System.Windows.Forms.BindingSource opcionesAsignarHabitacionBindingSource;
        private hotelDataSet hotelDataSet;
        private System.Windows.Forms.BindingSource mediosDePagoBindingSource;
        private Hoteles.hotelDataSetTableAdapters.mediosDePagoTableAdapter mediosDePagoTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lHoraSal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lHoraEnt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNroHab;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvDetallesTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.Label label3;
        
        
        
        
    }
}