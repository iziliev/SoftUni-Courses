import java.util.Arrays;
import java.util.Scanner;

public class P09_Most_Frequent_Number {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] array = Arrays
                .stream(scan.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        int maxCount = 0;
		int num = array[0];
        int count = 0;

        for (int i = 0; i < array.length; i++) {
            for (int j = i+1; j < array.length; j++) {
                if (array[i] == array[j]) {
                    count++;
                }
				if (count > maxCount){
					
					maxCount = count;
					num = array[i];
				}
            }
            
            count = 0;
        }
        System.out.println(num);
    }
}
