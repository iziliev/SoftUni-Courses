import java.util.*;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();

        if (text.length()>=20){
         char [] newText = text.toCharArray();
            for (int i = 0; i < 20; i++) {
                System.out.print(newText[i]);
            }
        }
        else{
            System.out.print(text);
            for (int i = text.length(); i < 20; i++) {
                System.out.print("*");
            }
        }
    }
}
