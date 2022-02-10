import java.lang.reflect.Array;
import java.util.*;

public class P10_Index_of_Letters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();

        for (int j = 0; j < text.length(); j++) {
            for (int i = 'a'; i <= 'z'; i++) {
                if (text.charAt(j) == i) {
                    System.out.println(text.charAt(j) + " -> "+(text.charAt(j)-97));
                }
            }
        }
    }
}

