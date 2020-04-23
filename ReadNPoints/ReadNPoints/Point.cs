using System;
using System.Collections.Generic;
using System.Text;

namespace ReadNPoints
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Name { get; set; }

        public Point()
        {
            this.Name = 'Z';
        }
    }
}
