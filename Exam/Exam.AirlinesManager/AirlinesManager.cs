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
            flight.Airline = airline;
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
            if (!this.airlinesByID.ContainsKey(airline.Id))
            {
                throw new ArgumentException();
            }

            var flightsForDel = airline.Flights;
            airlinesByID.Remove(airline.Id);
            foreach (var flight in flightsForDel)
            {
                flightsById.Remove(flight.Id);
            }
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
            var resultFlights = this.GetAllFlights().Where(x => x.Origin == origin).Where(x => x.Destination == destination).Where(x => x.IsCompleted == false);

            List<Airline> airlines = new List<Airline>();

            foreach (var flight in resultFlights)
            {
                airlines.Add(flight.Airline);
            }

            return airlines; 
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            return this.flightsById.Values;
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            return this.GetAllFlights().Where(x => x.IsCompleted == true);
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            return this.GetAllFlights().OrderBy(x => x.IsCompleted).ThenBy(x => x.Number).ToList();
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            if (!airlinesByID.ContainsKey(airline.Id) || !flightsById.ContainsKey(flight.Id))
            {
                throw new ArgumentException();
            }

            flight.IsCompleted = true;

            return flight;

        }
    }
}
