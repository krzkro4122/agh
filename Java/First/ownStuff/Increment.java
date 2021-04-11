import java.util.Scanner;

class PressCounter {
    private static Scanner input;

    public static void main(String[] args) {
        int a = 0;
        input = new Scanner(System.in);

        System.out.print("Press Enter to increment and display a number: ");
        while (true) {
            input.nextLine();
            System.out.print(a++);
        }
    }
}
