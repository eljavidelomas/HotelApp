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

        internal static void Adelanto(fPrincipal fPrincipal,int nroHab, decimal monto, int mediopago)
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
    }

    public class DetallesHabitacion
    {
        public string nroPromo;
        public string nombrePromo;
        public string nroSocio;
        public int pernocte;
        public string ptosCambiados;
        public decimal impHabitacion;

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
