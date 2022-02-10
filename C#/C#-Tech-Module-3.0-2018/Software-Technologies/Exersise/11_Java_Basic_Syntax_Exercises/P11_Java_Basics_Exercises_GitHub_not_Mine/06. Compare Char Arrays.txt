import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String first = scan.nextLine();
        String second = scan.nextLine();

        int compare = first.compareTo(second);
        
        if (compare < 0){
            System.out.println(first.replaceAll("\\W", ""));
            System.out.println(second.replaceAll("\\W", ""));
        }
        else {
            System.out.println(second.replaceAll("\\W", ""));
            System.out.println(first.replaceAll("\\W", ""));

        }
    }
}
