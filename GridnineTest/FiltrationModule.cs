using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gridnine.FlightCodingTest
{
    public static class FiltrationModule
    {
        public static void DepartingInThePastCheck(IList<Flight> flights)
        {
            List<Flight> invalidFlights = new List<Flight>();
            foreach (var flight in flights)
            {
                foreach (var segment in flight.Segments)
                {
                    if (segment.DepartureDate < DateTime.Now)
                    {
                        Console.WriteLine("Вылет до текущего момента времени");
                        Console.WriteLine("Вылет: " + segment.DepartureDate + " Прибытие: " + segment.ArrivalDate );
                        invalidFlights.Add(flight);
                        break;
                    }
                }
            }
            foreach (var invalidFlight in invalidFlights)
                flights.Remove(invalidFlight);
            Console.WriteLine(flights.Count);
        }

        public static void DepartsBeforeItArrivesCheck(IList<Flight> flights)
        {
            List<Flight> invalidFlights = new List<Flight>();
            foreach (var flight in flights)
            {
                foreach (var segment in flight.Segments)
                {
                    if (segment.ArrivalDate < segment.DepartureDate)
                    {
                        Console.WriteLine("Дата прибытия раньше даты вылета");
                        Console.WriteLine("Вылет: " + segment.DepartureDate + " Прибытие: " + segment.ArrivalDate);
                        invalidFlights.Add(flight);
                        break;
                    }
                }
            }
            foreach (var invalidFlight in invalidFlights)
                flights.Remove(invalidFlight);
            Console.WriteLine(flights.Count);
        }

        public static void FlightWithMoreThanTwoHoursGroundCheck(IList<Flight> flights)
        {
            List<Flight> invalidFlights = new List<Flight>();
            foreach (var flight in flights)
            {
                TimeSpan groundHours = new TimeSpan(0, 0, 0);
                TimeSpan twoHours = new TimeSpan(2, 0, 0);
                for (int i = 0; i < flight.Segments.Count - 1; i++)
                {
                    groundHours += flight.Segments[i + 1].DepartureDate.Subtract(flight.Segments[i].ArrivalDate);
                    if (groundHours > twoHours)
                    {
                        Console.WriteLine("Общее время, проведённое на земле, превышает два часа");
                        invalidFlights.Add(flight);
                        break;
                    }
                }
            }
            foreach (var invalidFlight in invalidFlights)
                flights.Remove(invalidFlight);
            Console.WriteLine(flights.Count);
        }
    }
}
