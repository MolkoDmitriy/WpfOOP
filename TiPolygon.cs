using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;


namespace WpfApp1
{
    class TiPolygon:tPoint
    {
        public Polygon polygon { get; protected set; }

        public TiPolygon()
        {
            polygon = new Polygon();
            window.canvas1.Children.Add(polygon);
        }

        public TiPolygon(tPoint p) : this()
        {
            X = p.X;
            Y = p.Y;
            polygon.Points.Add(new Point(p.X, p.Y));
            polygon.Points.Add(new Point(p.X, p.Y+100));
            polygon.Points.Add(new Point(p.X+100, p.Y+100));
            polygon.Fill = p.brush;
        }
        public override void RandomMovement(int width, int height)
        {
            polygon.Points.Clear();
            if (_MoveY == 0) _MoveY += 2;
            if (_MoveX == 0) _MoveX += 2;

            if (X < 0 || X > width - 100)
            {
                _MoveX = -_MoveX;
            }
            X += _MoveX;
            if (Y < 0 || Y > height - 100)
            {
                _MoveY = -_MoveY;
            }
            Y += _MoveY;
            polygon.Points.Add(new Point(X, Y));
            polygon.Points.Add(new Point(X, Y + 100));
            polygon.Points.Add(new Point(X + 100, Y + 100));
        }
    }
}
