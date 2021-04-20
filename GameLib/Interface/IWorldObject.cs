using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Model;

namespace GameLib.Interface
{
    public interface IWorldObject
    {
        Position Position { get; set; }
        string Icon { get; set; }
        string Name { get; set; }
    }
}
