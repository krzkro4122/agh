using System;

namespace C3 {
    public abstract class Human : ITransportable {
        private static Double HumanDensity = 10;
        private Double volume;
        private Double weight;
        public double Volume {
            get => volume;
            set {
                weight = value * HumanDensity;
                volume = value;
            }
        }

        public double Weight { 
            get => weight;
            set {
                volume = value / HumanDensity;
                weight = value;
            } 
        }
    }
}