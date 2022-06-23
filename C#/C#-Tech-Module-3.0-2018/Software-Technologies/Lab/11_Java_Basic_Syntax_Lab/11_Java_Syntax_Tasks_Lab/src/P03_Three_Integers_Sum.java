import java.util.Arrays;
import java.util.Scanner;

public class P03_Three_Integers_Sum {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int num1 = scan.nextInt();
        int num2 = scan.nextInt();
        int num3 = scan.nextInt();

        if (!Check(num1, num2, num3) &&
                !Check(num3, num1, num2) &&
                !Check(num2, num3, num1)){
            System.out.println("No");
        }
    }

    static boolean Check(int num1, int num2, int sum){
        if (num1 + num2 != sum){
            return false;
        }
        if (num1 <= num2){
            System.out.printf("%d + %d = %d%n", num1, num2, sum);
        } else {
            System.out.printf("%d + %d = %d%n", num2, num1, sum);
        }
        return true;
    }
}
