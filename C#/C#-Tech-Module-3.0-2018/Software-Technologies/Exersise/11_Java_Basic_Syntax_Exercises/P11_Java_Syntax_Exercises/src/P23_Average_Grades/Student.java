package P23_Average_Grades;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Student {
    public String name;
    public ArrayList<Double> grades;

    public Student(String name, ArrayList<Double> grades) {
        this.name = name;
        this.grades = grades;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public ArrayList<Double> getGrades() {
        return grades;
    }

    public void setGrades(ArrayList<Double> grades) {
        this.grades = grades;
    }

    public double getAverageGrade(){
        return this.grades
                .stream()
                .mapToDouble(n->(double)n)
                .average()
                .getAsDouble();
    }

}
