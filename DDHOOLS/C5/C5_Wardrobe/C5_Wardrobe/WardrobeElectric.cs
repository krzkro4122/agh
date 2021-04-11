using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class WardrobeElectric : Wardrobe
    {
        public WardrobeElectric()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(10000, 15000);
            // randomized values from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        override public string GetWardrobeType()
        {
            return "Motorized wardrobe";
        }
        public override string ToString()
        {
            return "Type: " + GetWardrobeType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
