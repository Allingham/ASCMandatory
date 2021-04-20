using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Interface;

namespace GameLib.Model
{
    class Bow : IWeapon
    {
        public Bow(Position position, string icon, int damage, string name)
        {
            Position = position;
            Icon = icon;
            Damage = damage;
            Name = name;
        }

        public Position Position { get; set; }
        public string Icon { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
    }
}