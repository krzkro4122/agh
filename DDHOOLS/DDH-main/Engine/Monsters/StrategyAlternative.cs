using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class StrategyAlternative : IStrategy
    {
        public List<StatPackage> BattleMove(Gnome gnome)
        {
            gnome.Potions -= 1;
            gnome.Health += 60;
            gnome.Stamina += 10;

            if (gnome.Health > 70) gnome.Strategy = new StrategyDefault();

            else if (gnome.Stamina == 10) gnome.Strategy = new StrategyVulnerableORrest();

            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Gnome pije elksir uzdrawiajacy (40 hp, 10 stamina)") };
        }
        public List<StatPackage> BattleMove(Daughter daughter)
        {            
            return new List<StatPackage>() {
                new StatPackage(DmgType.Physical, 10, "Banka strefy komfortu coreczki jest rozbita! Corka miota sie niekontrolowanie. (10 dmg [physical])")
            };
        }
        public List<StatPackage> BattleMove(Ghost ghost)
        {
            ghost.MagicPower -= 15;

            if (ghost.MagicPower == 0) ghost.Strategy = new StrategyGhostRage();

            List<String> throwables = new List<string>()
                {
                    "lodem ekipy", "ciepla zubrowka", "pysznym ciastem, ale z rodzynkami", "rosolem z chlebem", "platkami sniadaniowymi z woda"
                };
            String throwable = throwables[Index.RNG(0, throwables.Count)];

            return new List<StatPackage>() {
                    new StatPackage(DmgType.Poison, 25, "Duch gnome rzucil w ciebie " + throwable + ". Ledwo powstrzymujesz sie od wymiotow (25 dmg [poison])")
                };
        } 
        public List<StatPackage> BattleMove(Peppa peppa)
        {
            peppa.Stamina -= 100;

            if (peppa.Stamina == 0)
                peppa.Strategy = new StrategyVulnerableORrest();

            return new List<StatPackage>() {
                new StatPackage(DmgType.Earth, 50, "Peppa wykryla obrazenia inne od fizycznych, wiec zachowuje dystans i rzuca w ciebie grudka ziemi. (50 dmg [earth])")
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
                daughter.Health -= pack.HealthDmg;

                ans.Add(pack);
            }

            if (daughter.Health == 0)
            {
                daughter.Health += 1;
                daughter.Strategy = new StrategyVulnerableORrest();
            }
            return ans;
        }
            public List<StatPackage> React(List<StatPackage> packs, Ghost ghost)
        {
            return new List<StatPackage>(); // doesn't take damage at this phase
        }
        public List<StatPackage> React(List<StatPackage> packs, Peppa peppa)
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                peppa.Health -= pack.HealthDmg * 4 / 5; // Peppa w defensywie przyjmuje mniej obrazen i sie tak nie meczy
                peppa.Strength -= pack.StrengthDmg;
                peppa.Armor -= pack.ArmorDmg;
                peppa.Precision -= pack.PrecisionDmg;
                peppa.MagicPower -= pack.MagicPowerDmg;

                ans.Add(pack);
            }            

            return ans;
        }        
    }
}
