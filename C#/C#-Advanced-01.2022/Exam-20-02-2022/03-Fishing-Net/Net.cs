using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fishes;
        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;
            this.fishes = new List<Fish>();
        }
        public IReadOnlyCollection<Fish> Fish => this.fishes;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => this.fishes.Count;
        public string AddFish(Fish fish)
        {
            if (this.Count < this.Capacity)
            {
                if (!string.IsNullOrWhiteSpace(fish.FishType) && fish.Length>0&&fish.Weight>0)
                {
                    this.fishes.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";
                }

                return "Invalid fish.";
            }
            return "Fishing net is full.";
        }
        public bool ReleaseFish(double weight)
        {
            var currentFish = this.fishes.FirstOrDefault(x => x.Weight == weight);
            if (currentFish!=null)
            {
                this.fishes.Remove(currentFish);
                return true;
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            return this.fishes.FirstOrDefault(x => x.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            return this.fishes.OrderByDescending(x=>x.Length).FirstOrDefault();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");
            foreach (var fish in this.fishes.OrderByDescending(x=>x.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
