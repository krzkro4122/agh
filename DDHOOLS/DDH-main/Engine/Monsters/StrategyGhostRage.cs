using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class StrategyGhostRage : IStrategy
    {
        public List<StatPackage> BattleMove(Gnome gnome) { return new List<StatPackage>(); }
        public List<StatPackage> BattleMove(Daughter daughter) { return new List<StatPackage>(); }
        public List<StatPackage> BattleMove(Ghost ghost)
        {
            ghost.Stamina = 0;

            ghost.Strategy = new StrategyVulnerableORrest();

            return new List<StatPackage>() {
                new StatPackage(DmgType.Air, 40, "Duch uderza z calej sily jaka mu zostala (40 dmg [air]).Teraz jest slaby i masz szanse go dobic!")
            };
        }
        public List<StatPackage> BattleMove(Peppa peppa) { return new List<StatPackage>(); }



        public List<StatPackage> React(List<StatPackage> packs, Gnome gnome) { return new List<StatPackage>(); }
        public List<StatPackage> React(List<StatPackage> packs, Daughter daughter) { return new List<StatPackage>(); }
        public List<StatPackage> React(List<StatPackage> packs, Ghost ghost)
        {
            return new List<StatPackage>(); // Doesn't take damage at the default state
        }
        public List<StatPackage> React(List<StatPackage> packs, Peppa peppa) { return new List<StatPackage>(); }
    }
}
