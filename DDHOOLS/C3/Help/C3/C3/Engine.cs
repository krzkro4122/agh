using System;

namespace C3 {
    public class Engine {
        private FuelTank tank;
        private Waste waste;

        public Engine(FuelTank tank, Waste waste) {
            this.tank = tank;
            this.waste = waste;
        }

        public Double GetVelocity(Double submarineWeight) {
            return 10*(1 - submarineWeight/2500000);
        }

        public bool CheckFuelBeforeTravel(Double travelTime) {
            Double fuelUsage;
            if (tank.GetFuelType() == "Nuclear") fuelUsage = 0.125;
            else fuelUsage = 2.5;
            
            return tank.Volume > travelTime * fuelUsage;
        }

        public void Travel(Double travelTime) {
            Double fuelUsage;
            if (tank.GetFuelType() == "Nuclear") fuelUsage = 0.25;
            else fuelUsage = 0.75;
            
            waste.Volume += travelTime * 1.8;
            tank.Volume -= travelTime * fuelUsage;
        }
    }
}