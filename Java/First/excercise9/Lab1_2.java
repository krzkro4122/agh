package excercise9;

public class Lab1_2 {
    static int count = 0;
    public Lab1_2(){
        System.out.println(count + ": Hello!");
        count++;
    }
    public static void main(String[] args){

        int max = Integer.valueOf(args[0]);
        int min = Integer.valueOf(args[0]);
        float average = 0;

        for (String element : args){
            /*
            System.out.println(i + "." + element);
            */
            average += Integer.valueOf(element);
            if (Integer.valueOf(element) > max)
                max = Integer.valueOf(element);
            if (Integer.valueOf(element) < min)
                min = Integer.valueOf(element);
        }

        average /= args.length;
        System.out.println(args.length + " arguments were passed to my program.");
        System.out.println("Maximum value is: " + max);
        System.out.println("Minimum value is: " + min);
        System.out.println("Arithmetic average is: " + average);

        
        for ( int i = 0; i < Integer.valueOf(args[0]); i++){
            new Lab1_2();
        }  
    }
}
