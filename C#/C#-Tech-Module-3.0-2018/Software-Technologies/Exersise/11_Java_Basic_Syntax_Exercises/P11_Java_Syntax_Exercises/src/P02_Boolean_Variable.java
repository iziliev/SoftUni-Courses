import java.util.Scanner;

public class P02_Boolean_Variable {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine().toLowerCase();
        boolean check = Boolean.parseBoolean(input);
        if (check == true){
            System.out.println("Yes");
        } else {
            System.out.println("No");
        }
    }
}
