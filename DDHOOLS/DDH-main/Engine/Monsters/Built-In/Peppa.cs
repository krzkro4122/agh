using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Peppa : Monster
    {
        public Peppa()
        {
            Health = 1000;
            Strength = 150; // It's on steroids
            Armor = 100;
            Precision = 30;
            Stamina = 200;
            XPValue = 500;
            Name = "monster0010";
            BattleGreetings = "Oink oink. Jestem Swinka Peppa (na prawie cytatu w celach satyrycznych) i jestem na sterydianach.";
            Strategy = new StrategyDefault();
        }
        public IStrategy Strategy { get; set; }
        public override List<StatPackage> BattleMove()
        {
            return Strategy.BattleMove(this);
        }
        public override List<StatPackage> React(List<StatPackage> packs)
        {
            return Strategy.React(packs, this);
        }
    }
}
