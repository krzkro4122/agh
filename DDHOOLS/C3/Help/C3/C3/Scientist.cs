using System;
using System.ComponentModel;

namespace C3 {
    public class Scientist : Human {
        private Equipment Equipment;

        public Scientist(Equipment equipment) {
            this.Equipment = equipment;
            Weight = 70;
        }

        public void Work(double time) {
            for (int i = 0; i < time / 24; i++) {
                Console.WriteLine(Equipment.GatherData());
                
            }
        }
    }
}