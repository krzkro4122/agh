package shitANDgiggles;

/**
 * This is a documentation comment.
 * This is my first java program.
 */

import java.util.Scanner;

class LineReader {
    private static Scanner input;

    public static void main(String[] args) {
        System.out.println("Enter a line: ");
        input = new Scanner(System.in);
        System.out.println("Your input: " + input.nextLine());
    }
}