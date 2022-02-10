import java.util.Scanner;

public class P01_Variable_in_Hexadecimal_Format {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
		String text = scan.nextLine();

		System.out.println(Integer.parseInt(text,16));

    }
}
