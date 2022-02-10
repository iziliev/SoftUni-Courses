import java.util.Arrays;
import java.util.Scanner;
import java.util.TreeMap;

public class P07_Sums_by_Town {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int n = Integer.parseInt(scan.nextLine());

        TreeMap<String,Double> sumByTown = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String[] input = scan.nextLine().split("\\|");

            String town = input[0];
            double income = Double.parseDouble(input[1]);

            if (!sumByTown.containsKey(town)){
                sumByTown.put(town,0.00);
            }
            sumByTown.put(town,sumByTown.get(town)+income);
        }

        for (String item:sumByTown.keySet()) {
            System.out.println(item + " -> " + sumByTown.get(item));
        }
    }
}
