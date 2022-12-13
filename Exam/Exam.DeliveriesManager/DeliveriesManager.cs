using System.Collections.Generic;
using System.Linq;

namespace Exam.DeliveriesManager
{
    public class DeliveriesManager : IDeliveriesManager
    {
        private Dictionary<string, Deliverer> deliverersById = new Dictionary<string, Deliverer>();
        private Dictionary<string, Package> packegesById = new Dictionary<string, Package>();
        
        public void AddDeliverer(Deliverer deliverer)
        {
            this.deliverersById.Add(deliverer.Id, deliverer);
        }

        public void AddPackage(Package package)
        {
            this.packegesById.Add(package.Id, package);
        }

        public void AssignPackage(Deliverer deliverer, Package package)
        {
            this.deliverersById[deliverer.Id].Packages.Add(package);
        }

        public bool Contains(Deliverer deliverer)
        {
            return deliverersById.ContainsKey(deliverer.Id);
        }

        public bool Contains(Package package)
        {
            return packegesById.ContainsKey(package.Id);
        }

        public IEnumerable<Deliverer> GetDeliverers()
        {
            return this.deliverersById.Values;
        }

        public IEnumerable<Deliverer> GetDeliverersOrderedByCountOfPackagesThenByName()
        {
            return this.GetDeliverers().OrderByDescending(x => x.Packages.Count).ThenBy(x => x.Packages);
        }

        public IEnumerable<Package> GetPackages()
        {
            return this.packegesById.Values;
        }

        public IEnumerable<Package> GetPackagesOrderedByWeightThenByReceiver()
        {
            return this.GetPackages().OrderByDescending(x => x.Weight).ThenBy(x => x.Receiver);
        }

        public IEnumerable<Package> GetUnassignedPackages()
        {
            return this.GetPackages().Where(x => x.de == null);
            //throw new System.NotImplementedException();
        }
    }
}
