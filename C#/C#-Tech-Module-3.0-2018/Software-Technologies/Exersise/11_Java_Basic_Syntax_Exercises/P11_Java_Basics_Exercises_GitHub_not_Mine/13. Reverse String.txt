import java.util.*;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();

        String reversed = new StringBuilder(text).reverse().toString();
         System.out.println(reversed);

    }
}
