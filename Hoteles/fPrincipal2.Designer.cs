using Hoteles.Properties;
using System.Windows.Forms;
using Hoteles.Entities;
namespace Hoteles
{
    partial class fPrincipal2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPrincipal2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDatosHotel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelClave = new System.Windows.Forms.Label();
            this.textClave = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.labelConserje = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panelFunciones = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_validarAlarmas = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.nrohab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bar = new System.Windows.Forms.DataGridViewImageColumn();
            this.aac = new System.Windows.Forms.DataGridViewImageColumn();
            this.alarma = new System.Windows.Forms.DataGridViewImageColumn();
            this.luz = new System.Windows.Forms.DataGridViewImageColumn();
            this.salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsaldt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsaldt2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tole2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDatosHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelFunciones.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.47059F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.91177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.69118F));
            this.tableLayoutPanel1.Controls.Add(this.panelDatosHotel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelFunciones, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.45946F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.56757F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1360, 740);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.tableLayoutPanel1_MouseLeave);
            // 
            // panelDatosHotel
            // 
            this.panelDatosHotel.BackColor = System.Drawing.Color.Transparent;
            this.panelDatosHotel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelDatosHotel.BackgroundImage")));
            this.panelDatosHotel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDatosHotel.Controls.Add(this.pictureBox1);
            this.panelDatosHotel.Controls.Add(this.labelClave);
            this.panelDatosHotel.Controls.Add(this.textClave);
            this.panelDatosHotel.Controls.Add(this.textUsuario);
            this.panelDatosHotel.Controls.Add(this.labelConserje);
            this.panelDatosHotel.Controls.Add(this.labelFecha);
            this.panelDatosHotel.Controls.Add(this.labelHora);
            this.panelDatosHotel.Controls.Add(this.labelNombre);
            this.panelDatosHotel.Controls.Add(this.shapeContainer1);
            this.panelDatosHotel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatosHotel.Location = new System.Drawing.Point(999, 59);
            this.panelDatosHotel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelDatosHotel.Name = "panelDatosHotel";
            this.panelDatosHotel.Size = new System.Drawing.Size(358, 365);
            this.panelDatosHotel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(358, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // labelClave
            // 
            this.labelClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelClave.AutoSize = true;
            this.labelClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.Location = new System.Drawing.Point(179, 338);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(58, 20);
            this.labelClave.TabIndex = 8;
            this.labelClave.Text = "Clave:";
            this.labelClave.Visible = false;
            // 
            // textClave
            // 
            this.textClave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textClave.BackColor = System.Drawing.Color.LemonChiffon;
            this.textClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textClave.Location = new System.Drawing.Point(239, 337);
            this.textClave.Margin = new System.Windows.Forms.Padding(0);
            this.textClave.Name = "textClave";
            this.textClave.Size = new System.Drawing.Size(101, 20);
            this.textClave.TabIndex = 1;
            this.textClave.UseSystemPasswordChar = true;
            this.textClave.Visible = false;
            this.textClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
            // 
            // textUsuario
            // 
            this.textUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textUsuario.BackColor = System.Drawing.Color.LemonChiffon;
            this.textUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsuario.ForeColor = System.Drawing.Color.DarkRed;
            this.textUsuario.Location = new System.Drawing.Point(87, 337);
            this.textUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(73, 20);
            this.textUsuario.TabIndex = 0;
            this.textUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textUsuario.Visible = false;
            this.textUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUsuario_KeyPress);
            // 
            // labelConserje
            // 
            this.labelConserje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelConserje.AutoSize = true;
            this.labelConserje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConserje.Location = new System.Drawing.Point(0, 338);
            this.labelConserje.Name = "labelConserje";
            this.labelConserje.Size = new System.Drawing.Size(85, 20);
            this.labelConserje.TabIndex = 3;
            this.labelConserje.Text = "Conserje:";
            // 
            // labelFecha
            // 
            this.labelFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFecha.BackColor = System.Drawing.Color.Transparent;
            this.labelFecha.Font = new System.Drawing.Font("Lucida Sans Unicode", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(-5, 238);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(362, 26);
            this.labelFecha.TabIndex = 2;
            this.labelFecha.Text = "Sábado 15 de Octubre 2013";
            this.labelFecha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelHora
            // 
            this.labelHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHora.BackColor = System.Drawing.Color.Transparent;
            this.labelHora.Font = new System.Drawing.Font("Lucida Handwriting", 44F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHora.Location = new System.Drawing.Point(-1, 260);
            this.labelHora.Margin = new System.Windows.Forms.Padding(0);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(359, 63);
            this.labelHora.TabIndex = 1;
            this.labelHora.Text = "13:00:08";
            this.labelHora.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelNombre
            // 
            this.labelNombre.BackColor = System.Drawing.Color.Transparent;
            this.labelNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNombre.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.labelNombre.Location = new System.Drawing.Point(0, 0);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(356, 26);
            this.labelNombre.TabIndex = 2;
            this.labelNombre.Text = "VISUAL HOTEL VER 1.0  PROUD";
            this.labelNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(356, 363);
            this.shapeContainer1.TabIndex = 9;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lineShape3.BorderWidth = 2;
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 0;
            this.lineShape3.X2 = 359;
            this.lineShape3.Y1 = 27;
            this.lineShape3.Y2 = 27;
            // 
            // lineShape2
            // 
            this.lineShape2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lineShape2.BorderWidth = 2;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 0;
            this.lineShape2.X2 = 359;
            this.lineShape2.Y1 = 228;
            this.lineShape2.Y2 = 228;
            // 
            // lineShape1
            // 
            this.lineShape1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 356;
            this.lineShape1.Y1 = 330;
            this.lineShape1.Y2 = 330;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nrohab,
            this.categoria,
            this.bar,
            this.aac,
            this.alarma,
            this.luz,
            this.salida,
            this.importe,
            this.estado,
            this.hsaldt,
            this.tole});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.Color.Gray;
            this.dataGridView1.Location = new System.Drawing.Point(0, 59);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 2);
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(495, 681);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.ColumnHeadersHeight = 40;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewImageColumn1,
            this.dataGridViewImageColumn2,
            this.dataGridViewImageColumn3,
            this.dataGridViewImageColumn4,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.hsaldt2,
            this.tole2});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.GridColor = System.Drawing.Color.Gray;
            this.dataGridView2.Location = new System.Drawing.Point(495, 59);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView2, 2);
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(501, 681);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // panelFunciones
            // 
            this.panelFunciones.BackColor = System.Drawing.Color.White;
            this.panelFunciones.Controls.Add(this.tableLayoutPanel2);
            this.panelFunciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFunciones.Location = new System.Drawing.Point(999, 430);
            this.panelFunciones.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.panelFunciones.Name = "panelFunciones";
            this.panelFunciones.Size = new System.Drawing.Size(358, 304);
            this.panelFunciones.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.DarkCyan;
            this.tableLayoutPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(358, 304);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Thistle;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(352, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "SENSOR DE ANOMALÍAS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_validarAlarmas
            // 
            this.timer_validarAlarmas.Enabled = true;
            this.timer_validarAlarmas.Interval = 15000;
            this.timer_validarAlarmas.Tick += new System.EventHandler(this.timerValidarAlarmas_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // nrohab
            // 
            this.nrohab.FillWeight = 56.33804F;
            this.nrohab.HeaderText = "Hab";
            this.nrohab.MinimumWidth = 35;
            this.nrohab.Name = "nrohab";
            this.nrohab.ReadOnly = true;
            this.nrohab.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nrohab.Width = 45;
            // 
            // categoria
            // 
            this.categoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoria.HeaderText = "  Cat";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bar
            // 
            this.bar.FillWeight = 63.06764F;
            this.bar.HeaderText = "Bar";
            this.bar.Image = global::Hoteles.Properties.Resources.vacio;
            this.bar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.bar.Name = "bar";
            this.bar.ReadOnly = true;
            this.bar.Width = 37;
            // 
            // aac
            // 
            this.aac.FillWeight = 72.46375F;
            this.aac.HeaderText = "AAC";
            this.aac.Image = global::Hoteles.Properties.Resources.vacio;
            this.aac.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.aac.Name = "aac";
            this.aac.ReadOnly = true;
            this.aac.Width = 37;
            // 
            // alarma
            // 
            this.alarma.FillWeight = 81.30112F;
            this.alarma.HeaderText = "Ala";
            this.alarma.Image = global::Hoteles.Properties.Resources.vacio;
            this.alarma.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.alarma.Name = "alarma";
            this.alarma.ReadOnly = true;
            this.alarma.Width = 37;
            // 
            // luz
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.luz.DefaultCellStyle = dataGridViewCellStyle2;
            this.luz.FillWeight = 89.61292F;
            this.luz.HeaderText = "Luz";
            this.luz.Image = global::Hoteles.Properties.Resources.luzOff3;
            this.luz.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.luz.Name = "luz";
            this.luz.ReadOnly = true;
            this.luz.Width = 37;
            // 
            // salida
            // 
            this.salida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.salida.FillWeight = 120F;
            this.salida.HeaderText = "Horario";
            this.salida.Name = "salida";
            this.salida.ReadOnly = true;
            this.salida.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // importe
            // 
            this.importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.importe.DefaultCellStyle = dataGridViewCellStyle3;
            this.importe.FillWeight = 201F;
            this.importe.HeaderText = "SALDO";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
            this.importe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // estado
            // 
            this.estado.HeaderText = "estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            // 
            // hsaldt
            // 
            this.hsaldt.HeaderText = "hsaldt";
            this.hsaldt.Name = "hsaldt";
            this.hsaldt.ReadOnly = true;
            this.hsaldt.Visible = false;
            // 
            // tole
            // 
            this.tole.HeaderText = "tolerancia";
            this.tole.Name = "tole";
            this.tole.ReadOnly = true;
            this.tole.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 56.33804F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Hab";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 35;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "  Cat";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 63.06764F;
            this.dataGridViewImageColumn1.HeaderText = "Bar";
            this.dataGridViewImageColumn1.Image = global::Hoteles.Properties.Resources.vacio;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 37;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 72.46375F;
            this.dataGridViewImageColumn2.HeaderText = "AAC";
            this.dataGridViewImageColumn2.Image = global::Hoteles.Properties.Resources.vacio;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 40;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.FillWeight = 81.30112F;
            this.dataGridViewImageColumn3.HeaderText = "Ala";
            this.dataGridViewImageColumn3.Image = global::Hoteles.Properties.Resources.vacio;
            this.dataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Width = 37;
            // 
            // dataGridViewImageColumn4
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn4.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewImageColumn4.FillWeight = 89.61292F;
            this.dataGridViewImageColumn4.HeaderText = "Luz";
            this.dataGridViewImageColumn4.Image = global::Hoteles.Properties.Resources.luzOff3;
            this.dataGridViewImageColumn4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Width = 37;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn3.FillWeight = 120F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Horario";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.FillWeight = 201F;
            this.dataGridViewTextBoxColumn4.HeaderText = "SALDO";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "estado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // hsaldt2
            // 
            this.hsaldt2.HeaderText = "hsaldt";
            this.hsaldt2.Name = "hsaldt2";
            this.hsaldt2.ReadOnly = true;
            this.hsaldt2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.hsaldt2.Visible = false;
            // 
            // tole2
            // 
            this.tole2.HeaderText = "tolerancia";
            this.tole2.Name = "tole2";
            this.tole2.ReadOnly = true;
            this.tole2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.tole2.Visible = false;
            // 
            // fPrincipal2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 740);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fPrincipal2";
            this.Text = "fPrincipal2";
            this.Load += new System.EventHandler(this.fPrincipal2_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fPrincipal2_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDatosHotel.ResumeLayout(false);
            this.panelDatosHotel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelFunciones.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelFunciones;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panelDatosHotel;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.TextBox textClave;
        private System.Windows.Forms.TextBox textUsuario;
        public System.Windows.Forms.Label labelConserje;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Label labelNombre;
        public DataGridView dataGridView2;
        private Timer timer_validarAlarmas;
        private System.IO.Ports.SerialPort serialPort1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn nrohab;
        private DataGridViewTextBoxColumn categoria;
        private DataGridViewImageColumn bar;
        private DataGridViewImageColumn aac;
        private DataGridViewImageColumn alarma;
        private DataGridViewImageColumn luz;
        private DataGridViewTextBoxColumn salida;
        private DataGridViewTextBoxColumn importe;
        private DataGridViewTextBoxColumn estado;
        private DataGridViewTextBoxColumn hsaldt;
        private DataGridViewTextBoxColumn tole;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewImageColumn dataGridViewImageColumn1;
        private DataGridViewImageColumn dataGridViewImageColumn2;
        private DataGridViewImageColumn dataGridViewImageColumn3;
        private DataGridViewImageColumn dataGridViewImageColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn hsaldt2;
        private DataGridViewTextBoxColumn tole2;
    }
}