import java.util.*;

public class P18_Phonebook {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String line = scan.nextLine();
        HashMap<String, String> phoneBook = new HashMap<>();

        while (!line.equals("END")){
            String[] input = line.split("\\s+");
            String command = input[0];
            char ch = command.charAt(0);
            if (ch == 'A'){
                String name = input[1];
                String number = input[2];

                if (!phoneBook.containsKey(name)){
                    phoneBook.put(name," ");
                }
                phoneBook.put(name,number);

            } else if (ch == 'S'){
                String name = input[1];
                if (phoneBook.containsKey(name)){
                    for (String item: phoneBook.keySet()) {

                        String items = item;

                        if (name.equals(items)) {
                            System.out.printf("%s -> %s",item,phoneBook.get(item));
                            break;
                        }
                    }
                    System.out.println();
                } else {
                    System.out.printf("Contact %s does not exist.",name);
                    System.out.println();
                }
            }

            line = scan.nextLine();
        }
    }
}
