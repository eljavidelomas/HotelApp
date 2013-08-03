using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Administrador
{
    public class Controlador
    {

        internal static bool procesarComando(TabPage tabPage, Keys keyData)
        {
            switch (tabPage.Name)
            {
                case "tpHabitaciones":
                    DataSet dsHab;
                    TextBox nroHab = (TextBox)tabPage.Controls.Find("txtHab_nro", true)[0];
                    if (nroHab.Focused)
                    {

                        if ((dsHab = existeHabitacion(nroHab.Text)).Tables.Count > 0)
                        {
                            //tabPage.
                        }
                        //else
                            //insertar;
                    }
                    break;

                default:
                    break;
            }
            throw new NotImplementedException();
        }

        private static DataSet existeHabitacion(string p)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from habitaciones where nroHabitacion = " + p, FAdministrador.conn);
            dataAdapter.Fill(ds);

            return ds;          
        }
    }
}
