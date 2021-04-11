using System;
using System.Collections.Generic;

namespace C3 {
    public class LifeSupportSystem {
        private List<OxygenBottle> oxygenBottles;
        private FoodContainer foodContainer;
        private Waste waste;
        private List<Human> crew;


        public LifeSupportSystem(List<OxygenBottle> bottles, FoodContainer container, Waste waste, List<Human> crew) {
            oxygenBottles = bottles;
            foodContainer = container;
            this.waste = waste;
            this.crew = crew;
        }

        public bool CheckSuppliesBeforeTravel(Double travelTime) {
            Double oxygenTotal = 0.0;
            foreach (OxygenBottle ob in oxygenBottles) oxygenTotal += ob.Volume;

            if (oxygenTotal > travelTime * 0.05 * crew.Count) {
                return foodContainer.Volume > 0.5 * crew.Count * travelTime;
            }
            return false;
        }

        public void Run(Double travelTime) {
            foreach (OxygenBottle ob in oxygenBottles) ob.Volume -= 0.05 * travelTime;
            foodContainer.Volume -= 0.5 * crew.Count * travelTime;
            waste.Volume += crew.Count * travelTime * 1.2;
        }

    }
}