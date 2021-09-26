using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace WpfApp1
{
    class TiShape : tPoint
    {
        public tPoint[] points;

        public tPoint this[int Index]
        {
            get { return points[Index]; }
            set
            {
                this[Index] = new tPoint();
            }
        }

        public SolidColorBrush brush { get; private set; }
        public TiShape(int n)
        {
            points = new tPoint[n];
        }

        public TiShape(SolidColorBrush Brush, tPoint[] points)
        {
            this.points = new tPoint[points.Length];
            brush = Brush;
            for (int i = 0; i < points.Length; i++)
            {
                this.points[i] = points[i];
            }
        }


        override public void RandomMovement(int width, int height)
        {
            if (_MoveX == 0) _MoveX += 2;
            if (_MoveY == 0) _MoveY += 2;
            int flag_x = 0;
            int flag_y = 0;
            foreach (var point in points)
            {
                if ((point.Y < 0 || point.Y > height)) flag_y++;
                if ((point.X < 0 || point.X > width)) flag_x++;
            }
            if (flag_y>0)
            {
                _MoveY = -_MoveY;
            }
            if (flag_x >0)
            {
                _MoveX = -_MoveX;
            }
            foreach (var point in points)
            {
                point.MovePoint(_MoveX, _MoveY);
            }
        }



    }
}
