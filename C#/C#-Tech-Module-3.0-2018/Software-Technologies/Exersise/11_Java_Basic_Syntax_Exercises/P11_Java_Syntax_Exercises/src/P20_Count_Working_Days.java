import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Scanner;

public class P20_Count_Working_Days {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String firstDateText = scan.nextLine();
        String secondDateText = scan.nextLine();

        LocalDate firstDate = LocalDate.parse(firstDateText, DateTimeFormatter.ofPattern("dd-MM-yyyy"));
        LocalDate secondDate = LocalDate.parse(secondDateText,DateTimeFormatter.ofPattern("dd-MM-yyyy"));

        int[] holidayDays = {
            1, 3, 1, 6, 24, 6, 22, 1, 24, 25, 26
        };
        int[] holidayMouth = {
            1, 3, 5, 5, 5, 9, 9, 11, 12, 12, 12
        };

        int countWorkingDays = 0;

        for (LocalDate date = firstDate; date.isBefore(secondDate.plusDays(1)); date = date.plusDays(1)) {

            boolean check = false;

            if (date.getDayOfWeek().getValue() == 6 || date.getDayOfWeek().getValue() == 7){
                check = true;
                continue;
            }
            int currentDay = date.getDayOfMonth();
            int currentMonth = date.getMonthValue();

            for (int j = 0; j < holidayDays.length; j++){
                if (holidayDays[j] == currentDay && holidayMouth[j] == currentMonth){
                    check = true;
                    break;
                }
            }

            if (check == false){
                countWorkingDays++;
            }
        }
        System.out.println(countWorkingDays);
    }
}
