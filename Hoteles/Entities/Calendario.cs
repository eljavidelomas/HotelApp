using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public class Calendario
    {

        public static int nroDia(DateTime fecha)
        {
            int dia = dameTipoDia(fecha);
            if(dia == -1)
                dia = (int)fecha.DayOfWeek;

            return dia;
        }

        public static int nroDiaSig(DateTime fecha)
        {
            int dia = dameTipoDia(fecha.AddDays(1));
            if (dia == -1)
                dia = (int)fecha.AddDays(1).DayOfWeek;

            return dia;
        }

        public static int nroDiaAnt(DateTime fecha)
        {
            int dia = dameTipoDia(fecha.AddDays(-1));
            if (dia == -1)
                dia = (int)fecha.AddDays(-1).DayOfWeek;
            
            return dia;
        }

        private static int dameTipoDia(DateTime fecha)
        {
            SqlCommand comm = new SqlCommand("feriados_DameDia", fPrincipal2.conn);
            comm.CommandType = System.Data.CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@dia", fecha.Day);
            comm.Parameters.AddWithValue("@mes", fecha.Month);
            
            return Convert.ToInt32(comm.ExecuteScalar());            
        }

        //public void dameNroDia(out int dia,out int diaAnt)
        //{
        //    dia = (int)DateTime.Today.DayOfWeek;
        //    diaAnt = (int) DateTime.Today.AddDays(-1).DayOfWeek;
        //}

        //public void dameNroDiaSig(out int dia, out int diaSig)
        //{
        //    dia = (int)DateTime.Today.DayOfWeek;
        //    diaSig = (int)DateTime.Today.AddDays(1).DayOfWeek;
        //}

    }
}
