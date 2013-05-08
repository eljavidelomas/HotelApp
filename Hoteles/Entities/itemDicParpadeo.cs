using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hoteles.Entities
{
    public class itemDicParpadeo
    {
        public DataGridViewCellStyle estilo;
        public PictureBox picBox;

        public itemDicParpadeo(DataGridViewCellStyle style, PictureBox p)
        {
            this.estilo = style.Clone();
            this.picBox = p;
        }
    }
}
