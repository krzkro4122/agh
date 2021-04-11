using System;

namespace C3 {
    public class OxygenBottle : IVisitPort {
        private static double OxygenDensity = 114;
        private Double volume;
        private Double weight;
        
        public Double Volume {
            get => volume;
            set {
                weight = value * OxygenDensity;
                volume = value;
            }
        }

        public Double Weight { 
            get => weight;
            set {
                volume = value / OxygenDensity;
                weight = value;
            } 
        }
        
        private Double maxcapacity;
        
        public Double MaxCapacity {
            get => maxcapacity;
            set => maxcapacity = value;
        }

        public OxygenBottle(Double capacity) {
            maxcapacity = capacity;
        }

        public Double GetCapacity() {
            return maxcapacity;
        }
        
        public Double VisitPort() {
            Double filledUp = MaxCapacity - Volume;
            Volume = MaxCapacity;
            return filledUp*150;
        }
    }
}