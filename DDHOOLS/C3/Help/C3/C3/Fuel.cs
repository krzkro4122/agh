using System;

namespace C3 {
    public abstract class Fuel : ITransportable {

        public static Double FuelNuclearDensity = 2.78;
        public static Double FuelDieselDensity = 20.52;
        
        protected Double volume;
        protected Double weight;
        
        public Double Volume { get; set; }
        public Double Weight { get; set; }
        public String Type { get; set; }
        protected Double Density;

        public abstract String GetType();

    }

    public class FuelNuclear : Fuel {
        public Double Volume {
            set {
                volume = value;
                Density = FuelNuclearDensity;
                weight = Density * volume;
            }
            get => volume;
        }
        public Double Weight {
            set {
                weight = value;
                Density = FuelNuclearDensity;
                volume = weight / Density;
            }
            get => weight;
        }

        public FuelNuclear() {
            Volume = 50;
        }

        public override String GetType() {
            return "Nuclear";
        }
    }

    public class FuelDiesel : Fuel {
        public Double Volume {
            set {
                volume = value;
                Density = FuelDieselDensity;
                weight = Density * volume;
            }
            get => volume;
        }
        
        public Double Weight {
            set {
                weight = value;
                Density = FuelDieselDensity;
                volume = weight / Density;
            }
            get => weight;
        }
        public override String GetType() {
            return "Diesel";
        }
    }
}