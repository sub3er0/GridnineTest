using System;
using Xunit;
using Gridnine.FlightCodingTest;
using System.Collections.Generic;

namespace GridnineTest.Test
{
    public class GridnineTest
    {
        [Fact]
        public void DepartingInThePastTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            IList<Flight> flights = flightBuilder.GetFlights();
            FiltrationModule.DepartingInThePastCheck(flights);
            Assert.Equal(5, flights.Count);
        }

        [Fact]
        public void DepartsBeforeItArrivesTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            IList<Flight> flights = flightBuilder.GetFlights();
            FiltrationModule.DepartsBeforeItArrivesCheck(flights);
            Assert.Equal(5, flights.Count);
        }

        [Fact]
        public void FlightWithMoreThanTwoHoursGroundTest()
        {
            FlightBuilder flightBuilder = new FlightBuilder();
            IList<Flight> flights = flightBuilder.GetFlights();
            FiltrationModule.FlightWithMoreThanTwoHoursGroundCheck(flights);
            Assert.Equal(4, flights.Count);
        }

    }
}
