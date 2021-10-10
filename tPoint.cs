using System;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;


namespace WpfApp1
{
    class tPoint:AbstractShape
    {
        public MainWindow window = Application.Current.Windows[0] as MainWindow;

        public int X { get; protected set; }
        public int Y { get; protected set; }

        private static Random rnd = new Random();

        public int _MoveX = rnd.Next(-7, 3) + 2;
        public int _MoveY = rnd.Next(-7, 3) + 2;
        public SolidColorBrush brush { get;  set; }
        public tPoint()
        {
            X = 0;
            Y = 0;
            brush = Brushes.White;
        }
        public tPoint(int X, int Y, SolidColorBrush Brush)
        {
            this.X = X;
            this.Y = Y;
            brush = Brush;
        }
        public tPoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            brush = Brushes.White;
        }
        public override void RandomMovement(int width, int height)
        {
            if (X < 0 || X > width)
            {
                _MoveX = -_MoveX;
            }
            if (_MoveX == 0) _MoveX += 2;
            X += _MoveX;
            if (Y < 0 || Y > height)
            {
                _MoveY = -_MoveY;
            }
            if (_MoveY == 0) _MoveY += 2;
            Y += _MoveY;
        }
    }
}
