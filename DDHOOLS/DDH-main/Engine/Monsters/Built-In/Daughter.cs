using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Daughter : Monster
    {
        public Daughter()
        {
            Health = 10;
            Strength = 0;
            MagicPower = 300;
            Armor = 0;
            Precision = 50;
            Stamina = 15;
            XPValue = 125;
            Name = "monster0009";
            BattleGreetings = "Tato nagrajmy razem TikToka! =D ;* UwU xoxo";
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
