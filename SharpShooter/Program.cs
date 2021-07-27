using System;
using EnsoulSharp;
using EnsoulSharp.SDK;
using EnsoulSharp.SDK.MenuUI;
using SharpShooter.Champions;

namespace SharpShooter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // MAKE SURE USE THIS DELEGATE BEFORE EVERYTHING LOAD FIRST
            // DONT MAKE ASSEMBLY LOAD FIRST THAN SDK OR SOEMTHING
            // IT WILL MAKE GAME CRASH!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            GameEvent.OnGameLoad += OnGameLoad;
        }

        private static void OnGameLoad()
        {
            // do your auth before script load first
            // or check champion support or not 

            // example:

            // for single champion check
            //if (GameObjects.Player.CharacterName != "aaa") return;

            // for Aio check
            //string[] yourAiosupport = new[] {"aa", "bb", "cc"};
            //if (!yourAiosupport.Contains(GameObjects.Player.CharacterName)) return;

            // in here i wont be add more auth or any check logic in here
            // if you want to find some sbtw auth system
            // just try to use https://auth.gg/


            // Set Player
            ChampionCore.Player = GameObjects.Player;

            // Set MainMenu
            ChampionCore.MainMenu = new Menu(ChampionCore.Player.CharacterName, "[SharpShooter] " + ChampionCore.Player.CharacterName, true).Attach();

            // Load champion script
            switch (ChampionCore.Player.CharacterName)
            {
                case "Vayne":
                    new Vayne();
                    break;
            }

            // Pring load successful message in game and console
            Console.WriteLine($"[SharpShooter]: {ChampionCore.Player.CharacterName} Load Successful! Made By NightMoon");
            Game.Print("<font size='26'><font color='#9999CC'>SharpShooter</font></font> <font color='#FF5640'> Load Successful! Made By NightMoon</font>");
        }
    }
}