using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    class StrategyVulnerableORrest : IStrategy
    {
        public List<StatPackage> BattleMove(Gnome gnome)
        {
            gnome.Stamina += 30;

            if (gnome.Health < 80 && gnome.Potions > 0) gnome.Strategy = new StrategyAlternative();

            else gnome.Strategy = new StrategyDefault();

            return new List<StatPackage>() { new StatPackage(DmgType.Other, 0, "Gnome lapie oddech (30 stamina)") };
        }
        public List<StatPackage> BattleMove(Daughter daughter)
        {            
            return new List<StatPackage>() {
               new StatPackage(DmgType.Other, 0, "Tata mnie bil podczas robienia tego TikToka. Dont let it flop! 😶😶😶")
            };            
        }
        public List<StatPackage> BattleMove(Ghost ghost)
        {
            // Doesn't do much here
            return new List<StatPackage>();
        }
        public List<StatPackage> BattleMove(Peppa peppa)
        {
            peppa.Stamina += 200;

            peppa.Strategy = new StrategyDefault();

            return new List<StatPackage>() {
                new StatPackage(DmgType.Other, 0, "Peppa odpoczywa po straceniu sil. Teraz otrzymuje zwiekszone obrazenia! (x5)")
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
            }
            return ans;                    
        }
        public List<StatPackage> React(List<StatPackage> packs, Ghost ghost)
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                ghost.Health -= pack.HealthDmg;
            }

            return ans;
        }
        public List<StatPackage> React(List<StatPackage> packs, Peppa peppa)
        {
            List<StatPackage> ans = new List<StatPackage>();
            foreach (StatPackage pack in packs)
            {
                peppa.Health -= pack.HealthDmg * 5; // Peppa otrzymuje potezne obrazenia jak odpoczywa
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
