import java.util.Scanner;

public class P04_Vowel_or_Digit {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine().toLowerCase();
        char symbol = input.charAt(0);

        if (symbol == 'a' || symbol == 'e' || symbol == 'i' ||
                symbol == 'o' || symbol == 'u'){
            System.out.println("vowel");
        } else if (Character.isDigit(symbol)){
            System.out.println("digit");
        } else {
            System.out.println("other");
        }
    }
}
