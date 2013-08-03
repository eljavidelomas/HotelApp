using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Hoteles.Entities
{
    class FilaRopaConsumida
    {
        public string categoria;
        public int fundas;
        public int sabanas;
        public int acolchados;
        public int toallas;
        public int toallones;
        public int batas;
        

        public FilaRopaConsumida() { }

        public FilaRopaConsumida(DataRow dr)
        {
            this.categoria = dr["nombre"].ToString();
            this.fundas = int.Parse(dr["fundas"].ToString());
            this.sabanas = int.Parse(dr["sabanas"].ToString());
            this.acolchados = int.Parse(dr["acolchados"].ToString());
            this.toallas = int.Parse(dr["toallas"].ToString());
            this.toallones = int.Parse(dr["toallones"].ToString());
            this.batas = int.Parse(dr["batas"].ToString());
        }

        public override string ToString()
        {
            return "".PadRight(16) + categoria.ToString().PadRight(21) + " " +
                        fundas.ToString().PadLeft(3) + "    " +
                        sabanas.ToString().PadLeft(5) + "    " +
                        acolchados.ToString().PadLeft(8) + "     " +
                        toallas.ToString().PadLeft(5) + "    " +
                        toallones.ToString().PadLeft(8) + "    " +
                        batas.ToString().PadLeft(5);
        }
    }
}
