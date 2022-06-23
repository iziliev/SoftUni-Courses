package P25_Book_Library_Update;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Book_Library {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int n = Integer.parseInt(scan.nextLine());

        Library library = new Library("SoftUni");

        for (int i = 0; i <n; i++) {
            String[] tokens = scan.nextLine().split(" ");

            String title = tokens[0];
            String author = tokens[1];
            String publisher = tokens[2];
            LocalDate releaseDate = LocalDate.parse(tokens[3], DateTimeFormatter.ofPattern("dd.MM.yyyy"));
            String isbn = tokens[4];
            double price = Double.parseDouble(tokens[5]);

            Book book = new Book(title, author, publisher, releaseDate, isbn, price);

            library.getBooks().add(book);
            
                        

        }
        TreeMap<String,LocalDate> authorsSum = new TreeMap<>();

        for (Book book : library.getBooks()) {
            authorsSum.put(book.getTitle(),book.getReleaseDate());

        }

        Map<String,LocalDate> newDate = new LinkedHashMap<>();

        LocalDate finalDate = LocalDate.parse(scan.nextLine(),DateTimeFormatter.ofPattern("dd.MM.yyyy"));

        for (String item : authorsSum.keySet()) {
            LocalDate dates = authorsSum.get(item);
            if (dates.isAfter(finalDate)){
                newDate.put(item,authorsSum.get(item));
            }
        }

        newDate.entrySet()
                .stream()
                .sorted((a1,a2)->{
                    int compareResult = a1.getValue().compareTo(a2.getValue());

                    if (compareResult > 0){
                        compareResult = a1.getKey().compareTo(a2.getKey());
                    }
                    return compareResult;
                })
                .forEach(a-> System.out.printf("%s -> %s%n",a.getKey(),DateTimeFormatter.ofPattern("dd.MM.yyyy").format(a.getValue())));
    }
}
