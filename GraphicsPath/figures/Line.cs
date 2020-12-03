using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;



namespace GraphicsPath.figures
{
    public class Line: Control, ISupportInitialize
    {
        public Rectangle _rect;

        public void BeginInit()
        {
            throw new NotImplementedException();
        }

        public void EndInit()
        {
            throw new NotImplementedException();
        }
        public event EventHandler MouseEnter;

        public bool InLine(PointF point)
        {
            if ((0 == (point.X - _rect.Location.X) / ((_rect.Location.X - _rect.Width) - (_rect.Location.X))) && (0 == (point.Y - _rect.Location.Y) / ((_rect.Location.Y - _rect.Height) - (_rect.Location.Y))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
