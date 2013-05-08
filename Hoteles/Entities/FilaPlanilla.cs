using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Hoteles.Entities
{
    class FilaPlanilla
    {
        public int nro;
        public int nroHab;
        public DateTime desde;
        public DateTime hasta;
        public string socio;

        public decimal turnos;
        public decimal extras;
        public decimal bar;
        public decimal descuento;
        public decimal total;

        public decimal efectivo;
        public decimal tarjeta;
        public decimal gastos;

        public string cuentaGasto;

        public FilaPlanilla() { }

        public FilaPlanilla(DataRow dr,int nroOrd)
        {
            this.nro = nroOrd;
            if (dr.ItemArray.Length >= 10)
            {
                this.nroHab = int.Parse(dr["nroHabitacion"].ToString());
                this.desde = DateTime.Parse(dr["desde"].ToString());
                DateTime.TryParse(dr["horaCierre"].ToString(), out this.hasta);
                this.socio = dr["nroSocio"].ToString();                

                this.turnos = decimal.Parse(dr["impHabitacion"].ToString());
                this.extras = decimal.Parse(dr["impExtras"].ToString());
                this.bar = decimal.Parse(dr["impArticulos"].ToString());
                this.descuento = decimal.Parse(dr["descuentoAlCierre"].ToString()) + decimal.Parse(dr["descuentos"].ToString());
                this.total = this.turnos + this.extras + this.bar - this.descuento;

                this.efectivo = decimal.Parse(dr["efectivo"].ToString());
                this.tarjeta = decimal.Parse(dr["tarjeta"].ToString());
            }
            else  // Es gasto
            {
                this.gastos = decimal.Parse(dr["monto"].ToString());
                this.cuentaGasto = dr["nombre"].ToString();
                this.desde = DateTime.Parse(dr["fecha"].ToString());
            }
        }

        public override string ToString()
        {
            if (nroHab > 0)
            {
                return (nro == 0 ? "" : nro.ToString()).PadRight(3) + "  " +
                       (nroHab == 0 ? "" : nroHab.ToString()).PadLeft(2).PadRight(4) + " " +
                       desde.ToString("HH:mm") + "  " +
                       (hasta == DateTime.MinValue ? "   " : hasta.ToString("HH:mm")) + "   " +
                        socio.ToString().PadLeft(3).PadRight(6) + "  " +
                       (turnos == 0 ? "" : turnos.ToString()).PadLeft(8) + "    " +
                       (extras == 0 ? "" : extras.ToString()).PadLeft(6) + "    " +
                       (bar == 0 ? "" : bar.ToString()).PadLeft(6) + "    " +
                       (descuento == 0 ? "" : descuento.ToString()).PadLeft(6) + "     " +
                       (total == 0 ? "" : total.ToString()).PadLeft(8) + "    " +
                       (efectivo == 0 ? "" : efectivo.ToString()).PadLeft(8) + "   " +
                       (tarjeta == 0 ? "" : tarjeta.ToString()).PadLeft(8) + "     " +
                       (gastos == 0 ? "" : gastos.ToString()).PadLeft(8);
            }
            else
            {
                return (nro == 0 ? "" : nro.ToString()).PadRight(3) + "  " +
                      (nroHab == 0 ? "" : nroHab.ToString()).PadLeft(2).PadRight(4) + " " +
                      desde.ToString("HH:mm") + "  " +
                      (hasta == DateTime.MinValue ? "   " : hasta.ToString("HH:mm")) + "   " +
                       socio.ToString().PadLeft(3).PadRight(84) + "    " +                      
                       gastos.ToString().PadLeft(8);
            }
        }
    }
}
