using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Hoteles.Entities
{
    public class myDGVCell : DataGridView
    {

        public myDGVCell()
        {
           
        }
        
        //public override Type FormattedValueType
        //{
        //    get
        //    {
        //        return typeof(object);
        //    }
        //}


        //protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds,
        //    int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue,
        //    string errorText, DataGridViewCellStyle cellStyle,
        //    DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        //{
            
            
        //    // llamar al método base
        //    base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue,
        //        errorText, cellStyle, advancedBorderStyle, paintParts);
        //}


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            return;
        }
    }
}
