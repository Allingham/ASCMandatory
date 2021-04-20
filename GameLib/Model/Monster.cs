using System;
using System.Collections.Generic;
using System.Text;
using GameLib.Interface;

namespace GameLib.Model
{
    public class Monster : ICharacter
    {
        public Monster(Position position, string icon, string name, int hp, int damage)
        {
            Position = position;
            Icon = icon;
            Name = name;
            HP = hp;
            Damage = damage;
        }

        public Position Position { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        public bool IsDead()
        {
            return HP <= 0;
        }
    }
}
