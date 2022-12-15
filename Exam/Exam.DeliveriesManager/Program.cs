using System;

namespace Exam.DeliveriesManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var deliverer = new Deliverer("1", "FedEx");

            var manager = new DeliveriesManager();

            manager.AddDeliverer(deliverer);
        }
    }
}
