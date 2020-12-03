using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicsPath.figures
{
    public interface IFigure
    {
        Rectangle _rect { get; set; }
        bool InLine(PointF point);
    }
}
