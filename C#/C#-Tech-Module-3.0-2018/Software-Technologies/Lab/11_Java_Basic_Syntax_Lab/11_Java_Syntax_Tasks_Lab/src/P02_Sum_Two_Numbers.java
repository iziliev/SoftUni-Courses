import java.util.Scanner;

public class P02_Sum_Two_Numbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        double numOne = Double.parseDouble(scan.nextLine());
        double numTwo = Double.parseDouble(scan.nextLine());

        double sum = numOne + numTwo;

        System.out.printf("%.2f", sum);

    }
}
