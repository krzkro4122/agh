using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class ScandinavianDecorator : InteriorDecorator
    {
        private string color, flavor;
        override public Wardrobe CreateWardrobe(int maxPrice)
        {
            Wardrobe outputWardrobe = null;

            if (maxPrice > 15000)
                outputWardrobe = new WardrobeElectric();

            else if (maxPrice > 2000)
                outputWardrobe = new WardrobeCorner();

            else if (maxPrice > 1000)
                outputWardrobe = new WardrobeWallMounted();


            if (outputWardrobe != null)
            {
                this.color = outputWardrobe.GetColor();
                this.flavor = outputWardrobe.GetFlavor();
            }

            return outputWardrobe;
        }
        override public Desk CreateDesk(int maxPrice)
        {
            Desk outputDesk = null;

            if (maxPrice > 5000)
                outputDesk = new DeskStanding(color, flavor);

            else if (maxPrice > 1400)
                outputDesk = new DeskDrafting(color, flavor);

            else if (maxPrice > 1000)
                outputDesk = new DeskWooden(color, flavor);

            return outputDesk;            
        }
        override public string GetDecoratorType()
        {
            return "Scandinavian";
        }
        public override string ToString()
        {
            return "Decorator style: " + GetDecoratorType();
        }
    }
}
