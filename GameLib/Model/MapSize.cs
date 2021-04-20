using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Model
{
    public class MapSize
    {
        private int _maxX;
        private int _maxY;

        public MapSize(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        public int MaxX
        {
            get => _maxX;
            set
            {
                if (value >= 0 ) throw new ArgumentOutOfRangeException("Value", "Map size is too low");
                _maxX = value;
            }
        }

        public int MaxY
        {
            get => _maxY;
            set
            {
                if (value >= 0) throw new ArgumentOutOfRangeException("Value", "Map size is too low");
                _maxY = value;
            }
        }
    }
}
