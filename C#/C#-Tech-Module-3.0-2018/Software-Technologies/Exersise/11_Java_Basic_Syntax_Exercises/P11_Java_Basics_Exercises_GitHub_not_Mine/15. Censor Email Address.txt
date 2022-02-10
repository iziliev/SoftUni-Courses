import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String toMatch = scan.nextLine();
        String[] email = toMatch.split("@");
        String text = scan.nextLine();
        StringBuilder replacement = new StringBuilder();

        for (int i = 0; i < email[0].length(); i++) {
            replacement.append("*");
        }
        replacement.append("@");
        replacement.append(email[1]);

         System.out.println(text.replaceAll(toMatch,replacement.toString()));
    }
}
