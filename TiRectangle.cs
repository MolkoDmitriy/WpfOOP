using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;


namespace WpfApp1
{
    class TiRectangle:tPoint
    {
        public Rectangle rectangle { get; protected set; }

        public TiRectangle()
        {
            rectangle = new Rectangle();
            rectangle.Width = 100;
            rectangle.Height = 100;
            rectangle.Fill = Brushes.White;
            window.canvas1.Children.Add(rectangle);
        }

        public TiRectangle(tPoint p) : this()
        {
            X = p.X;
            Y = p.Y;
            rectangle.Fill = p.brush;
        }
        public override void RandomMovement(int width, int height)
        {
            if (_MoveY == 0) _MoveY += 2;
            if (_MoveX == 0) _MoveX += 2;

            if (X < 0 || X > width - rectangle.Width)
            {
                _MoveX = -_MoveX;
            }
            X += _MoveX;
            if (Y < 0 || Y > height - rectangle.Height)
            {
                _MoveY = -_MoveY;
            }
            Y += _MoveY;
            Canvas.SetLeft(rectangle, X);
            Canvas.SetTop(rectangle, Y);
        }
    }
}
