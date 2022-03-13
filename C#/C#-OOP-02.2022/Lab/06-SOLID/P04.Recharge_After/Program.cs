using System;
using System.Collections.Generic;

namespace P04.Recharge_After
{
    public class Program
    {
        public static void Main()
        {
            var work = new List<Worker>();

            Worker robot = new Robot("A-1",58);
            Worker emp = new Employee("H-2");

            robot.Work(15);
            robot.Recharge();

            emp.Sleep();
            emp.Work(25);


        }
    }
}
