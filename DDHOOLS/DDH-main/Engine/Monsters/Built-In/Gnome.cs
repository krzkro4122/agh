using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Gnome : Monster
    {
        public Gnome()
        {
            Health = 150;
            Strength = 20;
            MagicPower = 10;
            Armor = 0;
            Precision = 80;
            Stamina = 20;
            XPValue = 100;
            Name = "monster0007";
            BattleGreetings = "I am a Gnome and you just got gnobbly-gnomed!";            
            Strategy = new StrategyDefault();
            Potions = 2;
        }
        public IStrategy Strategy { get; set; }
        public int Potions { get; set; }
        public override List<StatPackage> BattleMove()
        {
            return Strategy.BattleMove(this);
        }
    }
}
