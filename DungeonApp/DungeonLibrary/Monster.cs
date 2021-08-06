using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;

            }
        }

        public Monster(string name, int hitChance, int block, int life, int maxLife,
            int minDamage, int maxDamage, string description)
            : base(name, hitChance, block, life, maxLife)
        {
            MaxDamage = maxDamage;
            Description = description;
            MinDamage = minDamage;
        }

        public override string ToString()
        {
            return string.Format($"{Name}\n{Description}\n" +
                $"{(Life == MaxLife ? "It is uninjured" : Life <= MaxLife * .25 ? "This creature is near death" : "It is injured")}");

        }

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }

    }

}
