using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Ghost : Monster
    {
        public Ghost()
        {
            Health = 1;
            Strength = 0;
            MagicPower = 30;
            Armor = 0;
            Precision = 0;
            Stamina = 5;
            XPValue = 10;
            Name = "monster0008";
            BattleGreetings = "Last thing i saw was a vent opening behind me in electrical. Where am i?";
        }
        public Ghost(String battleGreeting)
        {
            Health = 1;
            Strength = 0;
            MagicPower = 30;
            Armor = 0;
            Precision = 100;
            Stamina = 1;
            XPValue = 75;
            Name = "monster0008";
            BattleGreetings = battleGreeting; // custom battlegreeting for various killed entities
            // case when its a ghost of a daughter            
            if (battleGreeting.Length == 82) Strategy = new StrategyDefault();
            // case when its a ghost of a gnome                   
            else Strategy = new StrategyAlternative();
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
