using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    abstract class Wardrobe
    {
        protected int cost;
        protected string color, flavor;

        protected Random random = new Random();

        protected List<string> colors = new List<string> { "brown", "black", "blue", "white", "gray", "green", "red" };
        protected List<string> flavors = new List<string> { "strawberry", "mint", "choclate", "cream", "vanilla", "avocado", "orange" };

        virtual public string GetWardrobeType()
        {
            return "Unspecified wardrobe";
        }
        public string GetColor()
        {
            return color;
        }
        public string GetFlavor()
        {
            return flavor;
        }
    }
}
