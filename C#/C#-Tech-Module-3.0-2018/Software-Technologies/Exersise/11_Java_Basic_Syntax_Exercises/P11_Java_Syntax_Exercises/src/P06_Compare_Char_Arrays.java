import java.util.Arrays;
import java.util.Scanner;

public class P06_Compare_Char_Arrays {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        char[] arrOne = scan
                .nextLine()
                .toCharArray();
        char[] arrTwo = scan
                .nextLine()
                .toCharArray();

        if (arrOne.length > arrTwo.length){
            for (char ch:arrTwo) {
                if (ch != ' ') {
                    System.out.printf("%c", ch);
                }
            }
            System.out.println();
            for (char ch:arrOne) {
                if (ch != ' ') {
                    System.out.printf("%c", ch);
                }
            }
            System.out.println();
        } else if (arrOne.length < arrTwo.length) {
            for (char ch:arrOne) {
                if (ch != ' ') {
                    System.out.printf("%c", ch);
                }
            }
            System.out.println();
            for (char ch:arrTwo) {
                if (ch != ' ') {
                    System.out.printf("%c", ch);
                }
            }
            System.out.println();
        } else {
            boolean check = true;
            for (int i = 0; i < arrOne.length; i++) {
                if (arrOne[i] < arrTwo[i]) {
                    for (char ch:arrOne) {
                        if (ch != ' ') {
                            System.out.printf("%c", ch);
                        }                    }
                    System.out.println();
                    for (char ch:arrTwo) {
                        if (ch != ' ') {
                            System.out.printf("%c", ch);
                        }                    }
                    System.out.println();
                    check = true;
                    break;
                } else if (arrOne[i] > arrTwo[i]) {
                    for (char ch:arrTwo) {
                        if (ch != ' ') {
                            System.out.printf("%c", ch);
                        }
                    }
                    System.out.println();
                    for (char ch:arrOne) {
                        if (ch != ' ') {
                            System.out.printf("%c", ch);
                        }
                    }
                    System.out.println();
                    check = true;
                    break;
                } else {
                    check = false;
                }
            }
            if (check == false) {
                for (char ch:arrOne) {
                    if (ch != ' ') {
                        System.out.printf("%c", ch);
                    }
                }
                System.out.println();
                for (char ch:arrTwo) {
                    if (ch != ' ') {
                        System.out.printf("%c", ch);
                    }
                }
                System.out.println();
            }
        }

    }
}
