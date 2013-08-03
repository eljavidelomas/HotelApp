using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public class Tarifa
    {
        public int id;

        public int categoriaId;
        public DateTime desde;
        public DateTime hasta;
        public int dia;
        public int duracion;
        public decimal precio;
        public decimal precioMinuto;
        public bool pernocte;
        public int extension;
        public decimal extensionPrecio;
        public int tolerancia;
        public decimal precioTN;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public Tarifa()
        {
            id = 0;
        }

        public Tarifa(DataRow dr)
        {
            id = int.Parse(dr["id"].ToString());
            if (id > 0)
            {
                categoriaId = int.Parse(dr["catId"].ToString());
                DateTime fecha = DateTime.Now;
                desde = new DateTime(fecha.Year, fecha.Month, fecha.Day, DateTime.Parse(dr["desde"].ToString()).Hour, DateTime.Parse(dr["desde"].ToString()).Minute, 0);
                int diferenciaDias = Math.Abs( Calendario.nroDia(desde) - int.Parse(dr["dia"].ToString()));
                if ( diferenciaDias != 0)
                {
                    if ( Calendario.nroDia(desde.AddDays(-1)) == int.Parse(dr["dia"].ToString()))
                        desde = desde.AddDays(-1);
                    if ( Calendario.nroDia(desde.AddDays(1)) == int.Parse(dr["dia"].ToString()))                    
                        desde = desde.AddDays(1);
                }
                if (dr["hasta"].ToString() != "")
                {
                    hasta = new DateTime(desde.Year, desde.Month, desde.Day, DateTime.Parse(dr["hasta"].ToString()).Hour, DateTime.Parse(dr["hasta"].ToString()).Minute, 0);                    
                    if (hasta.TimeOfDay < desde.TimeOfDay)
                        hasta = hasta.AddDays(1);                    
                }

                int.TryParse(dr["dia"].ToString(), out dia);
                int.TryParse(dr["duracion"].ToString(), out duracion);
                decimal.TryParse(dr["precio"].ToString(), out precio);
                decimal.TryParse(dr["precioMinuto"].ToString(), out precioMinuto);
                int.TryParse(dr["extension"].ToString(), out extension);
                decimal.TryParse(dr["extensionPrecio"].ToString(), out extensionPrecio);
                int.TryParse(dr["tolerancia"].ToString(), out tolerancia);
                decimal.TryParse(dr["precioTN"].ToString(), out precioTN);
                bool.TryParse(dr["pernocte"].ToString(), out pernocte);
            }


        }

        public Tarifa(DataRow dr,DateTime hora)
        {
            id = int.Parse(dr["id"].ToString());
            if (id > 0)
            {
                categoriaId = int.Parse(dr["catId"].ToString());
                DateTime fecha = hora;
                desde = new DateTime(fecha.Year, fecha.Month, fecha.Day, DateTime.Parse(dr["desde"].ToString()).Hour, DateTime.Parse(dr["desde"].ToString()).Minute, 0);
                int diferenciaDias = Math.Abs(Calendario.nroDia(desde) - int.Parse(dr["dia"].ToString()));
                if (diferenciaDias != 0)
                {
                    if (Calendario.nroDia(desde.AddDays(-1)) == int.Parse(dr["dia"].ToString()))
                        desde = desde.AddDays(-1);
                    if (Calendario.nroDia(desde.AddDays(1)) == int.Parse(dr["dia"].ToString()))
                        desde = desde.AddDays(1);
                }
                if (dr["hasta"].ToString() != "")
                {
                    hasta = new DateTime(desde.Year, desde.Month, desde.Day, DateTime.Parse(dr["hasta"].ToString()).Hour, DateTime.Parse(dr["hasta"].ToString()).Minute, 0);
                    if (hasta.TimeOfDay < desde.TimeOfDay)
                        hasta = hasta.AddDays(1);
                }

                int.TryParse(dr["dia"].ToString(), out dia);
                int.TryParse(dr["duracion"].ToString(), out duracion);
                decimal.TryParse(dr["precio"].ToString(), out precio);
                decimal.TryParse(dr["precioMinuto"].ToString(), out precioMinuto);
                int.TryParse(dr["extension"].ToString(), out extension);
                decimal.TryParse(dr["extensionPrecio"].ToString(), out extensionPrecio);
                int.TryParse(dr["tolerancia"].ToString(), out tolerancia);
                decimal.TryParse(dr["precioTN"].ToString(), out precioTN);
                bool.TryParse(dr["pernocte"].ToString(), out pernocte);
            }


        }

        public decimal PrecioExtension()
        {
            if (this.extensionPrecio != 0)
                return extensionPrecio;
            else
                return this.extension * precioMinuto;
        }

        //public decimal obtenerPrecioMinutos(Tarifa tar,DateTime desde,DateTime hasta)
        //{
        //    decimal precioMinutoExtension;
        //    TimeSpan difMin = hasta - desde;
        //    precioMinutoExtension = obtenerPrecioExtensiones(tar);

        //    return precioMinutoExtension * (decimal)difMin.TotalMinutes;
        //}

        //public decimal obtenerPrecioExtensiones(Tarifa tarSig)
        //{
        //    double precioMinutoExtension;

        //    if (tarSig.extensionPrecio != null)
        //    {
        //        precioMinutoExtension = (double)tarSig.extensionPrecio / tarSig.extension;
        //    }
        //    else
        //    {
        //        precioMinutoExtension = (double)tarSig.precioMinuto;
        //    }

        //    return Convert.ToDecimal(precioMinutoExtension);
        //}

        public static decimal calcularPrecioConPernocte(int catId, out Tarifa tarifaNoche)
        {
            DateTime hora = DateTime.Now;            
            Tarifa tarSig;
            decimal precioTotal = 0;
            int dia = Calendario.nroDia(hora);
            int diaSig = Calendario.nroDiaSig(hora);
            int diaAnt = Calendario.nroDiaAnt(hora);
            
            Tarifa tar = obtenerTarifaActual(catId, dia, diaAnt, hora);
            if (tar == null)// no se encontro tarifa
            {
                tarifaNoche = null;
                return 0;
            }
            if (tar.pernocte)
            {
                tarifaNoche = tar;
                return tar.precioTN;
            }

            while (true)
            {
                int contadorOverflow = 0;
                tarSig = Tarifa.obtenerTarifaSiguiente(catId, dia, diaSig, tar, hora);
                if (tarSig.pernocte)
                {
                    decimal precioAux = Tarifa.obtenerPrecioDesdeHasta(tar, hora, tarSig.desde);
                    // 16-7-2013 Un bug, cuando hay hasta y es diferente de desde del sigueinte calcula mal
                    if (tar.hasta != DateTime.MinValue && precioAux > tar.precioTN)
                    {
                        decimal precioAux2 = 0;
                        precioAux = tar.precioTN;

                        if (tar.hasta < tarSig.desde)// si el hasta es menor al desde del turno noche obtengo la tar actual
                        {
                            Tarifa tarAux2 = obtenerTarifaActual(catId, Calendario.nroDia(tar.hasta), Calendario.nroDiaAnt(tar.hasta), tar.hasta);
                            precioAux2 = Tarifa.obtenerPrecioDesdeHasta(tarAux2, tar.hasta, tarSig.desde);
                            precioAux2 = precioAux2 > 0 ? precioAux2 : 0;
                        }

                        precioAux += precioAux2;

                    }

                    precioTotal += precioAux;
                    precioTotal += tarSig.precioTN;
                    tarifaNoche = tarSig;

                    return precioTotal;
                }

                //Calcular precio teniendo en cuenta condiciones
                if (tar.hasta != DateTime.MinValue)
                {
                    decimal precioAux2 = obtenerPrecioDesdeHasta(tar, hora, tar.hasta);
                    if (precioAux2 > tar.precioTN)
                        precioAux2 = tar.precioTN;
                    precioTotal += precioAux2;
                    hora = tar.hasta;
                }
                else
                {
                    precioTotal = obtenerPrecioDesdeHasta(tar, hora, tarSig.desde);
                    hora = tarSig.desde;
                }
                tar = tarSig;
                contadorOverflow++;
                if (contadorOverflow > 50)
                {
                    tarifaNoche = null;
                    return 0;
                }
                ////////////////////////////////////////////////////////////////////
            }
        }


        public static decimal obtenerPrecioActualizadoPorHabitacion(int nroHab)
        {
            decimal precioASumar;
            Tarifa tar = obtenerTarifaInicial(nroHab,DateTime.Now);
            DetallesHabitacion det = Habitacion.obtenerDetalles(nroHab);
            int diaAct = Calendario.nroDia(DateTime.Now);
            int diaAnt = Calendario.nroDiaAnt(DateTime.Now);
            int diaSig = Calendario.nroDiaSig(DateTime.Now);


            if (tar.hasta == DateTime.MinValue)// Si no tiene seteado el campo hasta, entonces...
            {
                Tarifa tActual = obtenerTarifaActual(det.catId, diaAct, diaAnt, DateTime.Now);
                Tarifa tSig = Tarifa.obtenerTarifaSiguiente(det.catId, diaAct, diaSig, tActual, DateTime.Now);
                det.hasta.AddMinutes(tActual.extension);
                if (tActual.extensionPrecio != 0)
                    precioASumar = tActual.extensionPrecio;
                else
                    precioASumar = tActual.precioMinuto * tActual.extension;

                actualizarTurno(nroHab, precioASumar, det.hasta);

                return det.impHabitacion + precioASumar;
            }
            else
            {

                return 0;
            }            
        }

        private static void actualizarTurno(int nroHab, decimal precioASumar, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public static decimal obtenerPrecioDesdeHasta(Tarifa tar, DateTime desde, DateTime hasta)
        {
            decimal precioTotal = 0;
            TimeSpan difMin = hasta - desde;
            double cantidadMinutos = difMin.TotalMinutes;
            if (difMin.TotalMinutes > (tar.duracion + tar.tolerancia))
            {
                precioTotal += tar.precio;
                cantidadMinutos -= (tar.duracion + tar.tolerancia);
                precioTotal += (decimal)cantidadMinutos * obtenerPrecioXMinuto(tar);
            }
            else
            {
                precioTotal = (decimal)cantidadMinutos * tar.precioMinuto;
            }

            return precioTotal;
        }

        public static decimal obtenerPrecioXMinuto(Tarifa tarSig)
        {
            double precioMinutoExtension;

            if (tarSig.extensionPrecio != 0)
            {
                precioMinutoExtension = (double)tarSig.extensionPrecio / tarSig.extension;
            }
            else
            {
                precioMinutoExtension = (double)tarSig.precioMinuto;
            }

            return Convert.ToDecimal(precioMinutoExtension);
        }

        public static Tarifa obtenerTarifaActual(int catId, int dia, int diaAnt, DateTime hora)
        {
            DataSet ds = new DataSet();
            Tarifa tarifa;
            SqlDataAdapter dataAdapter = new SqlDataAdapter("tarifas_obtenerActual", fPrincipal2.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@catId", catId);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@dia", dia);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@diaAnt", diaAnt);
            if (hora != DateTime.MinValue)
                dataAdapter.SelectCommand.Parameters.AddWithValue("@hora", hora);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    tarifa = new Tarifa(ds.Tables[0].Rows[0]);
                else
                    tarifa = new Tarifa(ds.Tables[1].Rows[0]);

                if (tarifa.desde.Day == hora.Day) // Si es el mismo dia del mes
                {
                    if (tarifa.desde.TimeOfDay > hora.TimeOfDay) // y la hora desde es mayor a la hora actual
                    {
                        tarifa.desde = tarifa.desde.AddDays(-1); // pongo fecha de ayer.
                    }
                }
            }
            catch (Exception ex)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    log.Info("Tarifa.obtenerTarifaActual - No se encontro tarifa. Datos: SP:obtenerTarifaConId; catId:" + catId + " hora:" + hora.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    log.Error("Tarifa.obtenerTarifaActual = " + ex.Message + ex.StackTrace);

                tarifa = null;
            }

            return tarifa;
        }


        public static Tarifa obtenerTarifaSiguiente(int catId, int diaAct, int diaSig, Tarifa tar, DateTime hora)
        {
            DataSet ds = new DataSet();
            Tarifa tarifaSig;
            
            int diaAnt = Calendario.nroDiaAnt(hora);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("tarifas_obtenerSiguiente", fPrincipal2.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@catId", catId);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@dia", diaAct);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@diaSig", diaSig);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@hora", hora);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (tar.hasta != DateTime.MinValue)
            {
                if (tar.hasta < hora )// Si hubo cruce de dias // REVISAR 2-7-2013
                {
                    diaAnt = diaAct;
                    diaAct = Calendario.nroDia(hora.AddDays(1));
                }
                Tarifa aux = obtenerTarifaActual(catId, diaAct, diaAnt, tar.hasta);
                if (aux.categoriaId == tar.categoriaId && aux.dia == tar.dia && aux.desde == tar.desde)// si es la misma
                {                    
                    dataAdapter.Fill(ds);
                    tarifaSig = new Tarifa(ds.Tables[ds.Tables.Count - 1].Rows[0]);

                    if (tarifaSig.desde.Day == hora.Day) // Si es el mismo dia del mes
                    {
                        if (tarifaSig.desde.TimeOfDay < hora.TimeOfDay) // y la hora desde es menor a la hora actual
                        {
                            tarifaSig.desde = tarifaSig.desde.AddDays(1); // pongo fecha de mañana.
                        }
                    }

                    return tarifaSig;
                }
                else
                    return obtenerTarifaActual(catId, diaAct, diaAnt, tar.hasta);
            }
                        
            try
            {
                dataAdapter.Fill(ds);
                tarifaSig = new Tarifa(ds.Tables[ds.Tables.Count-1].Rows[0]);

                if (tar.desde > tarifaSig.desde) // Si la fecha tarAnterior es mas actual que la siguiente , al asiguiente le sumo 1 dia.
                {
                    tarifaSig.desde = tarifaSig.desde.AddDays(1);
                    if(tarifaSig.hasta!= DateTime.MinValue)
                        tarifaSig.hasta= tarifaSig.hasta.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    log.Info("Tarifa.obtenerTarifaActual - No se encontro tarifa. Datos: SP:obtenerTarifaConId; catId:" + catId + " hora:" + hora.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                    log.Error("Tarifa.obtenerTarifaActual = " + ex.Message + ex.StackTrace);

                tarifaSig = null;
            }

            return tarifaSig;
        }

        public static Tarifa obtenerTarifaInicial(int nroHab,DateTime hora)
        {
            DataSet ds = new DataSet();
            Tarifa tarifa = new Tarifa();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("tarifas_obtenerInicial", fPrincipal2.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);            
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                if (ds.Tables[0].Rows.Count == 1)
                    tarifa = new Tarifa(ds.Tables[0].Rows[0],hora);
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(ex.Message + "-" + ex.StackTrace);                
            }

            return tarifa;
        }

    }
}
