using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;
        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.employees = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count =>this.employees.Count;

        public void Add(Employee employee)
        {
            if (this.Count<this.Capacity)
            {
                this.employees.Add(employee);
            }
        }
        public bool Remove(string name)
        {
            var employee = GetEmployee(name);
            if (employee!=null)
            {
                this.employees.Remove(employee);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            return this.employees.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Employee GetEmployee(string name)
        {
            return this.employees.FirstOrDefault(x => x.Name == name);
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");
            
            foreach (var employee in this.employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
