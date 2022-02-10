import java.util.Arrays;
import java.util.Scanner;

public class P08_Max_Sequence_of_Increasing_Elements {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] array = Arrays
                .stream(scan.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        int maxCount = 0;
        int index = 0;
        int count = 0;

        for (int i = 0; i < array.length - 1; i++) {
            if (array[i] < array[i+1]) {
                count++;
                if (count > maxCount){
					index = i-count;
                    maxCount = count;
                    
                }
            } else {
                count = 0;
            }
        }

        for (int i = index + 1; i <= index +maxCount + 1; i++) {
            System.out.print(array[i] + " ");
        }
    }
}
