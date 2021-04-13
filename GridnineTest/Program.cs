using System;
using System.Collections.Generic;

namespace Gridnine.FlightCodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            IList<Flight> flights = flightBuilder.GetFlights();
            FiltrationModule.DepartingInThePastCheck(flights);
            FiltrationModule.DepartsBeforeItArrivesCheck(flights);
            FiltrationModule.FlightWithMoreThanTwoHoursGroundCheck(flights);
        }
    }
}
