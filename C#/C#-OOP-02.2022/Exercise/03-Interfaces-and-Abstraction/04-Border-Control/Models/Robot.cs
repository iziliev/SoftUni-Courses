﻿using _04_Border_Control.Contracts;
using System;

namespace _04_Border_Control.Models
{
    public class Robot : IRobot, IIdentifiable
    {
        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
