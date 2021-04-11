using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    class ClassicDecorator : InteriorDecorator
    {
        private string color, flavor;
        override public Wardrobe CreateWardrobe(int maxPrice)
        {
            Wardrobe outputWardrobe = null;

            if (maxPrice > 2000)
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

            if (maxPrice > 3000)
                outputDesk = new DeskGaming(color, flavor);

            else if (maxPrice > 1500)
                outputDesk = new DeskOffice(color, flavor);

            else if (maxPrice > 1000)
                outputDesk = new DeskWooden(color, flavor);

            return outputDesk;
        }
        override public string GetDecoratorType()
        {
            return "Classic";
        }
        public override string ToString()
        {
            return "Decorator style: " + GetDecoratorType();
        }
    }
}
