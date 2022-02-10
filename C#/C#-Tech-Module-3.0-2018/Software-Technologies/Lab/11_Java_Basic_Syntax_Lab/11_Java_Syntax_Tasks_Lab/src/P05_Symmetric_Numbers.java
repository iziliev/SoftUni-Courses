import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class P05_Symmetric_Numbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());

        List<Integer> list = new ArrayList<Integer>();
        for (int i = 1; i <= n ; i++) {
            String num = new Integer(i).toString();

            if (num.length() < 2){
                list.add(i);
            } else {
                char first = num.charAt(0);
                char last = num.charAt(num.length()-1);
                if (first == last){
                    list.add(i);
                }
            }
        }
        for (Integer item : list) {
            System.out.print(item + " ");
        }

    }
}
