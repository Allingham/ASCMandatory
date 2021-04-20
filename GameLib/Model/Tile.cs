using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Model
{
    public class Tile
    {
        public Position Position { get; set; }
        public TileType TileType { get; set; }
        public bool Passable = true;
        public string Icon { get; set; }

        public Tile(Position position, TileType tileType = TileType.Grassland)
        {
            Position = position;
            TileType = tileType;
            if (tileType == TileType.Mountains)
            {
                Passable = false;
                Icon = "A";
            }
            else
            {
                Icon = " ";
            }
        }
    }

    public enum TileType
    {
        Mountains,
        Grassland
    }
}
