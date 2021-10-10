using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
namespace WpfApp1
{
    class TiEllipse : tPoint
    {

        public Ellipse ellipse { get; protected set; }

        public TiEllipse()
        {
            ellipse = new Ellipse();
            ellipse.Width = 150;
            ellipse.Height = 100;
        }
        public TiEllipse(tPoint p) : this()
        {
            X = p.X;
            Y = p.Y;
            brush = p.brush;
            ellipse.Fill = brush;
            window.canvas1.Children.Add(ellipse);
        }
        public override void RandomMovement(int width, int height)
        {
            if (_MoveY == 0) _MoveY += 2;
            if (_MoveX == 0) _MoveX += 2;

            if (X < 0 || X > width - ellipse.Width)
            {
                _MoveX = -_MoveX;
            }
            X += _MoveX;
            if (Y < 0 || Y > height - ellipse.Height)
            {
                _MoveY = -_MoveY;
            }
            Y += _MoveY;
            Canvas.SetLeft(ellipse, X);
            Canvas.SetTop(ellipse, Y);
        }
    }
}
