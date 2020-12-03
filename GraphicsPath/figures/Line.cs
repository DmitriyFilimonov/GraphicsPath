using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Drawing;

using System.Windows.Forms;



namespace GraphicsPath.figures
{
    public class Line
    {
        public Rectangle _rect;
        public bool InLine(PointF point)
        {
            if (
                    (
                    Math.Abs
                        (
                        (point.X - _rect.Location.X) / ((_rect.Location.X + _rect.Width) - (_rect.Location.X))
                        -
                        (point.Y - _rect.Location.Y) / ((_rect.Location.Y + _rect.Height) - (_rect.Location.Y))
                        )
                    <=0.2
                    )
                    ||
                    (
                        (
                            Math.Abs(_rect.Location.X-_rect.Width) < 30
                            ||
                            Math.Abs(_rect.Location.Y - _rect.Height) < 30
                        )
                        &&
                        (
                            (Math.Abs(point.X- _rect.Location.X)<30)
                            ||
                            (Math.Abs(point.Y - _rect.Location.Y) < 30)
                        )
                    )
                )
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
