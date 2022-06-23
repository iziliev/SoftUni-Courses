using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private Dictionary<int, IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new Dictionary<int, IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            CheckComputerExist(computerId);

            var computer = this.computers[computerId];

            IComponent component;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            if (this.components.Any(x=>x.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            computer.AddComponent(component);
            this.components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id,manufacturer,model,price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            if (this.computers.ContainsKey(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            this.computers.Add(id,computer);

            return $"Computer with id {id} added successfully.";

        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            CheckComputerExist(computerId);

            var computer = this.computers[computerId];

            IPeripheral peripheral;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance,connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            var computer = this.computers.Values.OrderByDescending(x=>x.OverallPerformance).Where(x=>x.Price <= budget).FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            this.computers.Remove(computer.Id);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            CheckComputerExist(id);

            var computer = this.computers[id];

            this.computers.Remove(id);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            CheckComputerExist(id);

            return this.computers[id].ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            CheckComputerExist(computerId);

            var computer = this.computers[computerId];

            var component = computer.Components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (component == null)
            {
                throw new ArgumentException($"Component {componentType} does not exist in Laptop with Id {computerId}.");
            }

            computer.RemoveComponent(componentType);

            this.components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            CheckComputerExist(computerId);

            var computer = this.computers[computerId];

            var peripheral = computer.Peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in Laptop with Id {computerId}.");
            }

            computer.RemovePeripheral(peripheralType);

            this.peripherals.Remove(peripheral);

            return $"Successfully removed {peripheralType} with id {peripheral.Id}.";
        }

        private void CheckComputerExist(int computerId)
        {
            if (!computers.ContainsKey(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }
        }
    }
}
