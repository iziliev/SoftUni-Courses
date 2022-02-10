import java.util.Scanner;

public class P03_Reverse_Characters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        StringBuilder result = new StringBuilder();
        for (int i = 0; i < 3; i++) {
            char letters = scan.nextLine().charAt(0);

            result.append(letters);
        }

        System.out.println(result.reverse());
    }
}
