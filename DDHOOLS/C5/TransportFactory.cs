using System;
using System.Collections.Generic;
using System.Text;

namespace C2_C5
{
    abstract class TransportFactory
    {
        protected string travelMode = "quickest"; // initial value
        public string TravelMode
        {
            get { return travelMode; }
            set
            {
                // available travel modes: quickest route, cheapest route, most convenient route
                if (value == "quickest" || value == "cheapest" || value == "convenient") travelMode = value;
                else Console.WriteLine("Unrecognized travel mode: " + value);
            }
        }

        abstract public Vehicle CreateVehicle();
		
        abstract public Ticket CreateTicket();

    }
}
