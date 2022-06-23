using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> pets;
        public Clinic(int capacity)
        {
            this.Capacity = capacity;
            this.pets = new List<Pet>();
        }
        public int Capacity { get; set; }
        public int Count =>this.pets.Count;
        public void Add(Pet pet)
        {
            if (this.Count<this.Capacity)
            {
                this.pets.Add(pet);
            }
        }
        public bool Remove(string name)
        {
            var currentPet = this.pets.FirstOrDefault(x => x.Name == name);

            if (currentPet != null)
            {
                this.pets.Remove(currentPet);
                return true;
            }
            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            return this.pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
        }
        public Pet GetOldestPet()
        {
            return this.pets.OrderByDescending(x=>x.Age).FirstOrDefault();
        }
        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var pet in this.pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }
            return sb.ToString().Trim();
        }

    }
}
