import java.lang.reflect.Array;
import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int[] arr = Arrays.stream(scan.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        int leftSum = 0;
        int rightSum = 0;
        boolean isEqual = false;

        for (int i = 0; i < arr.length; i++) {
            for (int left = 0; left < i; left++) {
                leftSum += arr[left];
            }
            for (int right = i + 1; right < arr.length; right++) {
                rightSum += arr[right];
            }
            if (leftSum == rightSum) {
                System.out.println(i);
                isEqual = true;
                break;
            }
            leftSum = 0;
            rightSum = 0;
        }
        if (!isEqual) {
            System.out.println("no");
        }
    }
}
