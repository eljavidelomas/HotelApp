using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Hoteles.Entities
{
    class FilaListArt
    {
        public int id;
        public string nombre;
        public int stock;
        public int consumo;
        public int reponer;
        public int stockGeneral;

        public FilaListArt() { }

        public FilaListArt(DataRow dr)
        {
            this.id = int.Parse(dr["id"].ToString());
            this.nombre = dr["nombre"].ToString();
            this.consumo = int.Parse(dr["CantConsumida"].ToString());
            this.stockGeneral = int.Parse(dr["stockActual"].ToString());
            this.stock = int.Parse(dr["stockRecomendado"].ToString());
            this.reponer = -1;// consultar
        }

        public override string ToString()
        {
            return id.ToString().PadLeft(3, '0').PadLeft(5) + "      " +
                    nombre.PadRight(52) + " " +
                    stock.ToString().PadLeft(4) + "      " +
                    consumo.ToString().PadLeft(4) + "        " +
                    reponer.ToString().PadLeft(4) + "      " +
                    stockGeneral.ToString().PadLeft(8);

        }
    }
}
