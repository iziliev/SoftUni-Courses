using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones;

        public Airfield(string name, int capacity,double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            this.drones = new List<Drone>();
        }
        public IReadOnlyCollection<Drone> Drones => drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip  { get; set; }
        public int Count =>this.drones.Count;
        public string AddDrone(Drone drone)
        {
            if (this.Count==this.Capacity)
            {
                return "Airfield is full.";
            }
            
            if (drone.Name!="" && drone.Name!= null && drone.Brand!=""&& drone.Brand != null && drone.Range>=5&&drone.Range<=15)
            {
                drones.Add(drone);
                return $"Successfully added {drone.Name} to the airfield.";
            }

            return "Invalid drone.";
        }
        public bool RemoveDrone(string name)
        {
            var currentDrone = this.drones.FirstOrDefault(x => x.Name == name);

            if (currentDrone != null)
            {
                this.drones.Remove(currentDrone);
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            var currentCount = this.Count;

            if (this.drones.Any(x => x.Brand == brand))
            {
                this.drones.RemoveAll(x=>x.Brand==brand);
                return currentCount - this.Count;
            }
            return 0;
        }
        public Drone FlyDrone(string name)
        {
            if (this.drones.Any(x=>x.Name == name))
            {
                var currentDrone = this.drones.FirstOrDefault(x => x.Name == name);
                currentDrone.Available = false;
                return currentDrone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            var list = this.drones
                .FindAll(x => x.Range >= range);

            foreach (var item in list)
            {
                item.Available = false;
            }
            return list;
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Drones available at {this.Name}:");
            foreach (var item in this.drones.Where(x=>x.Available==true))
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
