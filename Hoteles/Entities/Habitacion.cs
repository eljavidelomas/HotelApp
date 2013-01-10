using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Hoteles.Entities
{
    public class Habitacion
    {
        public int id;
        public int nroHabitacion;
        public bool habilitada;
        public int categoriaId;
        public char estado;


        static public Boolean Asignar(fPrincipal fPrincipal, int descuentoId, int nroHab, int pernocte,int conserjeId,int socioId)
        {                      
            SqlCommand comm = new SqlCommand("asignarHabitacion", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;
            if(descuentoId != 0)
                comm.Parameters.AddWithValue("@descuentoId", descuentoId);
            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@pernocte", pernocte);
            comm.Parameters.AddWithValue("@conserjeId", conserjeId);
            if(socioId != 0)
                comm.Parameters.AddWithValue("@socioId", socioId);
            comm.ExecuteNonQuery();            

            comm.CommandText = "listaTurnos";
            comm.Parameters.Clear();
            
            fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());
            
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
