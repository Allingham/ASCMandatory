using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using GameLib.Interface;

namespace GameLib.Model
{
    public class Game
    {
        //trace
        //state

        public AbstractWorld World { get; set; }
        public GameState GameState { get; set; }
        public Player Player { get; set; }
        public ICharacter CombatOponent { get; set; }
        TraceSource source = new TraceSource("Tracesource");

        public Game(AbstractWorld world ,Player player)
        {
            Player = player;
            World = world;
            world.WorldObjects.Add(Player);
            GameState = GameState.Map;
            CombatOponent = null;

            source.Switch = new SourceSwitch("this is my switch", "All");

            StreamWriter sw = new StreamWriter("events.txt");
            sw.AutoFlush = true;
            TraceListener listener = new TextWriterTraceListener(sw);

            listener.Filter = new EventTypeFilter(SourceLevels.All);


            source.Listeners.Add(listener);

        }


        public void Start()
        {
            while (!Player.IsDead())
            {
                Tick();
            }

        }

        public void Tick()
        {

            Console.Clear();
            switch (GameState)
            {
                case GameState.Combat:
                    Combat(Player, CombatOponent);
                    break;
                case GameState.Map:
                    World.DrawMap();
                    Console.WriteLine("Choose Direction");
                    Player.Move(this, World, Console.ReadKey().KeyChar);
                    break;
            }
        }

        public void Combat(Player player, ICharacter oponent)
        {
            while (true) { 
                player.DealDamage(source, oponent);
                
                if (oponent.IsDead())
                {
                    World.WorldObjects.Remove(oponent);
                    GameState = GameState.Map;
                    break;
                }

                player.TakeDamage(source, oponent);

                if (player.IsDead())
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    return;
                }
                Thread.Sleep(500);
            }

            if (oponent.IsDead()) Console.WriteLine($"You have killed {oponent.Name}");
            Console.ReadKey();
        }
    }
}
