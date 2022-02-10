import java.util.Arrays;
import java.util.Scanner;

public class P11_Equal_Sums {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int[] nums = Arrays
                .stream(scan.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        for (int i = 0; i < nums.length; i++) {
            int leftSum = Arrays
                    .stream(nums)
                    .limit(i)
                    .sum();

            int rightSum = Arrays
                    .stream(nums)
                    .skip(i+1)
                    .sum();

            if (leftSum == rightSum){
                System.out.println(i);
                return;
            }
        }
        System.out.println("no");
    }
}
