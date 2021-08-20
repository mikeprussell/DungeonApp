using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Ogre : Monster
    {
        public bool IsCyclopes { get; set; }

        public Ogre(string name, int hitChance, int block, int life, int maxLife,
            int minDamage, int maxDamage, string description, bool isCyclopes)
            : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {
            IsCyclopes = isCyclopes;
            if (IsCyclopes)
            {
                Block += 10;
                HitChance += 10;
                Description += "\nThis ogre is a Cyclopes!";

            }//END if IsHungry

        }//END FQCTOR

    }

}
