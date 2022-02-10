import java.util.Arrays;
import java.util.Scanner;

public class P06_Largest_3_Numbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] array = Arrays
                .stream(scan.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        Arrays.sort(array);

        int count = Math.min(3, array.length);

        for (int i = 0; i < count; i++) {
            System.out.println(array[array.length-1-i]+ " ");
        }
    }
}
