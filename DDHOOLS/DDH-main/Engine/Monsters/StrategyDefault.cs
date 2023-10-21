using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class StrategyDefault : IStrategy
    {
        public List<StatPackage> BattleMove(Gnome gnome)
        {
            gnome.Stamina -= 20;

            if (gnome.Health < 80 && gnome.Potions > 0) gnome.Strategy = new StrategyAlternative();

            else if (gnome.Stamina == 0) gnome.Strategy = new StrategyVulnerableORrest();

            return new List<StatPackage>() { new StatPackage(DmgType.Physical, gnome.Strength + gnome.Stamina, "Gnom zamaszyscie uderza kijem (" + (gnome.Strength + gnome.Stamina) + " dmg[fizyczne])") };
        }
        public List<StatPackage> BattleMove (Daughter daughter)
        {
            daughter.MagicPower -= 40;
            return new List<StatPackage>() { new StatPackage(DmgType.Psycho, 30, "Jestes za blisko osobnika z pokolenia Gen-Z (30 dmg [psycho])") };
        }
        public List<StatPackage> BattleMove(Ghost ghost)
        {
            ghost.MagicPower -= 15;

            if (ghost.MagicPower == 0) ghost.Strategy = new StrategyGhostRage();

            List<String> tracks = new List<string>() { "Nicky Minaj - Starships", "Megan Thee Stallion - Savage", "Cardi B - WAP" };
            String track = tracks[Index.RNG(0, tracks.Count)];

            return new List<StatPackage>() {
                new StatPackage(DmgType.Psycho, 25, "Duch coreczeki puscil " + track + " na 102% glosnosci. Tracisz szare komorki (25 dmg [psycho])")
            };
        }
        public List<StatPackage> BattleMove(Peppa peppa)
        {
            peppa.Stamina -= peppa.Stamina;

            peppa.Strategy = new StrategyVulnerableORrest();

            return new List<StatPackage>() {
                new StatPackage(DmgType.Physical, 60, "Peppa wymieszala ci zeby kopytem. (60 dmg [physical])")
            };
        }



        public List<StatPackage> React(List<StatPackage> packs, Gnome gnome)
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {                
                gnome.Health -= pack.HealthDmg;
                gnome.Strength -= pack.StrengthDmg;
                gnome.Armor -= pack.ArmorDmg;
                gnome.Precision -= pack.PrecisionDmg;
                gnome.MagicPower -= pack.MagicPowerDmg;
                ans.Add(pack);
            }
            return ans;
        }
        public List<StatPackage> React(List<StatPackage> packs, Daughter daughter)
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                daughter.MagicPower -= pack.HealthDmg * 2;

                if (pack.MagicPowerDmg != 0) daughter.MagicPower = 0; // Magic debuffs burst the bubble imidietaly

                ans.Add(pack);
            }

            if (daughter.MagicPower <= 0) daughter.Strategy = new StrategyAlternative();

            return ans;
        }
        public List<StatPackage> React(List<StatPackage> packs, Ghost ghost)
        {
            return new List<StatPackage>(); // Doesn't take damage at the default state
        }
        public List<StatPackage> React(List<StatPackage> packs, Peppa peppa)
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                peppa.Health -= pack.HealthDmg;
                peppa.Strength -= pack.StrengthDmg;
                peppa.Armor -= pack.ArmorDmg;
                peppa.Precision -= pack.PrecisionDmg;
                peppa.MagicPower -= pack.MagicPowerDmg;
                // Peppa detects if damage is other than physical and braces herself
                if (pack.DamageType != DmgType.Physical)
                    peppa.Strategy = new StrategyAlternative();
                ans.Add(pack);
            }

            return ans;
        }
    }
}
