using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class DeskOffice : Desk
    {
        public DeskOffice()
        {
            // randomized values in arbitrary ranges
            cost = random.Next(500, 1500);
            width = random.Next(100, 200);
            // randomized value from a List given in Desk.cs
            color = colors[random.Next(colors.Count)];
            flavor = flavors[random.Next(flavors.Count)];
        }
        public DeskOffice(string color, string flavor)
        {
            // randomized values in arbitrary ranges
            cost = random.Next(500, 1500);
            width = random.Next(100, 200);
            
            this.color = color;
            this.flavor = flavor;
        }

        override public string GetDeskType()
        {
            return "Office desk";
        }
        public override string ToString()
        {
            return "Type: " + GetDeskType() + "\nCost: " + cost + "\nColor: " + color + "\nFlavor: " + flavor;
        }
    }
}
