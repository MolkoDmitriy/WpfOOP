using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace WpfApp1
{
    class TiLine:tPoint
    {
        public Line line { get; protected set; }

        public TiLine()
        {
            line = new Line();
            line.X1 =0;
            line.Y1 = 0;
            line.X2 = 50;
            line.Y2 = 50;
            line.Stroke = Brushes.White;
        }
        public TiLine(tPoint p)
        {
            line = new Line();
            line.Stroke = p.brush;
            line.X1 = p.X;
            line.Y1 = p.Y;
            line.X2 = line.X1 + 50;
            line.Y2 = line.Y1 + 50;
        }

        public override void RandomMovement(int width, int height)
        {
            if (_MoveX == 0) _MoveX = 2;
            if (_MoveY == 0) _MoveY = 2;

            if(line.X1<0|| line.X1 > width)
            {
                _MoveX = -_MoveX;
            }
            else if (line.X2 < 0 || line.X2 > width)
            {
                _MoveX = -_MoveX;
            }

            if (line.Y1 < 0 || line.Y1 > height)
            {
                _MoveY = -_MoveY;
            }
            else if (line.Y2 < 0 || line.Y2 > height)
            {
                _MoveY = -_MoveY;
            }

            line.X1 += _MoveX;
            line.X2 += _MoveX;
            line.Y1 += _MoveY;
            line.Y2 += _MoveY;
        }
    }
}
