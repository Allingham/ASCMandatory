using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Model;

namespace GameLib.Interface
{
    public interface IWeaponFactory
    {
        IWeapon Create(WeaponType type, Position position);
    }

    public enum WeaponType
    {
        Melee,
        Ranged
    }
}
