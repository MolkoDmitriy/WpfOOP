using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;

namespace WpfApp1
{
    class TiEllipse : tPoint
    {

        public Ellipse ellipse { get;protected set; }

        public TiEllipse()
        {
            ellipse = new Ellipse();
            ellipse.Width = 150;
            ellipse.Height = 100;
            ellipse.Fill = brush;
        }
        public TiEllipse(tPoint p)
        {
            X = p.X;
            Y = p.Y;
            brush = p.brush;
            ellipse = new Ellipse();
            ellipse.Width = 150;
            ellipse.Height = 100;
            ellipse.Fill = brush;
        }

    }
}
