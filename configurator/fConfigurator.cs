using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing.Printing;
using System.Data.SqlClient;
using Configurator.Properties;
using System.Threading;


namespace Configurator
{
    public partial class fConfigurator : Form
    {
        public static SqlConnection conn;

        public fConfigurator()
        {
            InitializeComponent();            
        }

        private void fPrincipal_Load(object sender, EventArgs e)
        {
            if (conn == null)
            {
                conn = new SqlConnection();
                conn.ConnectionString = Settings.Default.hotelConn;
                conn.Open();
                foreach (string s in SerialPort.GetPortNames())
                {
                    portSeñalIn.Items.Add(s);
                }
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    ImpresoraCaja.Items.Add(printer);
                    ImpresoraCocina.Items.Add(printer);
                    ImpresoraTickets.Items.Add(printer);
                }                           
            }
            
            ImpresoraCaja.SelectedItem = tools.obtenerParametroString("ImpresoraCaja");
            ImpresoraCocina.SelectedItem = tools.obtenerParametroString("ImpresoraCocina");
            ImpresoraTickets.SelectedItem = tools.obtenerParametroString("ImpresoraTickets");
            portSeñalIn.SelectedItem = tools.obtenerParametroString("portSeñalIn");
            modSeñalizacion.SelectedItem = tools.obtenerParametroString("modSeñalizacion");
            stockCierreCaja.SelectedItem = tools.obtenerParametroString("stockCierreCaja");
            nombreHotel.Text = tools.obtenerParametroString("nombreHotel");            
            nroHotelCodBarras.Text = tools.obtenerParametroInt("nroHotelCodBarras").ToString();
            redondeo.Text = tools.obtenerParametroString("redondeo");
            emisionPedidos.SelectedItem = tools.obtenerParametroString("emisionPedidos");
            mostrarVisualEXE.Checked = tools.obtenerParametroInt("mostrarVisualEXE")==0?false:true;            
            emisionFactura.Checked = tools.obtenerParametroInt("emisionFactura") == 0 ? false : true;
            emisionGastos.Checked = tools.obtenerParametroInt("emisionGastos") == 0 ? false : true;
            eliminarRegistros.Checked = tools.obtenerParametroInt("eliminarRegistros") == 0 ? false : true;
            consumoRopaCierre.Checked = tools.obtenerParametroInt("consumoRopaCierre") == 0 ? false : true;
            senialOcupado.SelectedItem = tools.obtenerParametroString("senialOcupado");
            ordenListado.SelectedItem = tools.obtenerParametroString("ordenListado");
            minFinTurnoMayor100.Text = tools.obtenerParametroInt("minFinTurnoMayor100").ToString();
            minFinTurnoMenor100.Text = tools.obtenerParametroInt("minFinTurnoMenor100").ToString();
            coefPuntos.Text = tools.obtenerParametroString("coefPuntos");
            bytes.Text = tools.obtenerParametroInt("bytes").ToString();
            claveAcceso.Text = tools.obtenerParametroString("claveAcceso");
            placaOutter.Checked = tools.obtenerParametroInt("placaOutter") == 0 ? false : true;
            eventosCierre.Checked = tools.obtenerParametroInt("eventosCierre") == 0 ? false : true;
            loggin.Checked = tools.obtenerParametroInt("loggin") == 0 ? false : true;

        }
                
        private void actualizarParametroString(string parametro, string valor)
        {
            SqlCommand comm;
            try
            {
                comm = new SqlCommand("update parametros set val1_string = '" + valor + "' where nombre = '" + parametro + "'", fConfigurator.conn);
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {                
            }
        }           

        private void actualizarParametroInt(string parametro,int valor)
        {
            SqlCommand comm;
            
            comm = new SqlCommand("update parametros set val1 = " + valor +" where nombre = '" + parametro + "'", fConfigurator.conn);            
            comm.ExecuteNonQuery();
        }

        private void AdjustWidthComboBox_DropDown(object sender, System.EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox)sender;
            int width = senderComboBox.DropDownWidth;
            Graphics g = senderComboBox.CreateGraphics();
            Font font = senderComboBox.Font;
            int vertScrollBarWidth =
                (senderComboBox.Items.Count > senderComboBox.MaxDropDownItems)
                ? SystemInformation.VerticalScrollBarWidth : 0;

            int newWidth;
            foreach (string s in ((ComboBox)sender).Items)
            {
                newWidth = (int)g.MeasureString(s, font).Width
                    + vertScrollBarWidth;
                if (width < newWidth)
                {
                    width = newWidth;
                }
            }
            senderComboBox.DropDownWidth = width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int obj;
            lblConfirmar.Visible = false;
            foreach (Control control in this.panelPrincipal.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    if (int.TryParse(control.Text, out obj) && control.Name != "claveAcceso")
                    {
                        actualizarParametroInt(control.Name, int.Parse(control.Text));
                    }
                    else
                        actualizarParametroString(control.Name, control.Text);
                }
                else if (control.GetType() == typeof(ComboBox))
                {
                    if(((ComboBox) control).SelectedItem != null)
                        actualizarParametroString(control.Name, ((ComboBox) control).SelectedItem.ToString());
                }
                else if (control.GetType() == typeof(CheckBox))
                {
                    if (((CheckBox)control).Checked)
                        actualizarParametroInt(control.Name, 1);
                    else
                        actualizarParametroInt(control.Name, 0);
                }
            }

            lblConfirmar.Text = "Los Cambios fueron guardados correctamente.";
            Thread.Sleep(300);
            lblConfirmar.Visible = true;
            fPrincipal_Load(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
                      
    }
}
