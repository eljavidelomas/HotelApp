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
            int.TryParse(dr["fundas"].ToString(),out this.fundas);
            int.TryParse(dr["sabanas"].ToString(),out this.sabanas);
            int.TryParse(dr["acolchados"].ToString(),out this.acolchados);
            int.TryParse(dr["toallas"].ToString(), out this.toallas);
            int.TryParse(dr["toallones"].ToString(), out this.toallones);
            int.TryParse(dr["batas"].ToString(), out this.batas);
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
