import java.util.Scanner;

public class P17_Change_to_Uppercase {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();

        String[] text = input.split("(<\\w+>)|(<\\/\\w+>)");

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.length; i++) {
            sb.append(text[i]);
        }

        String result = sb.toString();

        System.out.println(result);
    }
}
/*
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        String pattern = "<upcase>(.+?)<\\/upcase>";

        Pattern r = Pattern.compile(pattern);
        Matcher m = r.matcher(text);

        for (int i = 0; i < text.length(); i++) {
            if (m.find()) {
               text = text.replace(m.group(),m.group(1).toUpperCase());
            }
        }

        System.out.println(text);
    }
}
*/
