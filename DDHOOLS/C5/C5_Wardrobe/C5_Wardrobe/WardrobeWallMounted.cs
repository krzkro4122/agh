using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class WardrobeWallMounted : Wardrobe
    {
        public WardrobeWallMounted()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(500, 1000);
            // randomized values from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        override public string GetWardrobeType()
        {
            return "Wall-mounted wardrobe";
        }
        public override string ToString()
        {
            return "Type: " + GetWardrobeType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
