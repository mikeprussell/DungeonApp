using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        private int _life;

        public string Name { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public int MaxLife { get; set; }

        public int Life
        {
            get { return _life; }
            set
            {
                _life = value > MaxLife ? MaxLife : value;

            }//END Set

        }//END Life

        //Even though this class is abstract and we'll neer create a Character class object,
        //creating a CTOR here is more object-oriented because it eliminates the duplication
        //of code in the child classes
        public Character(string name, int hitChance, int block, int life, int maxLife)
        {
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Life = life;
        }

        //We won't creat a ToString() as the base.ToString() because we want to display
        //the stats differently for the Player and the Monster

        public virtual int CalcBlock()
        {
            return Block;
            //This acts as a foundation to override the block calculation in child classes
        }

        public virtual int CalcHitChance()
        {
            return HitChance;
        }

        //Here, the abstract keyword indicates that we MUST override this method in the
        //child class in order for it to be useable. We do this to ensure that both child
        //classes have some version of the CalcDamage(). Becuase we don't define
        //the default functionality we'll use a method stub with no body.
        public abstract int CalcDamage();

    }

}
