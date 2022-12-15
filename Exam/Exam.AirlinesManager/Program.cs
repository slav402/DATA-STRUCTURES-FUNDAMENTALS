using Exam.DeliveriesManager;
using System;

namespace Exam.DeliveriesManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Airline airBg = new Airline("01", "airBG", 3);
            Airline airRu = new Airline("02", "RU", 1);

            Flight flight01 = new Flight("001", "1", "Panama", "Sofia", false);
            Flight flight02 = new Flight("002", "2", "London", "Sofia", false);
            Flight flight03 = new Flight("003", "3", "Paris", "Sofia", false);
            Flight flight04 = new Flight("004", "4", "Rome", "Sofia", false);
            Flight flight05 = new Flight("005", "5", "Athena", "Moskow", false);
            Flight flight06 = new Flight("006", "6", "NewYork", "Moskow", false);
            Flight flight07 = new Flight("007", "7", "Kabul", "Moskow", false);

            var airlineMenager = new AirlinesManager();

            airlineMenager.AddAirline(airRu);
            airlineMenager.AddAirline(airBg);

            airlineMenager.AddFlight(airRu, flight05);
            airlineMenager.AddFlight(airRu, flight06);
            airlineMenager.AddFlight(airRu, flight07);

            airlineMenager.AddFlight(airBg, flight01);
            airlineMenager.AddFlight(airBg, flight02);
            airlineMenager.AddFlight(airBg, flight03);
            airlineMenager.AddFlight(airBg, flight04);

            airlineMenager.DeleteAirline(airRu);
        }
    }
}
