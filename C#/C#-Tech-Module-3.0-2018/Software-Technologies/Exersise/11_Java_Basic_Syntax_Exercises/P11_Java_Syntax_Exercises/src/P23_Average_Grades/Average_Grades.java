package P23_Average_Grades;

import java.util.*;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class Average_Grades {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int n = Integer.parseInt(scan.nextLine());
        
        ArrayList<Student> students = new ArrayList<>();

        for (int i = 0; i < n; i++) {
            String[] input = scan.nextLine().split(" ");
            
            String name = input[0];
            ArrayList<Double> grades = new ArrayList<>();

            for (int j = 1; j < input.length; j++) {
                grades.add(Double.parseDouble(input[j]));
            }

            students.add(new Student(name,grades));
        }

        students
                .stream()
                .filter(s -> s.getAverageGrade() >= 5)
                .sorted(
                        Comparator.comparing(Student::getName)
                                .thenComparing(Comparator.comparing(Student::getAverageGrade).reversed())
                )
                .collect(Collectors.toList())
                .forEach(r -> System.out.printf("%s -> %.2f%n", r.getName(),r.getAverageGrade()));

    }

}
