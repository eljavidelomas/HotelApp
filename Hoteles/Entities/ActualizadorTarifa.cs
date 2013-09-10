using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hoteles.Entities
{
    public static class ActualizadorTarifa
    {
        static public Dictionary<int, decimal> contPernocte = new Dictionary<int, decimal>();
        static public Dictionary<int, bool> bitHasta = new Dictionary<int, bool>();


        static public bool actualizarTarifa(DetallesHabitacion tur, Tarifa tarIni, DataGridViewRow dr)
        {
            Tarifa tarAct;
            DateTime now = DateTime.Now;
            int nroVuelta = 0;

            if (tarIni.hasta != DateTime.MinValue)
            {
                if (tarIni.hasta > now)
                {
                    bitHasta[tur.nroHab] = true;
                    tarAct = tarIni;
                    bucle1(tur, tarAct, now, tarIni, dr);

                    return true;
                }
                else
                {
                    if (!bitHasta.ContainsKey(tur.nroHab) || bitHasta[tur.nroHab])
                    {
                        bitHasta[tur.nroHab] = false;
                        contPernocte[tur.nroHab] = 0;
                    }
                    return bucle0(tur, out tarAct, now, tarIni, dr);
                }
            }
            else // No
            {
                return bucle0(tur, out tarAct, now, tarIni, dr);
            }
        }

        private static bool bucle0(DetallesHabitacion tur, out Tarifa tarAct, DateTime now, Tarifa tar, DataGridViewRow dr)
        {
            tarAct = Tarifa.obtenerTarifaActual(tur.catId, Calendario.nroDia(now), Calendario.nroDiaAnt(now), now);
            if (tarAct == null)
                return false;

            if (tarAct.pernocte) // si
            {
                bucle1(tur, tarAct, now, tar, dr);
            }
            else // no
            {
                contPernocte[tur.nroHab] = 0;
                bucle4(false, tur, tur.nroHab, now, tarAct, dr);
            }

            return true;
        }

        private static void bucle1(DetallesHabitacion tur, Tarifa tarAct, DateTime now, Tarifa tar, DataGridViewRow dr)
        {
            decimal precioTotal = tools.redondeo(contPernocte[tur.nroHab] + tarAct.PrecioExtension());
            
            if (precioTotal >= tarAct.precioTN) // Si supero el precio turno noche
            {
                decimal montoAsumar = tools.redondeo(tarAct.precioTN - contPernocte[tur.nroHab]);
                tur.impHabitacion += montoAsumar;
                tur.hasta = tarAct.hasta;
                updateDetallesTurno(tur.nroHab, montoAsumar, tur.hasta, tarAct.precioTN, dr);
                contPernocte[tur.nroHab] = tarAct.precioTN;
            }
            else // No
            {
                bucle4(true, tur, tur.nroHab, now, tarAct, dr);
            }
        }

        static void bucle4(bool sumCont, DetallesHabitacion tur, int nroHab, DateTime hora, Tarifa tar, DataGridViewRow dr)
        {
            decimal monto;

            Tarifa tarSig = obtenerTarSiguiente(tur.catId, Calendario.nroDia(DateTime.Now), Calendario.nroDiaSig(DateTime.Now), hora);
            if (tur.hasta.AddMinutes(tar.extension) > tarSig.desde)
            {
                monto = calcularPrecioExtDesdeHasta(tar, tur.hasta, tarSig.desde);
                tur.hasta = tarSig.desde;
            }
            else
            {
                monto = tar.PrecioExtension();
                tur.hasta = tur.hasta.AddMinutes(tar.extension);
            }
            monto = tools.redondeo(monto);
            tur.impHabitacion += monto;
            if (sumCont)
                contPernocte[nroHab] += monto;
            updateDetallesTurno(nroHab, monto, tur.hasta, contPernocte[nroHab], dr);
        }

        public static void updateDetallesTurno(int nroHab, decimal montoAsumar, DateTime hasta, decimal contPernocte, DataGridViewRow dr)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("turnos_actualizar", fPrincipal2.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@monto", montoAsumar);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@hasta", hasta);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@contPern", contPernocte);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.ExecuteNonQuery();
            dr.Cells[9].Value = hasta;// h.salida datetime
            dr.Cells[6].Value = hasta.ToString("HH:mm");//h.salida datetime
            dr.Cells[7].Value = (decimal.Parse(dr.Cells[7].Value.ToString().Replace("$ ", "")) + montoAsumar).ToString("C");// importe
        }

        static public Tarifa obtenerTarSiguiente(int catId, int diaAct, int diaSig, DateTime horaAct)
        {
            DataSet ds = new DataSet();
            Tarifa tarifaSig;

            int diaAnt = Calendario.nroDiaAnt(horaAct);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("tarifas_obtenerSiguiente", fPrincipal2.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@catId", catId);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@dia", diaAct);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@diaSig", diaSig);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@hora", horaAct);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.Fill(ds);

            try
            {
                tarifaSig = new Tarifa(ds.Tables[ds.Tables.Count - 1].Rows[0]);

                if (tarifaSig.desde.Day == horaAct.Day) // Si es el mismo dia del mes
                {
                    if (tarifaSig.desde.TimeOfDay < horaAct.TimeOfDay) // y la hora desde del sig es menor a la hora actual
                    {
                        tarifaSig.desde = tarifaSig.desde.AddDays(1); // pongo fecha de mañana.
                    }
                }
            }
            catch (Exception ex)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    LoggerProxy.Info("ActualizadorTarifa.obtenerTarSiguiente - No se encontro tarifa Siguiente. Datos: catId:" + catId + " hora:" + horaAct.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    LoggerProxy.Error("ActualizadorTarifa.obtenerTarSiguiente  = " + ex.Message + " - " + ex.StackTrace);

                tarifaSig = null;
            }

            return tarifaSig;
        }

        public static decimal calcularPrecioExtDesdeHasta(Tarifa tar, DateTime desde, DateTime hasta)
        {
            double precioTotal = 0;
            TimeSpan difMin = hasta - desde;
            double cantidadMinutos = difMin.TotalMinutes;

            if (tar.extensionPrecio != 0)
            {
                precioTotal = ((double)tar.extensionPrecio / tar.extension) * cantidadMinutos;
            }
            else
            {
                precioTotal = (double)tar.precioMinuto * cantidadMinutos;
            }

            return Convert.ToDecimal(precioTotal);
        }

    }
}
