using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class DeskStanding : Desk
    {
        public DeskStanding()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(2000, 5000);
            width = random.Next(200, 300);
            // randomized value from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        public DeskStanding(string color, string flavor)
        {
            // randomized values in arbitrary ranges
            cost = random.Next(2000, 5000);
            width = random.Next(200, 300);

            this.color = color;
            this.flavor = flavor;
        }

        override public string GetDeskType()
        {
            return "Standing Desk";
        }
        public override string ToString()
        {
            return "Type: " + GetDeskType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
