using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class WardrobeSlide : Wardrobe
    {
        public WardrobeSlide()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(2000, 3000);
            // randomized values from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        override public string GetWardrobeType()
        {
            return "Wardrobe with a sliding door";
        }
        public override string ToString()
        {
            return "Type: " + GetWardrobeType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
