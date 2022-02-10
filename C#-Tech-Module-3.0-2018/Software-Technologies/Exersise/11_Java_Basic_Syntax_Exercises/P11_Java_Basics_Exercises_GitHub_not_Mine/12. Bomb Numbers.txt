import java.util.*;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        List<Integer> number = Arrays.stream(scan.nextLine().split("\\s+")).map(Integer::parseInt).collect(Collectors.toList());
        int[] special = Arrays.stream(scan.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        while (number.contains(special[0])) {
            int position = number.indexOf(special[0]);
            int start = position - special[1];
            int end = position + 1 + special[1];

            if (position - special[1] < 0 && position + special[1] > number.size())
                number.clear();
            else if (position - special[1] < 0)
                number.subList(0, 1 + special[1] + position).clear();
            else if (end > number.size())
                number.subList(start, number.size()).clear();
            else {
                number.subList(start, end).clear();
            }
        }
        int sum = number.stream().mapToInt(i -> i).sum();

        System.out.println(sum);
    }
}
