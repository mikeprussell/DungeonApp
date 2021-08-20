using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Troll : Monster
    {
        public bool IsHungry { get; set; }

        public Troll(string name, int hitChance, int block, int life, int maxLife,
            int minDamage, int maxDamage, string description, bool isHungry)
            : base(name, hitChance, block, life, maxLife, minDamage, maxDamage, description)
        {
            IsHungry = isHungry;
            if (IsHungry)
            {
                Block += 10;
                HitChance += 10;
                Description += "\nThis troll is hungry for flesh!";

            }//END if IsHungry

        }//END FQCTOR
    }

}
