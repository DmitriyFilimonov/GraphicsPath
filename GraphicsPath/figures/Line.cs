using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



namespace GraphicsPath.figures
{
    public class Line //: IFigure
    {
        public Rectangle _rect;

        //Rectangle IFigure._rect.X { get; set; }

        public bool InTarget(PointF point)
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
