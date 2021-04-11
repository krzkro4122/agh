using System;
using System.Collections.Generic;

namespace C5_Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {           
            List<InteriorDecorator> interiorDecorators = new List<InteriorDecorator>() { new ScandinavianDecorator(),
                new ClassicDecorator(), new ModernDecorator() };
            foreach (InteriorDecorator decorator in interiorDecorators)
            {
                Wardrobe w = decorator.CreateWardrobe(16000);
                Desk d = decorator.CreateDesk(6000);
                Console.WriteLine(decorator);
                Console.WriteLine();
                Console.WriteLine(w);
                Console.WriteLine();
                Console.WriteLine(d);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
