using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Model;

namespace GameLib.Interface
{
    public abstract class Armor : ILoot
    {
        public int DamageReduction { get; set; }
        public Position Position { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }

        protected Armor(int damageReduction, Position position, string icon, string name)
        {
            DamageReduction = damageReduction;
            Position = position;
            Icon = icon;
            Name = name;
        }
    }
}
