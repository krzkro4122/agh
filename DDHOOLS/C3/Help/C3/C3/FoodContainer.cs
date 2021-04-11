using System;

namespace C3 {
    public class FoodContainer : IVisitPort {
        private static Double foodDensity = 15;
        private Double volume = 0;
        private Double weight = 0;
        
        public Double Volume {
            get => volume;
            set {
                weight = value * foodDensity;
                volume = value;
            }
        }

        public Double Weight { 
            get => weight;
            set {
                volume = value / foodDensity;
                weight = value;
            } 
        }
        
        private Double maxcapacity;
        
        public Double MaxCapacity {
            get => maxcapacity;
            set => maxcapacity = value;
        }

        public FoodContainer(Double capacity) {
            maxcapacity = capacity;
        }

        public Double GetCapacity() {
            return maxcapacity;
        }
        
        public Double VisitPort() {
            Volume = MaxCapacity;
            return Volume*50;
        }
    }
}