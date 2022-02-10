using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Average_Grades
{
    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double AverageGrade => Grades.Average();
    }
}
