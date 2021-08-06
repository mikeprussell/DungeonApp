﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void Attack(Character attacker, Character defender)
        {
            //Randomize who goes first with percentage range or something else - maybe Initiative property
            //Could make Monster the attacker and defender - spell
            //Use a dice roll from 1-100 to use a basis to determine if the attacker hits:
            int diceroll = new Random().Next(1, 101);
            //The Sleep() allows us to pause the execution of code for a defined number
            //of milliseconds:
            System.Threading.Thread.Sleep(35);

            if (diceroll <= attacker.CalcHitChance() - defender.CalcBlock())
            {
                int damageDealt = attacker.CalcDamage();
                defender.Life -= damageDealt;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }

        }//END Attack()

        public static void Battle(Player player, Monster monster)
        {
            Attack(player, monster);
            if (monster.Life > 0)
            {
                Attack(monster, player);

            }//END if

        }//END Combat()

    }

}
