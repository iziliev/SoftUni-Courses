import java.util.Scanner;

public class P05_Integer_to_Hex_and_Binary {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        Integer number = Integer.parseInt(scan.nextLine());

        System.out.println(Integer.toHexString(number).toUpperCase());
        System.out.println(Integer.toBinaryString(number));
    }
}
