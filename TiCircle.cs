using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace WpfApp1
{
    class TiCircle:TiEllipse
    {

        public TiCircle(tPoint p)
        {
            X = p.X;
            Y = p.Y;
            brush = p.brush;
            ellipse = new Ellipse();
            ellipse.Width = 100;
            ellipse.Height = 100;
            ellipse.Fill = brush;
        }
    }
}
