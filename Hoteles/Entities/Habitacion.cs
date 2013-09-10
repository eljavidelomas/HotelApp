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

        static public Boolean Asignar(fPrincipal2 fPrincipal, int descuentoId, int nroHab, int pernocte, int catId, int conserjeId, int socioId, int puntos, decimal montoApagar,Tarifa tarifaNoche,decimal descTotalHabitacion,decimal impExtra)
        {
            try
            {
                SqlCommand comm;
                int dia = Calendario.nroDia(DateTime.Now);
                int diaAnt = Calendario.nroDiaAnt(DateTime.Now);
                
                if (pernocte == 0)
                {
                    Tarifa tarActual = Tarifa.obtenerTarifaActual(catId, dia, diaAnt, DateTime.Now);
                    Tarifa tarSig = Tarifa.obtenerTarifaActual(catId, dia, diaAnt, DateTime.Now.AddMinutes(tarActual.duracion));
                    decimal precioSumarContador = 0;
                    if (tarSig.pernocte)
                    {
                        if (tarSig.desde < DateTime.Now.AddMinutes(tarActual.duracion)) // Si desde= 10:00 y hasta= 11:00 tengo que poner en el contador 1 hora en $$$
                        {
                            decimal precioAux = tools.redondeo(Tarifa.obtenerPrecioDesdeHasta(tarActual, DateTime.Now, tarSig.desde));
                            precioSumarContador = tarActual.precio - precioAux;
                        }                      
                    }

                    comm = new SqlCommand("Habitacion_Asignar", fPrincipal2.conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    if (descuentoId != 0)
                        comm.Parameters.AddWithValue("@descuentoId", descuentoId);
                    comm.Parameters.AddWithValue("@nroHab", nroHab);
                    comm.Parameters.AddWithValue("@catId", catId);
                    comm.Parameters.AddWithValue("@dia", dia);
                    comm.Parameters.AddWithValue("@diaAnt", diaAnt);
                    comm.Parameters.AddWithValue("@pernocte", pernocte);
                    comm.Parameters.AddWithValue("@conserjeId", conserjeId);
                    comm.Parameters.AddWithValue("@contPernocte", precioSumarContador);
                    if (socioId != 0)
                        comm.Parameters.AddWithValue("@socioId", socioId);
                    if (puntos > 0)
                        comm.Parameters.AddWithValue("@puntos", puntos);
                }
                else
                {                    
                    if (montoApagar == 0)
                    {
                        return false;// No se encontro tarifa                    
                    }
                    
                    comm = new SqlCommand("Habitacion_AsignarTurnoNoche", fPrincipal2.conn);
                    comm.CommandType = CommandType.StoredProcedure;

                    comm.Parameters.AddWithValue("@nroHab", nroHab);
                    comm.Parameters.AddWithValue("@catId", catId);
                    comm.Parameters.AddWithValue("@tarifaId2", tarifaNoche.id);
                    comm.Parameters.AddWithValue("@precioTotal", tarifaNoche.precio);
                    comm.Parameters.AddWithValue("@precioExtras", impExtra);
                    DateTime fHasta = DateTime.Now.Hour > tarifaNoche.hasta.Hour ? DateTime.Now.AddDays(1) : DateTime.Now;
                    comm.Parameters.AddWithValue("@hasta", new DateTime(fHasta.Year, fHasta.Month, fHasta.Day, tarifaNoche.hasta.Hour, tarifaNoche.hasta.Minute, 0));
                    if (descuentoId != 0)
                        comm.Parameters.AddWithValue("@descuentoId", descuentoId);
                    comm.Parameters.AddWithValue("@conserjeId", conserjeId);
                    if (socioId != 0)
                        comm.Parameters.AddWithValue("@socioId", socioId);
                    if (puntos > 0)
                        comm.Parameters.AddWithValue("@puntos", puntos);
                    if (descTotalHabitacion > 0)
                        comm.Parameters.AddWithValue("@descTotalHabitacion", descTotalHabitacion);
                }

                comm.ExecuteNonQuery();

                comm.CommandText = "UPDATE cierresCaja set cantTA = cantTA + 1 where hasta is null";
                comm.Parameters.Clear();
                comm.CommandType = CommandType.Text; 
                comm.ExecuteNonQuery();

                tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);                

                return true;
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(" Habitacion.CS , metodo: Asignar -  " + ex.Message + " " + ex.StackTrace);
                return false;
            }
        }

        static public DetallesHabitacion obtenerDetalles(int nroHab)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("habitacion_detallesTurno", fPrincipal2.conn);
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

        static public void Cancelar(fPrincipal2 fPrincipal, int nroHab)
        {
            SqlCommand comm;
            comm = new SqlCommand("habitacion_cancelar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@nroHab", nroHab);

            comm.ExecuteNonQuery();
            tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);
            //comm.CommandText = "listaTurnos_2";
            //comm.Parameters.Clear();
            //comm.Parameters.AddWithValue("@orden", tools.obtenerParametroString("ordenListado"));
            //fPrincipal.dibujar(fPrincipal.maxFilas, fPrincipal.cantHab, comm.ExecuteReader());
            return;
        }

        internal static void Adelanto(fPrincipal2 fPrincipal, int nroHab, decimal monto, int mediopago)
        {
            SqlCommand comm;
            comm = new SqlCommand("habitacion_adelanto", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@monto", monto);
            comm.Parameters.AddWithValue("@medioPago", mediopago);
            comm.ExecuteNonQuery();

            tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);
        }

        internal static void Cierre(fPrincipal2 fPrincipal, int nroHab, decimal descPorArt,decimal descuento, int medioPago,decimal impHabitacionFaltante)
        {
            // Ingresar la ropa consumida en el turno
            SqlCommand comm = new SqlCommand("ropaConsumida_contabilizar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.ExecuteNonQuery();
            
            // Hacer el cierre de la habitacion
            comm.CommandText = "turnos_cerrar";
            comm.Parameters.AddWithValue("@descuento", descuento);
            comm.Parameters.AddWithValue("@descPorArt", descPorArt);            
            comm.Parameters.AddWithValue("@medioPago", medioPago);
            comm.Parameters.AddWithValue("@impHabFaltante", impHabitacionFaltante);
            comm.ExecuteNonQuery();            

            tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);          
        }

        static public DataRow preCierre(int nroHab)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("turnos_preCierre", fPrincipal2.conn);
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

        internal static List<Aviso> obtenerAlarmas(int nroHab)
        {
            DataSet ds = new DataSet();
            List<Aviso> avisos = new List<Aviso>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("alarmas_obtenerPorHabitacion", fPrincipal2.conn);
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
                LoggerProxy.Error(" Habitacion.CS , metodo: obtenerAvisos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer Avisos/Alarmas de la BD *");
            }
        }

        internal static List<Aviso> listadoAlarmas()
        {
            DataSet ds = new DataSet();
            List<Aviso> avisos = new List<Aviso>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from alarmas", fPrincipal2.conn);
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
                LoggerProxy.Error(" Habitacion.CS , metodo: listadoAvisos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer listado de Avisos de la BD *");
            }
        }

        internal static List<Aviso> listadoAvisos()
        {
            DataSet ds = new DataSet();
            List<Aviso> avisos = new List<Aviso>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from avisos", fPrincipal2.conn);
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
                LoggerProxy.Error(" Habitacion.CS , metodo: listadoAvisos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer listado de Avisos de la BD *");
            }
        }

        internal static void agregarAlarma(fPrincipal2 fPrincipal, int nroHab, int hora, int avisoSel)
        {

            SqlCommand comm = new SqlCommand("alarmas_asignar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@hora", hora);
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();

            tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);           
        }

        internal static void quitarAlarma(fPrincipal2 fPrincipal,int nroHab, int avisoSel)
        {
            SqlCommand comm = new SqlCommand("alarmas_quitar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();
        }
        
        internal static void quitarAviso(int nroHab, int avisoSel)
        {
            SqlCommand comm = new SqlCommand("avisos_quitar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();           
        }
        
        internal static Dictionary<int,string> obtenerCategorias(string nroHab)
        {
            DataSet ds = new DataSet();
            Dictionary<int, string> categorias = new Dictionary<int, string>();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select categoria,categoria2,categoria3,nombre from habitaciones H, categorias C  where nroHabitacion = " + nroHab + " and C.id in (categoria,categoria2,categoria3)", fPrincipal2.conn);
            try
            {
                dataAdapter.Fill(ds);
                
                categorias.Add(int.Parse(ds.Tables[0].Rows[0][0].ToString()),ds.Tables[0].Rows[0][3].ToString());
                if (ds.Tables[0].Rows.Count > 1)
                {
                    if(ds.Tables[0].Rows[1][1].ToString()!="")
                        categorias.Add(int.Parse(ds.Tables[0].Rows[1][1].ToString()), ds.Tables[0].Rows[1][3].ToString());
                    else
                        categorias.Add(int.Parse(ds.Tables[0].Rows[1][2].ToString()), ds.Tables[0].Rows[1][3].ToString());
                }
                if (ds.Tables[0].Rows.Count>2)
                    categorias.Add(int.Parse(ds.Tables[0].Rows[2][2].ToString()), ds.Tables[0].Rows[2][3].ToString());

                return categorias;
            }
            catch (Exception ex)
            {
                LoggerProxy.Error(" Habitacion.CS , metodo: obtenerCategorias  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer listado de categorias de la BD *");
            }
        }

        internal static void CambiarEstado(fPrincipal2 fPrincipal, int nroHab, string estHab)
        {
            SqlCommand comm = new SqlCommand("habitacion_cambiarEstado", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@est", estHab);
            comm.ExecuteNonQuery();
            if(fPrincipal != null)
                tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);            
        }

        public static decimal calcularPrecioTurno(int pernocte, decimal descuentoId,int puntos,int catId,out Tarifa tarifaNoche,out decimal totDescDinero,out decimal totExtra)
        {
            totDescDinero = 0;
            totExtra = 0;
            
            try
            {
                tarifaNoche = null;
                decimal precioTotal = 0;
                decimal impTurnoRedondeado = 0;
                SqlCommand comm;                
                int dia;
                int diaAnt;
                dia= Calendario.nroDia(DateTime.Now);
                diaAnt = Calendario.nroDiaAnt(DateTime.Now);

                if (pernocte == 0)
                {
                    comm = new SqlCommand("Habitacion_calcularPrecioAsignar", fPrincipal2.conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    if (descuentoId != 0)
                        comm.Parameters.AddWithValue("@descuentoId", descuentoId);                    
                    comm.Parameters.AddWithValue("@catId", catId);
                    comm.Parameters.AddWithValue("@dia", dia);
                    comm.Parameters.AddWithValue("@diaAnt", diaAnt);
                    comm.Parameters.AddWithValue("@pernocte", pernocte);
                    if (puntos > 0)
                        comm.Parameters.AddWithValue("@puntos", puntos);
                }
                else
                {                    
                    precioTotal = Tarifa.calcularPrecioConPernocte(catId, out tarifaNoche); 
                    if (precioTotal == 0)
                    {                        
                        return 0;// No se encontro tarifa                    
                    }
                    impTurnoRedondeado = tools.redondeo(tarifaNoche.precio);
                    totExtra = tools.redondeo(precioTotal - tools.redondeo(tarifaNoche.precio));

                    if (descuentoId == 0)
                        return impTurnoRedondeado + totExtra - puntos; // no es necesario aplicar descuentos
                                      
                    
                    comm = new SqlCommand("Habitacion_calcularPrecioAsignarTurnoNoche", fPrincipal2.conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@precioTotal", impTurnoRedondeado);
                    comm.Parameters.AddWithValue("@precioExtras", totExtra);
                   
                    if (descuentoId != 0)
                        comm.Parameters.AddWithValue("@descuentoId", descuentoId);
                   
                    if (puntos > 0)
                        comm.Parameters.AddWithValue("@puntos", puntos);
                }
                DataSet ds = new DataSet();                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(comm);
                dataAdapter.Fill(ds);
                decimal descFinal = Convert.ToDecimal(ds.Tables[0].Rows[0][1]);
                decimal impFinal = Convert.ToDecimal(ds.Tables[0].Rows[0][0]);
                decimal totPuntos = Convert.ToDecimal(ds.Tables[0].Rows[0][2]);
                totDescDinero = tools.redondeo(descFinal);

                return  impFinal - totDescDinero - totPuntos;
            }
            catch (Exception ex)
            {
                tarifaNoche = null;
                LoggerProxy.Error(" Habitacion.CS , metodo: calcularPrecioAsignar -  " + ex.Message + " " + ex.StackTrace);
                return 0;
            }
        }
        
        internal static void agregarAviso(fPrincipal2 fPrincipal, int nroHab, int avisoSel)
        {
            SqlCommand comm = new SqlCommand("avisos_asignar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);            
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();
            tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);
        }

        internal static List<Aviso> obtenerAvisos(int nroHab)
        {
            DataSet ds = new DataSet();
            List<Aviso> avisos = new List<Aviso>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("avisos_obtenerPorHabitacion", fPrincipal2.conn);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
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
                LoggerProxy.Error(" Habitacion.CS , metodo: obtenerAvisos  -  " + ex.Message + " " + ex.StackTrace);
                throw new Exception("* Error al traer Avisos/Alarmas de la BD *");
            }
        }

        internal static void quitarAviso(fPrincipal2 fPrincipal, int nroHab, int avisoSel)
        {
            SqlCommand comm = new SqlCommand("avisos_quitar", fPrincipal2.conn);
            comm.CommandType = CommandType.StoredProcedure;

            comm.Parameters.AddWithValue("@nroHab", nroHab);
            comm.Parameters.AddWithValue("@avisoId", avisoSel);

            comm.ExecuteNonQuery();
            tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);            
        }

        internal static void AdelantarPuntos(fPrincipal2 fPrincipal, int nroHab, int puntos,ref Socio socio)
        {
            using (SqlConnection conn = new SqlConnection(fPrincipal2.conn.ConnectionString))
            {
                SqlTransaction transaccion = null;
                conn.Open();
                transaccion = conn.BeginTransaction(IsolationLevel.RepeatableRead);
                try
                {
                    SqlCommand comm = new SqlCommand("habitacion_adelantarPuntos", conn);
                    comm.Transaction = transaccion;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@nroHab", nroHab);
                    comm.Parameters.AddWithValue("@puntos", puntos);
                    comm.ExecuteNonQuery();

                    socio.descontarPuntos(puntos,transaccion,conn);                    
                    transaccion.Commit();
                    tools.actualizarListadoTurnos(fPrincipal.dataGridView1, fPrincipal.dataGridView2);
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    LoggerProxy.Error(ex.Message + "-" + ex.StackTrace);
                }
            }
        }
    }

    public class DetallesHabitacion
    {
        public string nroPromo;
        public string nombrePromo;
        public string nroSocio;
        public string categoria;
        public int pernocte;
        public string ptosCambiados;
        public decimal impHabitacion;
        public decimal impAdelantado;
        public DateTime hasta;
        public DateTime desde;
        public double duracion;
        public decimal descuentoDinero;
        public decimal descArticulos;
        public decimal impArticulos;
        public decimal impHabIni;
        public decimal impExtras;
        public int catId;
        public int nroHab;
        public decimal contPernocte;


        public DetallesHabitacion(){}
        public DetallesHabitacion(DataRow dr)
        {
            nroPromo = dr["descuentoId"].ToString();
            nombrePromo = dr["nombre"].ToString();
            nroSocio = dr["nroSocio"].ToString();
            pernocte = dr["pernocte"].ToString() == "False" ? 0 : 1;
            ptosCambiados = dr["puntos"].ToString() == "" ? "0" : dr["puntos"].ToString();
            impHabitacion = decimal.Parse(dr["impHabitacion"].ToString());
            impAdelantado = decimal.Parse(dr["impAdelantado"].ToString());
            categoria = dr["categoria"].ToString();
            hasta = DateTime.Parse(dr["hasta"].ToString());
            desde = DateTime.Parse(dr["desde"].ToString());
            duracion = (hasta-DateTime.Parse(dr["desde"].ToString())).TotalMinutes;
            descuentoDinero = decimal.Parse(dr["descHabitacion"].ToString());
            descArticulos = decimal.Parse(dr["descArt"].ToString());
            impArticulos = decimal.Parse(dr["impArticulos"].ToString());
            impHabIni = decimal.Parse(dr["impHabIni"].ToString());
            impExtras = decimal.Parse(dr["impExtras"].ToString());
            catId = int.Parse(dr["catId"].ToString());
            nroHab = int.Parse(dr["nroHab"].ToString());
            contPernocte = decimal.Parse(dr["contPernocte"].ToString());

        }

      
    }
}
