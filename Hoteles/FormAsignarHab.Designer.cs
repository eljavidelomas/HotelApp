namespace Hoteles
{
    partial class FormAsignarHab
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMensaje = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.tbNroHab = new System.Windows.Forms.TextBox();
            this.panelOpElegidas = new System.Windows.Forms.Panel();
            this.tbIngPromo = new System.Windows.Forms.TextBox();
            this.labelIngPromo = new System.Windows.Forms.Label();
            this.flpPromos = new System.Windows.Forms.FlowLayoutPanel();
            this.labelPromo = new System.Windows.Forms.Label();
            this.labelNroHab = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panelOpElegidas.SuspendLayout();
            this.flpPromos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.labelMensaje);
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Controls.Add(this.panelOpElegidas);
            this.panel1.Controls.Add(this.flpPromos);
            this.panel1.Controls.Add(this.labelNroHab);
            this.panel1.Controls.Add(this.tbNroHab);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(105, 49);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(1153, 637);
            this.panel1.TabIndex = 0;
            // 
            // labelMensaje
            // 
            this.labelMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMensaje.ForeColor = System.Drawing.Color.Firebrick;
            this.labelMensaje.Location = new System.Drawing.Point(1, 71);
            this.labelMensaje.Name = "labelMensaje";
            this.labelMensaje.Size = new System.Drawing.Size(1081, 25);
            this.labelMensaje.TabIndex = 5;
            this.labelMensaje.Text = "mensaje";
            this.labelMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMensaje.Visible = false;
            // 
            // labelTitulo
            // 
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitulo.Font = new System.Drawing.Font("MV Boli", 28.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelTitulo.Location = new System.Drawing.Point(0, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(1153, 72);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Asignar Habitacion";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTitulo.Paint += new System.Windows.Forms.PaintEventHandler(this.labelTitulo_Paint);
            // 
            // tbNroHab
            // 
            this.tbNroHab.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbNroHab.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNroHab.Location = new System.Drawing.Point(645, 107);
            this.tbNroHab.MaxLength = 5;
            this.tbNroHab.Name = "tbNroHab";
            this.tbNroHab.Size = new System.Drawing.Size(73, 35);
            this.tbNroHab.TabIndex = 2;
            this.tbNroHab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNroHab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNroHab_KeyPress);
            // 
            // panelOpElegidas
            // 
            this.panelOpElegidas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOpElegidas.Controls.Add(this.tbIngPromo);
            this.panelOpElegidas.Controls.Add(this.labelIngPromo);
            this.panelOpElegidas.Location = new System.Drawing.Point(570, 99);
            this.panelOpElegidas.Name = "panelOpElegidas";
            this.panelOpElegidas.Size = new System.Drawing.Size(548, 321);
            this.panelOpElegidas.TabIndex = 6;
            this.panelOpElegidas.Visible = false;
            // 
            // tbIngPromo
            // 
            this.tbIngPromo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbIngPromo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIngPromo.Location = new System.Drawing.Point(297, 26);
            this.tbIngPromo.MaxLength = 4;
            this.tbIngPromo.Name = "tbIngPromo";
            this.tbIngPromo.Size = new System.Drawing.Size(73, 35);
            this.tbIngPromo.TabIndex = 7;
            this.tbIngPromo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbIngPromo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbIngPromo_KeyPress);
            // 
            // labelIngPromo
            // 
            this.labelIngPromo.AutoSize = true;
            this.labelIngPromo.Font = new System.Drawing.Font("Book Antiqua", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIngPromo.Location = new System.Drawing.Point(17, 27);
            this.labelIngPromo.Name = "labelIngPromo";
            this.labelIngPromo.Size = new System.Drawing.Size(276, 28);
            this.labelIngPromo.TabIndex = 0;
            this.labelIngPromo.Text = "Ingresar Tipo Promoción";
            // 
            // flpPromos
            // 
            this.flpPromos.AutoSize = true;
            this.flpPromos.Controls.Add(this.labelPromo);
            this.flpPromos.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpPromos.Location = new System.Drawing.Point(35, 105);
            this.flpPromos.Name = "flpPromos";
            this.flpPromos.Size = new System.Drawing.Size(412, 326);
            this.flpPromos.TabIndex = 4;
            this.flpPromos.Visible = false;
            // 
            // labelPromo
            // 
            this.labelPromo.AutoSize = true;
            this.labelPromo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 28.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPromo.ForeColor = System.Drawing.Color.OrangeRed;
            this.labelPromo.Location = new System.Drawing.Point(3, 0);
            this.labelPromo.Name = "labelPromo";
            this.labelPromo.Size = new System.Drawing.Size(375, 50);
            this.labelPromo.TabIndex = 0;
            this.labelPromo.Text = "Tipo de Promociones";
            // 
            // labelNroHab
            // 
            this.labelNroHab.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelNroHab.AutoSize = true;
            this.labelNroHab.Font = new System.Drawing.Font("Book Antiqua", 18F);
            this.labelNroHab.Location = new System.Drawing.Point(420, 109);
            this.labelNroHab.Name = "labelNroHab";
            this.labelNroHab.Size = new System.Drawing.Size(222, 28);
            this.labelNroHab.TabIndex = 3;
            this.labelNroHab.Text = "Ingresar Habitación";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.834101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.78188F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.62519F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.605223F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
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
            // FormAsignarHab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormAsignarHab";
            this.Text = "FormAsignar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelOpElegidas.ResumeLayout(false);
            this.panelOpElegidas.PerformLayout();
            this.flpPromos.ResumeLayout(false);
            this.flpPromos.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.TextBox tbNroHab;
        private System.Windows.Forms.Label labelNroHab;
        private System.Windows.Forms.FlowLayoutPanel flpPromos;
        private System.Windows.Forms.Label labelMensaje;
        private System.Windows.Forms.Label labelPromo;
        private System.Windows.Forms.Panel panelOpElegidas;
        private System.Windows.Forms.Label labelIngPromo;
        private System.Windows.Forms.TextBox tbIngPromo;
    }
}