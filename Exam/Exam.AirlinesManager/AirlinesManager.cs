using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        private Dictionary<string, Airline> airlinesByID = new Dictionary<string, Airline>();
        private Dictionary<string, Flight> flightsById = new Dictionary<string, Flight>();

        public void AddAirline(Airline airline)
        {
            this.airlinesByID.Add(airline.Id, airline);
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            this.flightsById.Add(flight.Id, flight);

            if (!airlinesByID.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            this.airlinesByID[airline.Id].Flights.Add(flight);
        }

        public bool Contains(Airline airline)
        {
            return airlinesByID.ContainsKey(airline.Id);
        }

        public bool Contains(Flight flight)
        {
            return flightsById.ContainsKey(flight.Id);
        }

        public void DeleteAirline(Airline airline)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            return this.GetAirlines().OrderByDescending(x => x.Rating).ThenByDescending(x => x.Flights.Count).ThenBy(x => x.Name);
        }

        public IEnumerable<Airline> GetAirlines()
        {
            return this.airlinesByID.Values;
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return this.flightsById.Values;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            throw new NotImplementedException();
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
