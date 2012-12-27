using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hoteles.Entities
{
    public class Habitacion
    {   

        static public Boolean asignar(fPrincipal fPrincipal)
        {            
            //fPrincipal.input1.funcion = "asignar";
            //fPrincipal.label1.Text = "Nro. Habitación:";            
            //fPrincipal.input1.Focus();
            //fPrincipal.fIngresos.Visible = true;
            return true;
        }

        static public Boolean mostarPromo(fPrincipal fPrincipal)
        {
            //fPrincipal.input1.funcion = "mostrarPromo";
            //fPrincipal.input1.ResetText();
            //fPrincipal.label1.Text = "Código Promoción:";
            //fPrincipal.input1.Focus();
            return true;
        }


        static public Boolean cancelar(fPrincipal fPrincipal)
        {   
            //fPrincipal.input1.funcion = "cancelar";
            //fPrincipal.label1.Text = "Nro. Habitación:";
            //fPrincipal.input1.Focus();
            //fPrincipal.fIngresos.Visible = true;
            return true;
        }

    }
}
