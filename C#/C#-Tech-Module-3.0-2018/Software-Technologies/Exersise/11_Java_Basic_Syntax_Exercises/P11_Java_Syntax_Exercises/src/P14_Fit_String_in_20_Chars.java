import java.util.Scanner;

public class P14_Fit_String_in_20_Chars {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();
        String result = "";
        if (input.length() > 20){
            result = input.substring(0,20);
        } else {
            int lenght = 20-input.length();
            result = input;
            for (int i = 0; i < lenght; i++) {
                result += "*";
            }
        }

        System.out.println(result);
    }
}
