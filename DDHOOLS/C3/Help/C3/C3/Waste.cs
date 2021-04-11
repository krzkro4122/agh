using System;

namespace C3 {
    public class Waste : IVisitPort {

        private static Double wasteDensity = 20;
        
        private Double volume = 0;
        private Double weight = 0;
        
        public Double Volume {
            get => volume;
            set {
                weight = value * wasteDensity;
                volume = value;
            }
        }

        public Double Weight { 
            get => weight;
            set {
                volume = value / wasteDensity;
                weight = value;
            } 
        }
        public Double VisitPort() {
            Volume = 0;
            return 1500;
        }
    }
}