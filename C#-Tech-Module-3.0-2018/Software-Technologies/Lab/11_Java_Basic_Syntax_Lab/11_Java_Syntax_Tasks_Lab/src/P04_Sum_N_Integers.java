import java.util.Scanner;

public class P04_Sum_N_Integers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());
        long sum = 0;

        for (int i = 0; i < n; i++) {
            int nextNum = Integer.parseInt(scan.nextLine());
            sum+=nextNum;
        }
        System.out.println("Sum = " + sum);
    }
}
