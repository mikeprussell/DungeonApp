using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class LongSword : Weapon
    {

        public bool HasShield { get; set; }

        public LongSword(string name, int bonusHitChance, int minDamage, int maxDamage,
            bool isTwoHanded, string description)
            : base(name, bonusHitChance, minDamage, maxDamage, isTwoHanded)
        {
            
        }

    }

}
