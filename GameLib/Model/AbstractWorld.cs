using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using GameLib.Factory;
using GameLib.Interface;

namespace GameLib.Model
{
    public abstract class AbstractWorld
    {
        //Template
        //IO


        public List<Tile> Tiles { get; set; }
        public List<IWorldObject> WorldObjects { get; set; }
        public MapSize Size { get; set; }

        protected AbstractWorld()
        {
            Tiles = new List<Tile>();
            WorldObjects = new List<IWorldObject>();
            LoadConfig();

            GenerateWorld();

            WeaponFactory WeaponFactory = new WeaponFactory();

            WorldObjects.Add(WeaponFactory.Create(WeaponType.Melee, new Position(2,2)));
            WorldObjects.Add(WeaponFactory.Create(WeaponType.Ranged, new Position(5,2)));

            WorldObjects.Add(new Monster(new Position(5,5), "M", "Monster Mads", 20,11));
            WorldObjects.Add(new Monster(new Position(2,7), "M", "Monster Magnus", 80,3));
        }


        public virtual void GenerateWorld()
        {
            for (int i = 0; i < Size.MaxX; i++)
            {
                for (int j = 0; j < Size.MaxY; j++)
                {
                    if (i == 0 || j == 0 || i == Size.MaxX -1 || j == Size.MaxY -1)
                    {
                        Tiles.Add(new Tile(new Position(i,j), TileType.Mountains));
                    }
                    else
                    {
                        Tiles.Add(new Tile(new Position(i, j)));
                    }


                }
            }

        }

        public void LoadConfig()
        {
            XmlDocument config = new XmlDocument();
            config.Load("config.xml");

            XmlNode xNode = config.DocumentElement.SelectSingleNode("x");
            XmlNode yNode = config.DocumentElement.SelectSingleNode("y");

            string xString = xNode.InnerText.Trim();
            string yString = yNode.InnerText.Trim();

            int x = Convert.ToInt32(xString);
            int y = Convert.ToInt32(yString);

            Size = new MapSize(x,y);
        }

        public abstract void DrawMap();


    }
}
