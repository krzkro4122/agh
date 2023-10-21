using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    interface IStrategy
    {
        List<StatPackage> BattleMove(Gnome gnome);
        List<StatPackage> BattleMove(Daughter daughter);
        List<StatPackage> BattleMove(Ghost ghost);
        List<StatPackage> BattleMove(Peppa peppa);

        List<StatPackage> React(List<StatPackage> packs, Gnome gnome);
        List<StatPackage> React(List<StatPackage> packs, Daughter daughter); // You can only debuff daughter with MagicPowerDmg
        List<StatPackage> React(List<StatPackage> packs, Ghost ghost);
        List<StatPackage> React(List<StatPackage> packs, Peppa peppa);
    }
}
