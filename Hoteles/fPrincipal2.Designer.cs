using Hoteles.Properties;
using System.Windows.Forms;
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelFunciones = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFuncVarios = new System.Windows.Forms.Label();
            this.labelFuncBar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.btnAdelanto = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDatosHotel = new System.Windows.Forms.Panel();
            this.labelClave = new System.Windows.Forms.Label();
            this.textClave = new System.Windows.Forms.TextBox();
            this.textUsuario = new System.Windows.Forms.TextBox();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelTel = new System.Windows.Forms.Label();
            this.labelConserje = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
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
            this.timer_parpadeoHabitaciones = new System.Windows.Forms.Timer(this.components);
            this.timer_validarAlarmas = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFunciones.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelDatosHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29F));
            this.tableLayoutPanel1.Controls.Add(this.panelFunciones, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panelDatosHotel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView2, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.36986F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.68493F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1360, 740);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panelFunciones
            // 
            this.panelFunciones.Controls.Add(this.tableLayoutPanel2);
            this.panelFunciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFunciones.Location = new System.Drawing.Point(967, 367);
            this.panelFunciones.Name = "panelFunciones";
            this.panelFunciones.Size = new System.Drawing.Size(390, 370);
            this.panelFunciones.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.labelFuncVarios, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelFuncBar, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button6, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.button3, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.button5, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.button4, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.button2, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnCerrar, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.button8, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnAdelanto, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button10, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnAsignar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCancelar, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(390, 370);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // labelFuncVarios
            // 
            this.labelFuncVarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFuncVarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(1)), true);
            this.labelFuncVarios.Location = new System.Drawing.Point(348, 185);
            this.labelFuncVarios.Margin = new System.Windows.Forms.Padding(0);
            this.labelFuncVarios.Name = "labelFuncVarios";
            this.labelFuncVarios.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelFuncVarios.Size = new System.Drawing.Size(40, 59);
            this.labelFuncVarios.TabIndex = 11;
            this.labelFuncVarios.Text = "Varios";
            this.labelFuncVarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFuncBar
            // 
            this.labelFuncBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFuncBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(1)), true);
            this.labelFuncBar.Location = new System.Drawing.Point(348, 124);
            this.labelFuncBar.Margin = new System.Windows.Forms.Padding(0);
            this.labelFuncBar.Name = "labelFuncBar";
            this.labelFuncBar.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelFuncBar.Size = new System.Drawing.Size(40, 59);
            this.labelFuncBar.TabIndex = 10;
            this.labelFuncBar.Text = "BAR";
            this.labelFuncBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(1)), true);
            this.label1.Location = new System.Drawing.Point(348, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tableLayoutPanel2.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(40, 120);
            this.label1.TabIndex = 2;
            this.label1.Text = "HABIT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(5, 249);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(165, 53);
            this.button6.TabIndex = 7;
            this.button6.Text = "F9 - Extraccion Dinero";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(178, 188);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(165, 53);
            this.button3.TabIndex = 3;
            this.button3.Text = "F8 - Cam.Estado de Hab";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(5, 188);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(165, 53);
            this.button5.TabIndex = 7;
            this.button5.Text = "F7 - Avisos Horarios";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(5, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 53);
            this.button1.TabIndex = 7;
            this.button1.Text = "F5 - Ped.Bar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(178, 127);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(165, 53);
            this.button4.TabIndex = 5;
            this.button4.Text = "F6 - Anular.Pedido bar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(178, 249);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 53);
            this.button2.TabIndex = 8;
            this.button2.Text = "F10 - Claves Opcionales";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCerrar.Location = new System.Drawing.Point(178, 66);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(165, 53);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "F4 - Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(5, 310);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(165, 55);
            this.button8.TabIndex = 7;
            this.button8.Text = "F11 - Consultar Estado";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // btnAdelanto
            // 
            this.btnAdelanto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdelanto.Location = new System.Drawing.Point(5, 66);
            this.btnAdelanto.Name = "btnAdelanto";
            this.btnAdelanto.Size = new System.Drawing.Size(165, 53);
            this.btnAdelanto.TabIndex = 4;
            this.btnAdelanto.Text = "F3 - Adelanto";
            this.btnAdelanto.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Location = new System.Drawing.Point(178, 310);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(165, 55);
            this.button10.TabIndex = 6;
            this.button10.Text = "F12 - Cierre Planilla";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsignar.Location = new System.Drawing.Point(5, 5);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(165, 53);
            this.btnAsignar.TabIndex = 0;
            this.btnAsignar.Text = "F1 - Aisgnar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.Location = new System.Drawing.Point(178, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(165, 53);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "F2 - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(348, 246);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.SetRowSpan(this.label2, 2);
            this.label2.Size = new System.Drawing.Size(40, 122);
            this.label2.TabIndex = 9;
            this.label2.Text = "CAJA";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelDatosHotel
            // 
            this.panelDatosHotel.BackColor = System.Drawing.Color.LightYellow;
            this.panelDatosHotel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDatosHotel.Controls.Add(this.labelClave);
            this.panelDatosHotel.Controls.Add(this.textClave);
            this.panelDatosHotel.Controls.Add(this.textUsuario);
            this.panelDatosHotel.Controls.Add(this.labelDireccion);
            this.panelDatosHotel.Controls.Add(this.labelTel);
            this.panelDatosHotel.Controls.Add(this.labelConserje);
            this.panelDatosHotel.Controls.Add(this.labelFecha);
            this.panelDatosHotel.Controls.Add(this.labelHora);
            this.panelDatosHotel.Controls.Add(this.labelNombre);
            this.panelDatosHotel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatosHotel.Location = new System.Drawing.Point(967, 59);
            this.panelDatosHotel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelDatosHotel.Name = "panelDatosHotel";
            this.panelDatosHotel.Size = new System.Drawing.Size(390, 305);
            this.panelDatosHotel.TabIndex = 8;
            // 
            // labelClave
            // 
            this.labelClave.AutoSize = true;
            this.labelClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClave.Location = new System.Drawing.Point(0, 277);
            this.labelClave.Name = "labelClave";
            this.labelClave.Size = new System.Drawing.Size(75, 25);
            this.labelClave.TabIndex = 8;
            this.labelClave.Text = "Clave:";
            this.labelClave.Visible = false;
            // 
            // textClave
            // 
            this.textClave.BackColor = System.Drawing.Color.LemonChiffon;
            this.textClave.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textClave.Location = new System.Drawing.Point(79, 279);
            this.textClave.Margin = new System.Windows.Forms.Padding(0);
            this.textClave.Name = "textClave";
            this.textClave.Size = new System.Drawing.Size(116, 23);
            this.textClave.TabIndex = 7;
            this.textClave.UseSystemPasswordChar = true;
            this.textClave.Visible = false;
            // 
            // textUsuario
            // 
            this.textUsuario.BackColor = System.Drawing.Color.LemonChiffon;
            this.textUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsuario.ForeColor = System.Drawing.Color.DarkRed;
            this.textUsuario.Location = new System.Drawing.Point(111, 246);
            this.textUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.textUsuario.Name = "textUsuario";
            this.textUsuario.Size = new System.Drawing.Size(116, 23);
            this.textUsuario.TabIndex = 6;
            this.textUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textUsuario.Visible = false;
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDireccion.Location = new System.Drawing.Point(204, 88);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(148, 24);
            this.labelDireccion.TabIndex = 5;
            this.labelDireccion.Text = "Viamonte 2220";
            this.labelDireccion.Visible = false;
            // 
            // labelTel
            // 
            this.labelTel.AutoSize = true;
            this.labelTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTel.Location = new System.Drawing.Point(1, 88);
            this.labelTel.Name = "labelTel";
            this.labelTel.Size = new System.Drawing.Size(153, 24);
            this.labelTel.TabIndex = 4;
            this.labelTel.Text = "Tel.: 4345-5454";
            this.labelTel.Visible = false;
            // 
            // labelConserje
            // 
            this.labelConserje.AutoSize = true;
            this.labelConserje.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConserje.Location = new System.Drawing.Point(0, 243);
            this.labelConserje.Name = "labelConserje";
            this.labelConserje.Size = new System.Drawing.Size(106, 25);
            this.labelConserje.TabIndex = 3;
            this.labelConserje.Text = "Conserje:";
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.Location = new System.Drawing.Point(1, 129);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(381, 37);
            this.labelFecha.TabIndex = 2;
            this.labelFecha.Text = "Fecha:  Sáb 12 / 03 / 12";
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.Font = new System.Drawing.Font("Lucida Handwriting", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHora.Location = new System.Drawing.Point(0, 191);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(253, 41);
            this.labelHora.TabIndex = 1;
            this.labelHora.Text = "Hora:  13:00";
            // 
            // labelNombre
            // 
            this.labelNombre.BackColor = System.Drawing.Color.Transparent;
            this.labelNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelNombre.Font = new System.Drawing.Font("Baskerville Old Face", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.ForeColor = System.Drawing.Color.Firebrick;
            this.labelNombre.Location = new System.Drawing.Point(0, 0);
            this.labelNombre.Margin = new System.Windows.Forms.Padding(0);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(388, 92);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "HotelApp V 1.0";
            this.labelNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle49;
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
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle52;
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
            this.dataGridView1.Size = new System.Drawing.Size(482, 681);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // nrohab
            // 
            this.nrohab.FillWeight = 56.33804F;
            this.nrohab.HeaderText = "Nº Hab";
            this.nrohab.MinimumWidth = 35;
            this.nrohab.Name = "nrohab";
            this.nrohab.ReadOnly = true;
            this.nrohab.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nrohab.Width = 45;
            // 
            // categoria
            // 
            this.categoria.FillWeight = 79.05887F;
            this.categoria.HeaderText = "  Cat";
            this.categoria.Name = "categoria";
            this.categoria.ReadOnly = true;
            this.categoria.Width = 63;
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
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle50.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle50.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.luz.DefaultCellStyle = dataGridViewCellStyle50;
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
            this.salida.FillWeight = 161.5295F;
            this.salida.HeaderText = "H. Sal";
            this.salida.Name = "salida";
            this.salida.ReadOnly = true;
            // 
            // importe
            // 
            this.importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle51.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.importe.DefaultCellStyle = dataGridViewCellStyle51;
            this.importe.FillWeight = 196.6283F;
            this.importe.HeaderText = "Importe";
            this.importe.Name = "importe";
            this.importe.ReadOnly = true;
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
            this.dataGridView2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dataGridView2.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle53;
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
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle56;
            this.dataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView2.GridColor = System.Drawing.Color.Gray;
            this.dataGridView2.Location = new System.Drawing.Point(482, 59);
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
            this.dataGridView2.Size = new System.Drawing.Size(482, 681);
            this.dataGridView2.TabIndex = 10;
            this.dataGridView2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 56.33804F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nº Hab";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 35;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 45;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 79.05887F;
            this.dataGridViewTextBoxColumn2.HeaderText = "  Cat";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 63;
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
            this.dataGridViewImageColumn2.Width = 37;
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
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle54.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn4.DefaultCellStyle = dataGridViewCellStyle54;
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
            this.dataGridViewTextBoxColumn3.FillWeight = 161.5295F;
            this.dataGridViewTextBoxColumn3.HeaderText = "H. Sal";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle55.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle55;
            this.dataGridViewTextBoxColumn4.FillWeight = 196.6283F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "estado";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // hsaldt2
            // 
            this.hsaldt2.HeaderText = "hsaldt";
            this.hsaldt2.Name = "hsaldt2";
            this.hsaldt2.ReadOnly = true;
            this.hsaldt2.Visible = false;
            // 
            // tole2
            // 
            this.tole2.HeaderText = "tolerancia";
            this.tole2.Name = "tole2";
            this.tole2.ReadOnly = true;
            this.tole2.Visible = false;
            // 
            // timer_parpadeoHabitaciones
            // 
            this.timer_parpadeoHabitaciones.Interval = 5000;
            // 
            // timer_validarAlarmas
            // 
            this.timer_validarAlarmas.Enabled = true;
            this.timer_validarAlarmas.Interval = 5000;
            this.timer_validarAlarmas.Tick += new System.EventHandler(this.timerValidarAlarmas_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
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
            this.panelFunciones.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelDatosHotel.ResumeLayout(false);
            this.panelDatosHotel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panelFunciones;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelFuncVarios;
        private System.Windows.Forms.Label labelFuncBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnAdelanto;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDatosHotel;
        private System.Windows.Forms.Label labelClave;
        private System.Windows.Forms.TextBox textClave;
        private System.Windows.Forms.TextBox textUsuario;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelTel;
        public System.Windows.Forms.Label labelConserje;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Label labelNombre;
        public DataGridView dataGridView2;
        private Timer timer_parpadeoHabitaciones;
        private Timer timer_validarAlarmas;
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
        private System.IO.Ports.SerialPort serialPort1;
    }
}