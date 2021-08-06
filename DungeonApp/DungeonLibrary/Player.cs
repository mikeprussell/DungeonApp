using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player(string name, int hitChance, int block, int life, int maxLife,
            Race playerRace, Weapon equippedWeapon)
            : base(name, hitChance, block, life, maxLife)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            switch (PlayerRace)
            {
                case Race.Dwarf:
                    Block += 10;
                    MaxLife += 5;
                    Life += 5;
                    break;
                case Race.Elf:
                    HitChance += 15;
                    MaxLife += 2;
                    Life += 2;
                    break;
                case Race.HalfElf:
                    Block += 5;
                    MaxLife += 10;
                    Life += 5;
                    break;
                case Race.Human:
                    MaxLife += 2;
                    Life += 2;
                    HitChance += 5;
                    Block += 5;
                    break;
                case Race.Gnome:
                    MaxLife += 5;
                    Life += 5;
                    HitChance += 2;
                    Block += 5;
                    break;
                case Race.Halfling:
                    Block += 15;
                    Life += 5;
                    HitChance += 5;
                    break;
                default:
                    break;

            }//END Switch

        }//END FQCTOR

        public override string ToString()
        {
            return string.Format($"{Name}\nRace: {PlayerRace}\nLife: {Life} of {MaxLife}\n" +
                $"Equipped Weapon:\n{EquippedWeapon}\nHit Chance: {HitChance}%\n" +
                $"Block Chance: {Block}%");
        }

        public override int CalcDamage()
        {
            Random rand = new Random();

            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }

    }//END Class

}//END Namespace
