using System.Windows.Forms;
using Hoteles.Entities;
using System.Drawing;
using Hoteles.Properties;
using System.IO;
namespace Hoteles
{
    partial class fPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);            
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
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
            this.timerHora = new System.Windows.Forms.Timer(this.components);
            this.timerParpadeo = new System.Windows.Forms.Timer(this.components);
            this.timerValidarAlarmas = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelFunciones.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panelDatosHotel.SuspendLayout();
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
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.36986F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.68493F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1366, 768);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panelFunciones
            // 
            this.panelFunciones.Controls.Add(this.tableLayoutPanel2);
            this.panelFunciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFunciones.Location = new System.Drawing.Point(971, 381);
            this.panelFunciones.Name = "panelFunciones";
            this.panelFunciones.Size = new System.Drawing.Size(392, 384);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(392, 384);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // labelFuncVarios
            // 
            this.labelFuncVarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFuncVarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(1)), true);
            this.labelFuncVarios.Location = new System.Drawing.Point(350, 191);
            this.labelFuncVarios.Margin = new System.Windows.Forms.Padding(0);
            this.labelFuncVarios.Name = "labelFuncVarios";
            this.labelFuncVarios.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelFuncVarios.Size = new System.Drawing.Size(40, 61);
            this.labelFuncVarios.TabIndex = 11;
            this.labelFuncVarios.Text = "Varios";
            this.labelFuncVarios.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFuncBar
            // 
            this.labelFuncBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFuncBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(1)), true);
            this.labelFuncBar.Location = new System.Drawing.Point(350, 128);
            this.labelFuncBar.Margin = new System.Windows.Forms.Padding(0);
            this.labelFuncBar.Name = "labelFuncBar";
            this.labelFuncBar.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelFuncBar.Size = new System.Drawing.Size(40, 61);
            this.labelFuncBar.TabIndex = 10;
            this.labelFuncBar.Text = "BAR";
            this.labelFuncBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(1)), true);
            this.label1.Location = new System.Drawing.Point(350, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.tableLayoutPanel2.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(40, 124);
            this.label1.TabIndex = 2;
            this.label1.Text = "HABIT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(5, 257);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(166, 55);
            this.button6.TabIndex = 7;
            this.button6.Text = "F9 - Extraccion Dinero";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(179, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 55);
            this.button3.TabIndex = 3;
            this.button3.Text = "F8 - Cam.Estado de Hab";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(5, 194);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 55);
            this.button5.TabIndex = 7;
            this.button5.Text = "F7 - Avisos Horarios";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(5, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 55);
            this.button1.TabIndex = 7;
            this.button1.Text = "F5 - Ped.Bar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(179, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 55);
            this.button4.TabIndex = 5;
            this.button4.Text = "F6 - Anular.Pedido bar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(179, 257);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 55);
            this.button2.TabIndex = 8;
            this.button2.Text = "F10 - Claves Opcionales";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCerrar.Location = new System.Drawing.Point(179, 68);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(166, 55);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "F4 - Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(5, 320);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(166, 59);
            this.button8.TabIndex = 7;
            this.button8.Text = "F11 - Consultar Estado";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // btnAdelanto
            // 
            this.btnAdelanto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdelanto.Location = new System.Drawing.Point(5, 68);
            this.btnAdelanto.Name = "btnAdelanto";
            this.btnAdelanto.Size = new System.Drawing.Size(166, 55);
            this.btnAdelanto.TabIndex = 4;
            this.btnAdelanto.Text = "F3 - Adelanto";
            this.btnAdelanto.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Location = new System.Drawing.Point(179, 320);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(166, 59);
            this.button10.TabIndex = 6;
            this.button10.Text = "F12 - Cierre Planilla";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btnAsignar
            // 
            this.btnAsignar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAsignar.Location = new System.Drawing.Point(5, 5);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(166, 55);
            this.btnAsignar.TabIndex = 0;
            this.btnAsignar.Text = "F1 - Aisgnar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancelar.Location = new System.Drawing.Point(179, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(166, 55);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "F2 - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(350, 254);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.SetRowSpan(this.label2, 2);
            this.label2.Size = new System.Drawing.Size(40, 128);
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
            this.panelDatosHotel.Location = new System.Drawing.Point(971, 61);
            this.panelDatosHotel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.panelDatosHotel.Name = "panelDatosHotel";
            this.panelDatosHotel.Size = new System.Drawing.Size(392, 317);
            this.panelDatosHotel.TabIndex = 8;
            this.panelDatosHotel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDatosHotel_Paint);
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
            this.textClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textClave_KeyPress);
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
            this.textUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textUsuario_KeyPress);
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
            this.labelHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHora.Location = new System.Drawing.Point(0, 191);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(205, 37);
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
            this.labelNombre.Size = new System.Drawing.Size(390, 92);
            this.labelNombre.TabIndex = 0;
            this.labelNombre.Text = "HotelApp V 1.0";
            this.labelNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerHora
            // 
            this.timerHora.Enabled = true;
            this.timerHora.Interval = 10000;
            this.timerHora.Tick += new System.EventHandler(this.timerHora_Tick);
            // 
            // timerParpadeo
            // 
            this.timerParpadeo.Enabled = true;
            this.timerParpadeo.Interval = 1000;
            this.timerParpadeo.Tick += new System.EventHandler(this.timerParpadeo_Tick);
            // 
            // timerValidarAlarmas
            // 
            this.timerValidarAlarmas.Enabled = true;
            this.timerValidarAlarmas.Interval = 25000;
            this.timerValidarAlarmas.Tick += new System.EventHandler(this.timerValidarAlarmas_Tick);
            // 
            // fPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "fPrincipal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.fPrincipal_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelFunciones.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panelDatosHotel.ResumeLayout(false);
            this.panelDatosHotel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public TableLayoutPanel tableLayoutPanel1;        
        private Panel panelFunciones;
        private Panel panelDatosHotel;
        private Label labelNombre;
        private Label labelConserje;
        private Label labelFecha;
        private Label labelHora;
        private Timer timerHora;
        private Label labelDireccion;
        private Label labelTel;
        private TextBox textClave;
        private TextBox textUsuario;
        private Label labelClave;
        private Label label1;
        private Button btnAsignar;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel2;
        private Button button4;
        private Button btnAdelanto;
        private Button btnCancelar;
        private Button button10;
        private Button btnCerrar;
        private Button button8;
        private Button button6;
        private Button button5;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label labelFuncBar;
        private Label labelFuncVarios;
        private Timer timerParpadeo;
        private Timer timerValidarAlarmas;
        
    }
}

