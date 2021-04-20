using System;
using System.Diagnostics;
using System.Xml;
using GameLib.Interface;
using GameLib.Model;


namespace FrameWorkTests
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Game game = new Game(new World(), new Player("Player", 30, 5));
            
            game.Start();

            Console.ReadLine();
        }
    }
}
