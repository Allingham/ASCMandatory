using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Model
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                 throw new ArgumentOutOfRangeException("x and Y must not be negative");
            }
            else
            {
                X = x;
                Y = y;
            }
        }
    }
}
