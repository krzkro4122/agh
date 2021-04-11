using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class DeskDrafting : Desk
    {
        public DeskDrafting()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(500, 1400);
            width = random.Next(100, 150);
            // randomized value from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        public DeskDrafting(string color, string flavor)
        {
            // randomized values in arbitrary ranges
            cost = random.Next(500, 1400);
            width = random.Next(100, 150);
            
            this.color = color;
            this.flavor = flavor;
        }
        override public string GetDeskType()
        {
            return "Drafting desk";
        }
        public override string ToString()
        {
            return "Type: " + GetDeskType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
