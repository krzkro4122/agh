using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class DeskWooden : Desk
    {
        public DeskWooden()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(100, 1000);
            width = random.Next(100, 250);
            // randomized value from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        public DeskWooden(string color, string flavor)
        {
            // randomized values in arbitrary ranges
            cost = random.Next(100, 1000);
            width = random.Next(100, 250);

            this.color = color;
            this.flavor = flavor;
        }
        override public string GetDeskType()
        {
            return "Wooden desk";
        }
        public override string ToString()
        {
            return "Type: " + GetDeskType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
