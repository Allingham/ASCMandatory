using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Interface;
using GameLib.Model;

namespace GameLib.Factory
{
    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon Create(WeaponType type, Position position)
        {
            Random rnd = new Random();

            switch (type)
            {
                case WeaponType.Melee:
                    return new Sword(position, "S", rnd.Next(10), "Zweihander" );
                case WeaponType.Ranged:
                    return new Bow(position, "B", rnd.Next(8), "Elvish Bow");
            }

            return null;
        }
    }
}
