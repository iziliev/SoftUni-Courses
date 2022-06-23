import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class P12_Bomb_Numbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        List<Integer> number = Arrays
                .stream(scan.nextLine().split("\\s+"))
                .map(Integer::parseInt)
                .collect(Collectors.toList());

        int[] parameters = Arrays
                .stream(scan.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        int specialNum = parameters[0];
        int range = parameters[1];

        while (number.contains(specialNum)){
            int index = number.indexOf(specialNum);

            int leftIndex = index-range;
            if (leftIndex<0){
                leftIndex = 0;
            }
            int rightIndex = index+range;
            if (rightIndex >= number.size()){
                rightIndex = number.size() - 1;
            }

            number.subList(leftIndex,rightIndex + 1).clear();
        }

        int suma = number
                .stream()
                .mapToInt(Integer::intValue)
                .sum();

        System.out.println(suma);


    }
}
