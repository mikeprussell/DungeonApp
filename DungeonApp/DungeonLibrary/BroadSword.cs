using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class BroadSword : Weapon
    {

        public bool HasShield { get; set; }

        public BroadSword(string name, int bonusHitChance, int minDamage, int maxDamage,
            bool isTwoHanded, bool hasShield, string description)
            : base(name, bonusHitChance, minDamage, maxDamage, isTwoHanded)
        {

            HasShield = hasShield;
            if (HasShield)
            {
                bonusHitChance += 5;
                description += "\nThere is also a shield!";

            }//END if HasShield
            
        }

    }

}
