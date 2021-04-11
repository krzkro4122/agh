using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    abstract class InteriorDecorator
    {
        abstract public Desk CreateDesk(int maxPrice);
        abstract public Wardrobe CreateWardrobe(int maxPrice);
        virtual public string GetDecoratorType()
        {
            return "Unspecified decorator";
        }
    }
}
