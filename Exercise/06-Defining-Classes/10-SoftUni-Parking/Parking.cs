﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count { get { return this.cars.Count; } }
        public string AddCar(Car car)
        {

            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
                
            }
            else if (this.capacity == this.cars.Count)
            {
                return "Parking is full!";
                
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registrationNumber)
        {

            if (this.cars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                this.cars.Remove(this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return $"Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return this.cars.FirstOrDefault(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var item in registrationNumbers)
            {
                this.cars.RemoveAll(x => x.RegistrationNumber == item);
            }
        }
    }
}
