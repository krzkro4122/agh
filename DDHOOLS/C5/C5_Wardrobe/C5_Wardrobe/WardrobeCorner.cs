using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class WardrobeCorner : Wardrobe
    {
        public WardrobeCorner()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(1000, 2000);
            // randomized values from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        override public string GetWardrobeType()
        {
            return "Corner Wardrobe";
        }
        public override string ToString()
        {
            return "Type: " + GetWardrobeType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
