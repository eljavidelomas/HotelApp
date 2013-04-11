using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hoteles.Entities
{
    public class Calendario
    {

        public static int nroDia(DateTime fecha)
        {
            int dia = (int)DateTime.Today.DayOfWeek;
            return dia;
        }

        public static int nroDiaSig(DateTime fecha)
        {
            int dia = (int)DateTime.Today.AddDays(1).DayOfWeek;
            return dia;
        }

        public static int nroDiaAnt(DateTime fecha)
        {
            int dia = (int)DateTime.Today.AddDays(-1).DayOfWeek;
            return dia;
        }

        public void dameNroDia(out int dia,out int diaAnt)
        {
            dia = (int)DateTime.Today.DayOfWeek;
            diaAnt = (int) DateTime.Today.AddDays(-1).DayOfWeek;
        }

        public void dameNroDiaSig(out int dia, out int diaSig)
        {
            dia = (int)DateTime.Today.DayOfWeek;
            diaSig = (int)DateTime.Today.AddDays(1).DayOfWeek;
        }

    }
}
