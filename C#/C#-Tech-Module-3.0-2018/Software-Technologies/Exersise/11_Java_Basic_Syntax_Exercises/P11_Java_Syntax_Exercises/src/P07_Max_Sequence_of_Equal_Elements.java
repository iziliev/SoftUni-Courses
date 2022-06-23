import java.util.Arrays;
import java.util.Scanner;

public class P07_Max_Sequence_of_Equal_Elements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] array = Arrays
                .stream(scan.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        int maxCount = 1;
        int index = 0;
        int count = 1;

        for (int i = 1; i < array.length; i++) {
            if (array[i] == array[i-1]) {
                count++;
                if (count > maxCount){
                    maxCount = count;
                    index = i;
                }
            } else {
                count = 1;
            }
        }

        for (int i = index; i > index - maxCount; i--) {
            System.out.printf("%d ",array[i]);
        }
        System.out.println();
    }
}
