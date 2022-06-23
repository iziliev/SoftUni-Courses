import java.util.Arrays;
import java.util.Scanner;

public class P13_Reverse_String {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();

        char[] result = input.toCharArray();

        for (int i = result.length-1; i >= 0 ; i--) {
            System.out.printf("%c",result[i]);
        }
        System.out.println();
    }
}
