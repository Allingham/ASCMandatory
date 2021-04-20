using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib.Interface
{
    public interface ICharacter : IWorldObject
    {
        int HP { get; set; }
        int Damage { get; set; }
        bool IsDead();

    }
}
