using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class WardrobeMirror : Wardrobe
    {
        public WardrobeMirror()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(4000, 5000);            
            // randomized values from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        override public string GetWardrobeType()
        {
            return "Wardrobe with a mirror";
        }
        public override string ToString()
        {
            return "Type: " + GetWardrobeType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
