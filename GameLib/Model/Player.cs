using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;
using GameLib.Model;

namespace GameLib.Interface
{
    public class Player : ICharacter
    {
        public Player(string name = "Player", int hp = 50, int damage = 10)
        {
            Position = new Position(1,1);
            Icon = "P";
            Name = name;
            HP = hp;
            Damage = damage;
            
        }


        public virtual void Move(Game game, AbstractWorld world, char direction)
        {
            switch (direction)
            {
                case 'w':
                    if (world.Tiles.Find(ti => ti.Position.X == Position.X && ti.Position.Y == Position.Y-1).Passable)
                    {
                        Position = new Position(Position.X, Position.Y - 1);

                        CheckTile(game, world);

                    }
                    else
                    {
                        //log not accessible
                    }
                    break;
                case 'a':
                    if (world.Tiles.Find(ti => ti.Position.X == Position.X-1 && ti.Position.Y == Position.Y).Passable)
                    {
                        Position = new Position(Position.X - 1, Position.Y);
                        CheckTile(game, world);
                    }
                    else
                    {
                        
                    }
                    break;
                case 's':
                    if (world.Tiles.Find(ti => ti.Position.X == Position.X && ti.Position.Y == Position.Y + 1).Passable)
                    {
                        Position = new Position(Position.X, Position.Y + 1);
                        CheckTile(game, world);
                    }
                    else
                    {
                        
                    }
                    break;
                case 'd':
                    if (world.Tiles.Find(ti => ti.Position.X == Position.X + 1 && ti.Position.Y == Position.Y).Passable)
                    {
                        Position = new Position(Position.X + 1, Position.Y);
                        CheckTile(game, world);
                    }
                    else
                    {
                        
                    }
                    break;
            }
        }

        public virtual void DealDamage(TraceSource source, ICharacter oponent)
        {
            if (Weapon != null)
            {
                oponent.HP -= Damage + Weapon.Damage;
                source.TraceEvent(TraceEventType.Critical, 1, $"Hit enemy for {Damage + Weapon.Damage}. new enemy hp: {oponent.HP}");
                Console.WriteLine($"Hit enemy for {Damage + Weapon.Damage}. new enemy hp: {oponent.HP}");
            }
            else
            {
                oponent.HP -= Damage;
                source.TraceEvent(TraceEventType.Critical, 1, $"Hit enemy for {Damage}. new enemy hp: {oponent.HP}");
                Console.WriteLine($"Hit enemy for {Damage}. new enemy hp: {oponent.HP}");
            }
            
            
            //log damage
        }

        public virtual void TakeDamage(TraceSource source, ICharacter oponent)
        {
            if (Armor != null)
            {
                HP -= oponent.Damage - Armor.DamageReduction;
                source.TraceEvent(TraceEventType.Critical, 1, $"Took {oponent.Damage - Armor.DamageReduction}. new hp: {HP}");
                Console.WriteLine($"Took {oponent.Damage - Armor.DamageReduction}. new hp: {HP}");
            }
            else
            {
                HP -= oponent.Damage;
                source.TraceEvent(TraceEventType.Critical, 1, $"Took {oponent.Damage}. new hp: {HP}");
                Console.WriteLine($"Took {oponent.Damage}. new hp: {HP}");
            }
            
        }

        public void CheckTile(Game game, AbstractWorld world)
        {
            //reflektion

            IWorldObject ObjectInTile = null;
            ObjectInTile = world.WorldObjects.Find(wo =>
                wo.Position.X == Position.X && wo.Position.Y == Position.Y);
            string NameOfObjectInTile = ObjectInTile.GetType().Name;

            if (NameOfObjectInTile != "Player")
            {
                switch (NameOfObjectInTile)
                {
                    case "Sword":
                        Weapon = ObjectInTile as IWeapon;
                        ObjectInTile.Position = null;
                        world.WorldObjects.Remove(ObjectInTile);
                        break;
                    case "Bow":
                        Weapon = ObjectInTile as IWeapon;
                        ObjectInTile.Position = null;
                        world.WorldObjects.Remove(ObjectInTile);
                        break;
                    case "Monster":
                        game.CombatOponent = ObjectInTile as ICharacter;
                        game.GameState = GameState.Combat;
                        break;
                }
                Console.WriteLine(NameOfObjectInTile);
                Console.ReadKey();
            }
        }

        public bool IsDead()
        {
            return HP <= 0;
        }

        public Position Position { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int Damage { get; set; }
        
        public IWeapon Weapon { get; set; }
        public Armor Armor { get; set; }
    }
}
