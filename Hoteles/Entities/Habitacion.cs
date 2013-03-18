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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static public Boolean Asignar(fPrincipal fPrincipal, int descuentoId, int nroHab, int pernocte, int conserjeId, int socioId, int puntos)
        {
            SqlCommand comm;
            if (pernocte == 0)
            {
                comm = new SqlCommand("asignarHabitacion", fPrincipal.conn);
                comm.CommandType = CommandType.StoredProcedure;
                if (descuentoId != 0)
                    comm.Parameters.AddWithValue("@descuentoId", descuentoId);
                comm.Parameters.AddWithValue("@nroHab", nroHab);
                comm.Parameters.AddWithValue("@pernocte", pernocte);
                comm.Parameters.AddWithValue("@conserjeId", conserjeId);
                if (socioId != 0)
                    comm.Parameters.AddWithValue("@socioId", socioId);
                if (puntos > 0)
                    comm.Parameters.AddWithValue("@puntos", puntos);
            }
            else
            {
                Tarifa tarifaNoche;
                decimal precioTotal = calcularPrecioConPernocte(nroHab, out tarifaNoche);
                decimal precioExtra = precioTotal - tarifaNoche.precio;
                if (precioTotal == 0)
                {
                    return false;
                }
                comm = new SqlCommand("asignarHabitacionTurnoNoche", fPrincipal.conn);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.AddWithValue("@nroHab", nroHab);
                comm.Parameters.AddWithValue("@tarifaId2", tarifaNoche.id);
                comm.Parameters.AddWithValue("@precioTotal", precioTotal - precioExtra);
                comm.Parameters.AddWithValue("@precioExtras", precioExtra);
                comm.Parameters.AddWithValue("@hasta", tarifaNoche.hasta);
                if (descuentoId != 0)
                    comm.Parameters.AddWithValue("@descuentoId", descuentoId);
                comm.Parameters.AddWithValue("@conserjeId", conserjeId);
                if (socioId != 0)
                    comm.Parameters.AddWithValue("@socioId", socioId);
                if (puntos > 0)
                    comm.Parameters.AddWithValue("@puntos", puntos);
            }

            comm.ExecuteNonQuery();
            comm.CommandText = "listaTurnos";
            comm.Parameters.Clear();
            fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());

            return true;
        }

        static public DetallesHabitacion obtenerDetalles(int nroHab)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("habitacion_detallesTurno", fPrincipal.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            try
            {
                dataAdapter.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                    return new DetallesHabitacion(ds.Tables[0].Rows[0]);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public static decimal calcularPrecioConPernocte(int nroHab, out Tarifa tarifaNoche)
        {
            decimal precioTotal;
            Tarifa tarifaActual = Tarifa.obtenerTarifaActual(nroHab, DateTime.MinValue);
            if (tarifaActual == null)// no se encontro tarifa.
            {
                tarifaNoche = tarifaActual;
                return 0;
            }
            if (tarifaActual.pernocte)
            {
                tarifaNoche = tarifaActual;
                if (DateTime.Now.Hour > 12) // Si son mas de las 12 del mediodia
                    tarifaNoche.hasta = tarifaNoche.hasta.AddDays(1);
                return tarifaActual.precioTN;
            }
            else
            {
                precioTotal = 0;
                TimeSpan diferencia;

                diferencia = tarifaActual.hasta.TimeOfDay - DateTime.Now.TimeOfDay;
                decimal precioParcial = (Decimal.Parse(diferencia.TotalMinutes.ToString()) * tarifaActual.precioMinuto);
                if (tarifaActual.precioTN != 0)
                {
                    precioTotal += (precioParcial > tarifaActual.precioTN ? tarifaActual.precioTN : precioParcial);
                }
                else
                    precioTotal += precioParcial;
                tarifaActual = Tarifa.obtenerTarifaActual(nroHab, tarifaActual.hasta);
                int cont = 0; // este cont es para salir en caso de que no este bien configurado las tarifas, las franjas horarias
                while (tarifaActual.pernocte == false && cont < 30)
                {
                    diferencia = tarifaActual.hasta.TimeOfDay - tarifaActual.desde.TimeOfDay;
                    precioParcial = (Decimal.Parse(diferencia.TotalMinutes.ToString()) * tarifaActual.precioMinuto);
                    if (tarifaActual.precioTN != 0)
                    {
                        precioTotal += (precioParcial > tarifaActual.precioTN ? tarifaActual.precioTN : precioParcial);
                    }
                    else
                        precioTotal += precioParcial;

                    // HAY QUE REVISARLO..... !!!!!!!!!!!!!!!!!!

                    tarifaActual = Tarifa.obtenerTarifaActual(nroHab, tarifaActual.hasta);
                    cont++;
                }
                if (cont > 29) // si salio por contador
                {
                    tarifaNoche = new Tarifa();
                    return 0;
                }
                precioTotal += tarifaActual.precioTN;                
                tarifaNoche = tarifaActual;
            }
            if (DateTime.Now.Hour > 12) // Si son mas de las 12 del mediodia
                tarifaNoche.hasta = tarifaNoche.hasta.AddDays(1);
            return precioTotal;

        }

        static public void Cancelar(fPrincipal fPrincipal, int nroHab)
        {
            SqlCommand comm;
            comm = new SqlCommand("habitacion_cancelar", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@nroHab", nroHab);

            comm.ExecuteNonQuery();
            comm.CommandText = "listaTurnos";
            comm.Parameters.Clear();
            fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());
            return;
        }

        internal static void Adelanto(fPrincipal fPrincipal, int nroHab, decimal monto, int mediopago)
        {
            SqlCommand comm;
            comm = new SqlCommand("habitacion_adelanto", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@monto", monto);
            comm.Parameters.AddWithValue("@medioPago", mediopago);

            comm.ExecuteNonQuery();
            comm.CommandText = "listaTurnos";
            comm.Parameters.Clear();
            fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());

        }

        internal static void Cierre(fPrincipal fPrincipal, int nroHab, decimal descPorArt,decimal descuento, int medioPago)
        {
            SqlCommand comm = new SqlCommand("turnos_cerrar", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@descuento", descuento);
            comm.Parameters.AddWithValue("@descPorArt", descPorArt);
            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@medioPago", medioPago);

            comm.ExecuteNonQuery();
            comm.CommandText = "listaTurnos";
            comm.Parameters.Clear();
            fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());

        }

        static public DataRow preCierre(int nroHab)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("turnos_preCierre", fPrincipal.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            try
            {
                dataAdapter.Fill(ds);
                
                return ds.Tables[0].Rows[0];
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        internal static List<Aviso> obtenerAvisos(int nroHab)
        {
            DataSet ds = new DataSet();
            List<Aviso> avisos = new List<Aviso>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("avisos_obtenerPorHabitacion", fPrincipal.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            try
            {
                dataAdapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    avisos.Add(new Aviso(int.Parse(row[0].ToString()), row[1].ToString(), int.Parse(row[2].ToString())));
                }

                return avisos;
            }
            catch (Exception ex)
            {
                log.Error(" Habitacion.CS , metodo: obtenerAvisos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer Avisos/Alarmas de la BD *");
            }
        }

        internal static List<Aviso> listadoAvisos()
        {
            DataSet ds = new DataSet();
            List<Aviso> avisos = new List<Aviso>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from avisos", fPrincipal.conn);
            try
            {
                dataAdapter.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    avisos.Add(new Aviso(int.Parse(row[0].ToString()), row[1].ToString()));
                }

                return avisos;
            }
            catch (Exception ex)
            {
                log.Error(" Habitacion.CS , metodo: listadoAvisos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer listado de Avisos de la BD *");
            }
        }

        internal static void agregarAviso(fPrincipal fPrincipal, int nroHab, int hora, int avisoSel)
        {

            SqlCommand comm = new SqlCommand("avisos_asignar", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@hora", hora);
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();
                        
            comm.CommandText = "listaTurnos";
            comm.Parameters.Clear();
            fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());

        }

        internal static void quitarAviso(fPrincipal fPrincipal,int nroHab, int avisoSel)
        {
            SqlCommand comm = new SqlCommand("avisos_quitar", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();
            
            comm.CommandText = "listaTurnos";
            comm.Parameters.Clear();
            fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());
        }
        internal static void quitarAviso(int nroHab, int avisoSel)
        {
            SqlCommand comm = new SqlCommand("avisos_quitar", fPrincipal.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();           
        }

        
    }

    public class DetallesHabitacion
    {
        public string nroPromo;
        public string nombrePromo;
        public string nroSocio;
        public int pernocte;
        public string ptosCambiados;
        public decimal impHabitacion;


        public DetallesHabitacion(){}
        public DetallesHabitacion(DataRow dr)
        {
            nroPromo = dr["descuentoId"].ToString();
            nombrePromo = dr["nombre"].ToString();
            nroSocio = dr["nroSocio"].ToString();
            pernocte = dr["pernocte"].ToString() == "False" ? 0 : 1;
            ptosCambiados = dr["puntos"].ToString();
            impHabitacion = decimal.Parse(dr["impHabitacion"].ToString());

        }
    }
}
