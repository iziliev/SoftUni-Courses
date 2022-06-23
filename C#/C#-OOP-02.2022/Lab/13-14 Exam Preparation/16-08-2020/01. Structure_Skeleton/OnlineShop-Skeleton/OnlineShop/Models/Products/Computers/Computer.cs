using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (components.Count > 0)
                {
                    return base.OverallPerformance + this.components.Average(x => x.OverallPerformance);
                }
                return base.OverallPerformance;
            }
        }
        public override decimal Price
        {
            get
            {
                decimal totalPrice = base.Price;
                if (components.Count > 0)
                {
                    totalPrice += components.Sum(x => x.Price);
                }
                if (peripherals.Count > 0)
                {
                    totalPrice += peripherals.Sum(x => x.Price);
                }
                return totalPrice;
            }
        }

        public IReadOnlyCollection<IComponent> Components =>this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x=>x.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.components.FirstOrDefault(x=>x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException($"Component {component.GetType().Name} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Remove(component);

            return component;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            double peripheralsAverageOverallPerformance = this.peripherals.Count == 0 ? 0 : this.peripherals.Average(x => x.OverallPerformance);


            sb.AppendLine($"{base.ToString()}");

            sb.AppendLine($" Components ({this.components.Count}):");

            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }
            
            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({peripheralsAverageOverallPerformance:F2}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().Trim();
        }
    }
}
