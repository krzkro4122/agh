using System;

namespace C3 {
    public class FuelTank : IVisitPort {
        
        private Double volume;
        private Double weight;
        
        public Double Volume {
            get => volume;
            set {
                Double fuelDensity;
                if (fuel.GetType() == "Nuclear") fuelDensity = Fuel.FuelNuclearDensity;
                else fuelDensity = Fuel.FuelDieselDensity;
                
                weight = value * fuelDensity;
                volume = value;
            }
        }

        public Double Weight { 
            get => weight;
            set {
                Double fuelDensity;
                if (fuel.GetType() == "Nuclear") fuelDensity = Fuel.FuelNuclearDensity;
                else fuelDensity = Fuel.FuelDieselDensity;
                
                volume = value / fuelDensity;
                weight = value;
            } 
        }
        
        public Double VisitPort() {
            Double filledUp = MaxCapacity - Volume;
            Volume = MaxCapacity;
            return filledUp*2000;
        }
        
        private Fuel fuel;
        private Double maxcapacity;
        public Double MaxCapacity {
            get => maxcapacity;
            set => maxcapacity = value;
        }

        public FuelTank(Double capacity, Fuel fuel) {
            this.fuel = fuel;
            MaxCapacity = capacity;
        }

        public String GetFuelType() {
            return fuel.GetType();
        }

    }
}