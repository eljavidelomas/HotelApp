using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public class Descuento
    {
        public int id;
        public string nombre;
        public string descripcion;
        public decimal descuentoFijo;
        public int descuentoPorcentaje;
        public string pathImagen;
        public int cantidadArticulos;
        public int acumulaPuntaje;
        public int tarifaId;
        public int menuId;


        public Descuento(string nombre)
        {
            id = 0;
            this.nombre = nombre;
        }

        private Descuento(DataRow dr)
        {
            id = int.Parse(dr["id"].ToString());
            nombre = dr["nombre"].ToString();
            descripcion = dr["descripcion"].ToString();
            descuentoFijo = string.IsNullOrEmpty(dr["descuentoFijo"].ToString()) ? 0 : Decimal.Parse(dr["descuentoFijo"].ToString());
            descuentoPorcentaje = string.IsNullOrEmpty(dr["descuentoPorcentaje"].ToString()) ? 0 : int.Parse(dr["descuentoPorcentaje"].ToString());
            pathImagen = dr["pathImagen"].ToString();
            cantidadArticulos = string.IsNullOrEmpty(dr["cantidadArticulos"].ToString()) ? 0 : int.Parse(dr["cantidadArticulos"].ToString());
            acumulaPuntaje = string.IsNullOrEmpty(dr["acumulaPuntaje"].ToString()) ? 0 : int.Parse(dr["acumulaPuntaje"].ToString());            
            tarifaId = String.IsNullOrEmpty( dr["tarifaId"].ToString() ) ? 0 : int.Parse(dr["tarifaId"].ToString());
            menuId = string.IsNullOrEmpty(dr["menuId"].ToString()) ? 0 : int.Parse(dr["menuId"].ToString());
            
        }

        public static List<Descuento> obtenerDescuentos(int nroHab)
        {
            DataSet ds = new DataSet();
            List<Descuento> descuentos = new List<Descuento>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Descuentos_GetAll", fPrincipal.conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@nroHab", nroHab);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                descuentos.Add(new Descuento(dr));
            }

            return descuentos;
        }


    }
}
