using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Model;

namespace GameLib.Interface
{
    public interface IWeapon : ILoot
    {
        int Damage { get; set; }

    }
}
