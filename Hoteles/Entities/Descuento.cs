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
        public int tipoDescuentoId;
        public int claseArticuloId;
        public int cantidadArticulos;
        public int puntaje;
        public int tarifaId;


        private Descuento(DataRow dr)
        {
            id = int.Parse(dr["id"].ToString());
            nombre = dr["nombre"].ToString();
            descripcion = dr["descripcion"].ToString();
            descuentoFijo = string.IsNullOrEmpty(dr["descuentoFijo"].ToString()) ? 0 : Decimal.Parse(dr["descuentoFijo"].ToString());
            descuentoPorcentaje = string.IsNullOrEmpty(dr["descuentoPorcentaje"].ToString()) ? 0 : int.Parse(dr["descuentoPorcentaje"].ToString());
            pathImagen = dr["pathImagen"].ToString();
            tipoDescuentoId = string.IsNullOrEmpty(dr["tipoDescuento"].ToString())? 0 : int.Parse(dr["tipoDescuento"].ToString());
            claseArticuloId = string.IsNullOrEmpty(dr["claseArticuloId"].ToString())?0 : int.Parse(dr["claseArticuloId"].ToString());
            cantidadArticulos = string.IsNullOrEmpty(dr["cantidad"].ToString()) ? 0 : int.Parse(dr["cantidad"].ToString());
            puntaje = string.IsNullOrEmpty( dr["puntaje"].ToString()) ? 0 : int.Parse(dr["puntaje"].ToString());
            tarifaId = String.IsNullOrEmpty( dr["tarifaId"].ToString() ) ? 0 : int.Parse(dr["tarifaId"].ToString());
        }

        public static List<Descuento> obtenerDescuentoPorTipo(int tipoDescuentoId)
        {
            DataSet ds = new DataSet();
            List<Descuento> descuentos = new List<Descuento>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from descuentos where tipoDescuento = " + tipoDescuentoId, fPrincipal.conn);
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                descuentos.Add(new Descuento(dr));
            }

            return descuentos;
        }


    }
}
