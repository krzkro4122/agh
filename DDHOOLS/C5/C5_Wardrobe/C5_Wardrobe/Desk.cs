using System;
using System.Collections.Generic;
using System.Text;

namespace C5_Wardrobe
{
    abstract class Desk
    {
        protected int cost, width;
        protected string color, flavor;

        protected Random random = new Random();

        protected List<string> colors = new List<string> {"brown", "black", "blue", "white", "gray", "green", "red"};
        protected List<string> flavors = new List<string> { "strawberry", "mint", "choclate", "cream", "vanilla", "avocado", "orange" };

        virtual public string GetDeskType()
        {
            return "Unspecified desk";
        }
    }
}
