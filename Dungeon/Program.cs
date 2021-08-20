using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;//ADDED

namespace Dungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            string heroName;
            Race heroRace = Race.Human;
            int killCount = 0;

            Console.Title = "Mythic Quest - Titans Rift";
            Console.WriteLine(@"
      __  __       _   _     _         ____                  _   
     |  \/  |     | | | |   (_)       / __ \                | |  
     | \  / |_   _| |_| |__  _  ___  | |  | |_   _  ___  ___| |_ 
     | |\/| | | | | __| '_ \| |/ __| | |  | | | | |/ _ \/ __| __|
     | |  | | |_| | |_| | | | | (__  | |__| | |_| |  __/\__ \ |_ 
     |_|  |_|\__, |\__|_| |_|_|\___|  \___\_\\__,_|\___||___/\__|
              __/ |                                                          
             |___/  <>
                   //
                  //
    <>(((((((((({@}::::::::::::::::::::::::::::::::::::::::::::::::::::======-
                  \\     _______ _ _                    _____  _  ____
                   \\   |__   __(_) |                  |  __ \(_)/ _| |         
                    <>     | |   _| |_ __ _ _ __  ___  | |__) |_| |_| |_        
                           | |  | | __/ _` | '_ \/ __| |  _  /| |  _| __|       
                           | |  | | || (_| | | | \__ \ | | \ \| | | | |_        
                           |_|  |_|\__\__,_|_| |_|___/ |_|  \_\_|_|  \__| 
"); 

            Console.WriteLine("\nEnter your name, hero: ");
            heroName = Console.ReadLine();
            Console.Clear();

            bool raceMenu = true;

            do
            {
                Console.WriteLine("Choose your race:\n" +
                    "1) Human\n" +
                    "2) Elf\n" +
                    "3) Dwarf\n" +
                    "4) Warlock\n" +
                    "5) Gnome\n" +
                    "6) Halfling");
                ConsoleKey raceChoice = Console.ReadKey().Key;
                Console.Clear();

                switch (raceChoice)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        heroRace = Race.Human;
                        raceMenu = false;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        heroRace = Race.Elf;
                        raceMenu = false;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        heroRace = Race.Dwarf;
                        raceMenu = false;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        heroRace = Race.Warlock;
                        raceMenu = false;
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        heroRace = Race.Gnome;
                        raceMenu = false;
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        heroRace = Race.Halfling;
                        raceMenu = false;
                        break;

                    default:
                        Console.WriteLine($"{raceChoice} was not a valid option. Please choose again.");
                        break;
                }

            } while (raceMenu);

            Console.Clear();
            Console.WriteLine($"Welcome, {heroName} the {heroRace}!\nYour journey begins...\n");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine("You gallop toward the entrance of the castle...\n");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine(@"        \|              |/");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(@"         \|            |/");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(@"          \|          |/");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(@"           \|        |/");
            System.Threading.Thread.Sleep(500);
            Console.WriteLine(@"            \|      |/");
            Console.WriteLine();

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("equipped with only your rusty battle axe.\n");

            System.Threading.Thread.Sleep(500);
            Console.WriteLine(@"
             _,-,
            T_  |
            ||`-'
            ||
            ||
            ~~
");

            Console.WriteLine("\nPress any key to proceed.");
            Console.ReadKey();

            Weapon rustyAxe = new Weapon("Rusty Axe", 0, -1, 3, true);
            Player player = new Player(heroName, 60, 12, 55, 55, heroRace, rustyAxe);

            bool exit = false;

            do
            {
                Console.WriteLine(Room.GetRoom());
                Monster imp = new Monster("Imp", 30, 2, 5, 5, 1, 3,
                    "An evil flying demon sneers at you menacingly.");

                Monster boarklin = new Monster("Boarklin", 20, 4, 2, 2, 1, 3,
                    "A humanoid creatures with long ears, pig snout and sharp-pointed teeth cackles at you.");

                Monster troll = new Monster("Troll", 20, 4, 2, 2, 1, 3,
                    "Disfigured and bloodthirsty... this creature of darkness roars as drool drips to the floor.");

                Spider giantSpider = new Spider("Giant Spider", 40, 10, 10, 10, 1, 4,
                    "This grotesque abomination is the size of a large dog.",
                    new Random().Next(3) == 1 ? true : false);

                Spider swordSpider = new Spider("Giant Sword Spider", 50, 10, 20, 20, 1, 6,
                    "This hideous giant spider has a toughened hide and razor sharp pincers!",
                new Random().Next(3) == 2 ? true : false);

                Monster[] monsters =
                {
                    imp, troll, imp, boarklin, boarklin, giantSpider, swordSpider, giantSpider
                };

                Random rand = new Random();
                int index = rand.Next(monsters.Length);
                Monster monster = monsters[index];
                Console.WriteLine("In this room you see a " + monster.Name + "!");

                bool reload = false;

                Console.WriteLine("\nPress any key to proceed.");
                Console.ReadKey();

                do
                {
                    Console.Title = $"Life: {player.Life} Monsters killed: {killCount}";
                    Console.WriteLine("\nChoose an action:\n" +
                        "A)ttack\n" +
                        "F)lee\n" +
                        "V)iew Stats\n" +
                        "M)onster Stats");
                    ConsoleKey userChoice = Console.ReadKey().Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Combat.Battle(player, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("You killed the " + monster.Name + "!");
                                Console.ResetColor();
                                reload = true;
                                System.Threading.Thread.Sleep(2500);
                                killCount++;
                            }
                            break;

                        case ConsoleKey.F:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("RUN AWAY!");
                            Console.ResetColor();
                            Console.WriteLine($"The {monster.Name} attacks you as you turn to flee!");
                            Combat.Attack(monster, player);
                            reload = true;
                            break;

                        case ConsoleKey.V:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;

                        case ConsoleKey.Escape:
                            Console.WriteLine("Quitter");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("You chose an improper option.");
                            break;
                    }

                    if (player.Life < 1)
                    {
                        System.Threading.Thread.Sleep(2500);
                        Console.WriteLine($"You have been slain by the {monster.Name}!");
                        System.Threading.Thread.Sleep(2500);
                        exit = true;
                    }

                } while (!reload && !exit);

            } while (!exit);

            Console.WriteLine("GAME OVER!");

        }//END Main()

    }//END Class

}//END Namespace