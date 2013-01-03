using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hoteles.Entities
{
    public class TipoDescuento
    {
        
        public string nombre;
        public string pathImagen;
        public int tipoDescuentoId;
        

        private TipoDescuento(DataRow dr)
        {            
            nombre = dr["nombre"].ToString();
            pathImagen = dr["pathImagen"].ToString();
            tipoDescuentoId = int.Parse(dr["tipoDescuentoId"].ToString());            
        }

        public static List<TipoDescuento> obtenerTiposDescuento()
        {
            DataSet ds = new DataSet();
            List<TipoDescuento> descuentos = new List<TipoDescuento>();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from tipoDescuentos", fPrincipal.conn);
            dataAdapter.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                descuentos.Add(new TipoDescuento(dr));
            }

            return descuentos;
        }

      
    }
}
