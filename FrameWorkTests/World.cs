using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Interface;
using GameLib.Model;

namespace FrameWorkTests
{
    public class World : AbstractWorld
    {


        public override void DrawMap()
        {
            for (int j = 0; j < Size.MaxY; j++)
            {
                for (int i = 0; i < Size.MaxX; i++)
                {
                    IWorldObject wo = WorldObjects.Find(wo => wo.Position.X == i && wo.Position.Y == j);
                    if (WorldObjects.Find(wo => wo.Position.X == i && wo.Position.Y == j) != null)
                    {
                        Console.Write(wo.Icon);
                    }
                    else
                    {
                        Console.Write(Tiles.Find(ti => ti.Position.X == i && ti.Position.Y == j).Icon);
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
