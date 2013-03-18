using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hoteles.Entities
{
    public class Aviso
    {
        public int id;
        public string mensaje;
        public int nroHab;
        public DateTime hora;

        public Aviso(int id, string mensaje)
        {
            this.id = id;
            this.mensaje = mensaje;
        }
        public Aviso(int id, int nrohab, string mensaje)
        {
            this.id = id;
            this.mensaje = mensaje;
            this.nroHab = nrohab;
        }
        public Aviso(int id, string mensaje, int hora)
        {
            this.id = id;
            this.mensaje = mensaje;
            this.hora = new DateTime(1, 1, 1, hora / 100, hora % 100, 0);
        }

    }
}
