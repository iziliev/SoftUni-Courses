import java.util.Arrays;
import java.util.Scanner;

public class P15_Censor_Email_Address {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String email = scan.nextLine();
        String userName = email.split("@")[0];

        String replacement = getReplacement(userName.length(),'*',email);

        String text = scan.nextLine();

        text = text.replaceAll(email,replacement);

        System.out.println(text);
    }

    private static String getReplacement(int length, char c, String email) {

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < length; i++) {
            sb.append(c);
        }

        String userName = email.split("@")[0];
        return email.replaceFirst(userName,sb.toString());
    }
}
