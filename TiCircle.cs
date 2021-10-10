using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
namespace WpfApp1
{
    class TiCircle:TiEllipse
    {

        public TiCircle( tPoint p, int r = 100)
        {
            X = p.X;
            Y = p.Y;
            brush = p.brush;
            ellipse = new Ellipse();
            ellipse.Width = r;
            ellipse.Height = r;
            ellipse.Fill = brush;
            window.canvas1.Children.Add(ellipse);
        }
    }
}
