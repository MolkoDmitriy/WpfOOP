using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    class TiCircle:tPoint
    {
        public tPoint center { get; set; }

        public int rad = 150;

        public TiCircle(tPoint point)
        {
            center = point;
        }
    }
}
