using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Hoteles.Entities
{
    public static class Alarma
    {
        static Label lAviso;
        static Timer timer ;
        public static bool prendida = false;
        

        static public Label activar(fPrincipal fPrincipal,string mensaje)
        {
            if (lAviso == null)
            {
                lAviso = new Label();
                timer = new Timer();                
                timer.Tick += new EventHandler(timer_Tick); // Everytime timer ticks, timer_Tick will be called
                timer.Interval = (800) * (1);              // Timer will tick evert second
                timer.Enabled = true;                       // Enable the timer
                timer.Start();
                lAviso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
                lAviso.BackColor = Color.White;
                lAviso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                lAviso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                lAviso.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lAviso.ForeColor = System.Drawing.Color.Red;                
                lAviso.Margin = new System.Windows.Forms.Padding(3);
                lAviso.Name = "lAviso";
                lAviso.Size = new System.Drawing.Size(1, 1);
                lAviso.TabIndex = 4;
                lAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                fPrincipal.tableLayoutPanel1.SetColumnSpan(lAviso, 3);
                fPrincipal.tableLayoutPanel1.Controls.Add(lAviso, 0, 0);

            }
            lAviso.Text = mensaje;
            prendida = true;

            return lAviso;
        }

        static public void desactivar()
        {
            if (lAviso != null)
            {
                timer.Stop();
                timer.Dispose();
                lAviso.Visible = false;
                lAviso.Dispose();
                lAviso = null;
                prendida = false;
            }
        }

        static void timer_Tick(object sender, EventArgs e)
        {
            if (lAviso.Visible)
                lAviso.Visible = false;
            else
                lAviso.Visible = true;
        }
        
    }
    
}
