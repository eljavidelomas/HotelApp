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

        private Tarifa(DataRow dr)
        {
            id = int.Parse(dr["id"].ToString());
            if (id > 0)
            {
                categoriaId = int.Parse(dr["catId"].ToString());
                DateTime fecha = DateTime.Parse(dr["desde"].ToString());
                //if (fecha.TimeOfDay > DateTime.Now.TimeOfDay)                
                //    fecha = DateTime.Now.AddDays(-1);                
                //else
                    fecha = DateTime.Now;
                desde = new DateTime(fecha.Year, fecha.Month, fecha.Day, DateTime.Parse(dr["desde"].ToString()).Hour, DateTime.Parse(dr["desde"].ToString()).Minute, 0);

                if (dr["hasta"].ToString() != "")
                {
                    DateTime fechaHasta = DateTime.Parse(dr["hasta"].ToString());
                    if (fechaHasta < desde)
                        fechaHasta = fechaHasta.AddDays(1);
                    hasta = new DateTime(fechaHasta.Year, fechaHasta.Month, fechaHasta.Day, DateTime.Parse(dr["hasta"].ToString()).Hour, DateTime.Parse(dr["hasta"].ToString()).Minute, 0);
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
                tarSig = Tarifa.obtenerTarifaSiguiente(catId, dia, diaSig, tar, hora);//falta desarrollar esta funcion teniendo en cuenta que si tar.hasta existe y es mayor a hora...
                if (tarSig.pernocte)
                {
                    decimal precioAux = Tarifa.obtenerPrecioDesdeHasta(tar, hora, tarSig.desde);
                    if (tar.hasta != DateTime.MinValue && precioAux > tar.precioTN)
                        precioAux = tar.precioTN;

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
                ////////////////////////////////////////////////////////////////////
            }
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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("tarifas_obtenerActual", fPrincipal.conn);
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
            Tarifa tarifa;
            //int diaAct;
            int diaAnt = Calendario.nroDiaAnt(hora);
            SqlDataAdapter dataAdapter = new SqlDataAdapter("tarifas_obtenerSiguiente", fPrincipal.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@catId", catId);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@dia", diaAct);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@diaSig", diaSig);
            if (tar.hasta != DateTime.MinValue)
            {
                if (tar.hasta < hora)// Si hubo cruce de dias
                {
                    diaAnt = diaAct;
                    diaAct = Calendario.nroDia(hora.AddDays(1));
                }
                return obtenerTarifaActual(catId, diaAct, diaAnt, tar.hasta);
            }
            else
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@hora", hora);
            }
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                dataAdapter.Fill(ds);
                tarifa = new Tarifa(ds.Tables[0].Rows[0]);
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

    }
}
