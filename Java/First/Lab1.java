import java.util.Date;
import java.util.Calendar;
import java.text.SimpleDateFormat;

class Lab1 {
    private static String months[] = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
    public static void main(String[] args) {
    

        System.out.println("Deprecated approach: ");
        Date date = new Date();
        System.out.println("Current Date: " + new Date().toString());
        int weekday_index = date.getDay();
        System.out.println("Number of the current day of the week: " + weekday_index);
        if ( weekday_index == 6 || weekday_index == 0 )
            System.out.println("It means it's the weekend today.");
        else
            System.out.println("It means it's a weekday today.");
        

        System.out.println("\nCalendar approach: ");
        Calendar calendar = Calendar.getInstance();
        Date d = calendar.getTime();
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy.MM.dd HH:mm");
        System.out.println(simpleDateFormat.format(d));

        System.out.println(new SimpleDateFormat("yyyy.MM.dd HH:mm").format(Calendar.getInstance().getTime())); // 1-line version

        int month = calendar.get(Calendar.MONTH) + 1;
        System.out.print("\nCurrent month is: ");
        switch(month){
            case 1:
                System.out.println("January\n");
                break;
            case 2:
                System.out.println("February\n");
                break;
            case 3:
                System.out.println("March\n");
                break;
            case 4:
                System.out.println("April\n");
                break;
            case 5:
                System.out.println("May\n");
                break;
            case 6:
                System.out.println("June\n");
                break;
            case 7:
                System.out.println("July\n");
                break;
            case 8:
                System.out.println("August\n");
                break;
            case 9:
                System.out.println("September\n");
                break;
            case 10:
                System.out.println("October\n");
                break;
            case 11:
                System.out.println("November\n");
                break;
            case 12:
                System.out.println("December\n");
                break;
        }

        month = calendar.get(Calendar.MONTH);
        System.out.println("Current month is: " + months[month] + " (Array approach)");
    }
}