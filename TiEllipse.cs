using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    class TiEllipse:tPoint
    {
        

        public int rad_x = 150;
        public int rad_y = 100;
        
        public TiEllipse(tPoint p)
        {
            X = p.X;
            Y = p.Y;
        }
    }
}
