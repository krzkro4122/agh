using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class DeskGaming : Desk
    {
        public DeskGaming()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(1000, 3000);
            width = random.Next(150, 200);
            // randomized value from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        public DeskGaming(string color, string flavor)
        {
            // randomized values in arbitrary ranges
            cost = random.Next(1000, 3000);
            width = random.Next(150, 200);

            this.color = color;
            this.flavor = flavor;
        }
        override public string GetDeskType()
        {
            return "Gaming desk";
        }
        public override string ToString()
        {
            return "Type: " + GetDeskType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
